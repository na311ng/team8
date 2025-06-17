using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ToDoList
{
    public partial class ToDoList : MaterialForm
    {
        public ToDoList()
        {
            InitializeComponent();
            ApplyTheme("Blue");
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700,
                Primary.Indigo100, Accent.Pink200,
                TextShade.WHITE);
            // 예시: toDoListView가 DataGridView 컨트롤 이름일 때
            toDoListView.EnableHeadersVisualStyles = false;

            // 전체 그리드의 기본 배경/글자색
            toDoListView.BackgroundColor = Color.FromArgb(38, 50, 56); // 색 조정
            toDoListView.DefaultCellStyle.BackColor = Color.White; // 셀 배경
            toDoListView.DefaultCellStyle.ForeColor = Color.Black; // 셀 글자색

            // 선택된 셀 스타일
            toDoListView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243); // 파란색 선택
            toDoListView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 헤더 스타일
            toDoListView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181); 
            toDoListView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            toDoListView.ColumnHeadersDefaultCellStyle.Font = new Font("Bold", 10, FontStyle.Bold);
        }

        //데이터를 데이터 테이블에 저장 후 데이터 그리드 뷰에서 볼 수 있도록 함
        DataTable todoList = new DataTable("ToDoList");
        //현재 데이터를 수정 중인가 
        bool isEditing = false;
        //현재 exe 파일이 저장되어 있는 경로
        string filePath = Path.Combine(Application.StartupPath, "todolist.xml");
        //카테고리 리스트
        List<string> categories = new List<string> { };

        public void ApplyTheme(string theme)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            switch (theme)
            {
                case "Blue":
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Blue500, Primary.Blue700, Primary.Blue100, Accent.LightBlue200, TextShade.WHITE
                    );
                    break;
                case "Red":
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Red500, Primary.Red700, Primary.Red100, Accent.Pink200, TextShade.WHITE
                    );
                    break;
                case "Green":
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Green500, Primary.Green700, Primary.Green100, Accent.LightGreen200, TextShade.WHITE
                    );
                    break;
            }
        }
        private void btnShop_Click(object sender, EventArgs e)
        {
            // 상점 창 띄우기
            ShopForm shop = new ShopForm(this);
            shop.ShowDialog();
        }
        

        private void ToDoList_Load(object sender, EventArgs e)
        {
            // 컬럼 정의
            todoList.Columns.Add("Title", typeof(string));
            todoList.Columns.Add("Description", typeof(string));
            todoList.Columns.Add("Start", typeof(DateTime));
            todoList.Columns.Add("End", typeof(DateTime));
            todoList.Columns.Add("Priority", typeof(int));
            todoList.Columns.Add("IsCompleted", typeof(bool));
            todoList.Columns.Add("Category", typeof(string));
            todoList.Columns.Add("URL", typeof(string));

            if (!todoList.Columns.Contains("CompletedDate"))
                todoList.Columns.Add("CompletedDate", typeof(DateTime));

            //그리드뷰에 생성
            toDoListView.DataSource = todoList;
            toDoListView.AllowUserToAddRows = false;

            toDoListView.Columns["Start"].DefaultCellStyle.Format = "MM-dd";
            toDoListView.Columns["End"].DefaultCellStyle.Format = "MM-dd";

            //그리드뷰에서 ULR이 보이지 않도록 설정 (투두리스트가 생성 후에 설정)
            if (toDoListView.Columns["URL"] != null)
            {
                int urlIndex = toDoListView.Columns["URL"].Index;
                DataGridViewLinkColumn linkCol = new DataGridViewLinkColumn
                {
                    Name = "URL",
                    HeaderText = "Link",
                    DataPropertyName = "URL",
                    UseColumnTextForLinkValue = false,
                    LinkBehavior = LinkBehavior.HoverUnderline,
                    TrackVisitedState = false
                };

                toDoListView.Columns.RemoveAt(urlIndex);
                toDoListView.Columns.Insert(urlIndex, linkCol);
            }
                

            // 특정 컬럼은 읽기 전용으로 설정
            foreach (DataGridViewColumn col in toDoListView.Columns)
            {
                if (col.Name != "IsCompleted")
                    col.ReadOnly = true;
                else
                    col.ReadOnly = false; // 체크박스만 편집 가능
            }

            calendar.TitleBackColor = Color.FromArgb(63, 81, 181);
            calendar.TitleForeColor = Color.White;
            calendar.TrailingForeColor = Color.LightGray;
            calendar.BackColor = Color.FromArgb(38, 50, 56);
            calendar.ForeColor = Color.White;
            calendar.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
            panelCalendar.BackColor = Color.FromArgb(55, 71, 79); // Panel 배경 추가시

            calendar.DateChanged += calendar_DateChanged;  // 날짜 클릭 이벤트 연결


            //카테고리 콤보박스 컬럼 생성
            DataGridViewComboBoxColumn categoryColumn = new DataGridViewComboBoxColumn();
            categoryColumn.HeaderText = "Category";
            categoryColumn.Name = "Category";
            categoryColumn.DataPropertyName = "Category"; //데이터 테이블 연결

            // 전체를 읽기 전용으로 설정하지 말고
            toDoListView.ReadOnly = false; // 전체는 편집 가능 상태로

            //폼 로드 시 저장된 파일로부터 데이터 로드
            LoadFromFile(filePath);
        }

        //저장 기능//
        private void SaveToFile(string path)
        {
            try
            {
                if(todoList.Rows.Count == 0) //테이블이 비어있으면
                {
                    using (DataSet ds = new DataSet())
                    {
                        ds.Tables.Add(todoList.Clone()); //스키마만 저장 (테이블이 비어있을 때 빈 파일을 생성하기 위해)
                        ds.WriteXml(path, XmlWriteMode.WriteSchema);
                    }
                }
                else
                {
                    todoList.WriteXml(path, XmlWriteMode.WriteSchema);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일 저장 실패: " + ex.Message);
            }

        }
        private void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return; //파일이 존재하지 않으면 리턴
            try
            {
                if (File.Exists(path))
                {
                    todoList.ReadXml(path); //경로의 xml파일을 읽음
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일 불러오기 실패: " + ex.Message);
            }
        }

        private void ToDoList_FormClosed(object sender, FormClosedEventArgs e)
        {
            //닫을 때 저장
            SaveToFile(filePath);
        }


        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start.Date;
            string filter = $"#{selectedDate:MM/dd/yyyy}# >= Start AND #{selectedDate:MM/dd/yyyy}# <= End";

            // 완료된 날짜 이후는 표시하지 않도록
            filter += $" AND (CompletedDate IS NULL OR CompletedDate >= #{selectedDate:MM/dd/yyyy}#)";

            DataView view = new DataView(todoList);
            view.RowFilter = filter;

            toDoListView.DataSource = view;
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            using (var form = new AddScheduleForm())
            {
                form.SetPriorityRange(todoList.Rows.Count);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var existingCategories = todoList.AsEnumerable()
                        .Where(row => row.RowState != DataRowState.Deleted)
                        .Select(row => row.Field<string>("Category"))
                        .Where(c => !string.IsNullOrWhiteSpace(c))
                        .SelectMany(c => c.Split(',').Select(x => x.Trim())) // "Work, Study" 처럼 여러 개 있을 경우 분리
                        .Distinct()
                        .OrderBy(c => c)
                        .ToList();

                    using (var categoryForm = new CategoryForm(existingCategories))
                    {
                        string selectedCategory = "";
                        if (categoryForm.ShowDialog() == DialogResult.OK)
                        {
                            selectedCategory = string.Join(", ", categoryForm.SelectedCategories);
                        }

                        // 2. 일정 추가 (Category 포함)
                        todoList.Rows.Add(
                            form.ScheduleTitle,
                            form.ScheduleDescription,
                            form.StartDate,
                            form.EndDate,
                            form.Priority,
                            false,                // IsCompleted
                            selectedCategory,     // Category
                            form.ScheduleURL      // URL 기본값
                        );

                        SortTodoListByPriority();

                        // 3. 달력에 시작일 강조
                        calendar.AddBoldedDate(form.StartDate);
                        calendar.UpdateBoldedDates();
                    }
                }
            }
        }

        

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (toDoListView.CurrentCell == null || toDoListView.CurrentCell.RowIndex < 0)
                {
                    MessageBox.Show("삭제할 항목을 먼저 선택하세요.");
                    return;
                }

                var row = ((DataRowView)toDoListView.CurrentRow.DataBoundItem).Row;
                row.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
        
        private void btnChart_Click(object sender, EventArgs e)
        {

            DateTime selectedDate = calendar.SelectionStart; // 달력에서 선택된 날짜
            Chart chartForm = new Chart(todoList, selectedDate);
            chartForm.ShowDialog();

        }

        private void btnApi_Click(object sender, EventArgs e)
        {
            // API 키 먼저 실행
            var apiKeyForm = new ApiKey();
            if (apiKeyForm.ShowDialog() == DialogResult.OK)
            {
                string userKey = apiKeyForm.EnteredApiKey;

                // todoList는 현재 폼(Form1)에서 선언된 데이터테이블임
                API apiForm = new API(todoList, userKey);
                apiForm.ShowDialog();
            }
        }

        private void toDoListView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // 헤더 등 무시

            var row = ((DataRowView)toDoListView.Rows[e.RowIndex].DataBoundItem).Row;

            using (var form = new AddScheduleForm())
            {
                // 기존 데이터를 폼에 미리 넣어줄 수 있으면 좋음
                form.ScheduleTitle = row["Title"].ToString();
                form.ScheduleDescription = row["Description"].ToString();
                form.StartDate = (DateTime)row["Start"];
                form.EndDate = (DateTime)row["End"];

                if (form.ShowDialog() == DialogResult.OK)
                {
                    // 수정 완료 후 DataRow에 반영
                    row["Title"] = form.ScheduleTitle;
                    row["Description"] = form.ScheduleDescription;
                    row["Start"] = form.StartDate;
                    row["End"] = form.EndDate;

                    // DataGridView 자동 갱신
                    toDoListView.Refresh();
                }
            }
        }

        private void toDoListView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (toDoListView.Columns[e.ColumnIndex].Name == "IsCompleted")
            {
                var row = ((DataRowView)toDoListView.Rows[e.RowIndex].DataBoundItem).Row;
                bool isChecked = Convert.ToBoolean(row["IsCompleted"]);

                

                if (isChecked)
                {
                    // 완료 날짜를 체크한 날짜로 설정
                    row["CompletedDate"] = DateTime.Today;
                }
                else
                {
                    // 체크 해제 시 완료 날짜 초기화
                    row["CompletedDate"] = DBNull.Value;
                }

                toDoListView.Refresh();
            }
        }

        private void toDoListView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (toDoListView.Columns[e.ColumnIndex].Name == "IsCompleted")
            {
                var row = ((DataRowView)toDoListView.Rows[e.RowIndex].DataBoundItem).Row;

                if (row.RowState == DataRowState.Deleted) return;

                DateTime selected = calendar.SelectionStart.Date;
                var completedDate = row["CompletedDate"] as DateTime?;

                if (completedDate != null)
                {
                    if (selected > completedDate.Value)
                    {
                        e.CellStyle.ForeColor = Color.Gray;  // 완료 이후 날짜는 회색
                        e.CellStyle.SelectionForeColor = Color.Gray;
                    }
                    else if (selected == completedDate.Value)
                    {
                        e.CellStyle.ForeColor = Color.Black; // 완료한 당일은 일반 글씨
                        e.CellStyle.SelectionForeColor = Color.Black;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Black; // 완료 전 날짜는 기본
                        e.CellStyle.SelectionForeColor = Color.Black;
                        e.Value = false; // 체크 표시 안 함
                    }
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.SelectionForeColor = Color.Black;
                    e.Value = false; // 완료 날짜 없으면 체크 안 됨
                }
            }
        }
        
        private void SortTodoListByPriority()
        {
            // DataTable 필터 또는 소팅
            todoList.DefaultView.Sort = "Priority ASC";
            DataTable sorted = todoList.DefaultView.ToTable();
            todoList.Clear();
            foreach (DataRow row in sorted.Rows)
                todoList.ImportRow(row);
            toDoListView.DataSource = todoList; // DataSource 갱신
        }

        private void toDoListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toDoListView.Columns[e.ColumnIndex].Name == "URL")
            {
                string url = toDoListView.Rows[e.RowIndex].Cells["URL"].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(url))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid URL: " + ex.Message);
                    }
                }
            }
        }

        private void toDoListView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (toDoListView.IsCurrentCellDirty)
            {
                toDoListView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
