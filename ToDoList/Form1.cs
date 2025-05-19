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

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        //데이터를 데이터 테이블에 저장 후 데이터 그리드 뷰에서 볼 수 있도록 함
        DataTable todoList = new DataTable("ToDoList");
        //현재 데이터를 수정 중인가 
        bool isEditing = false;
        //현재 exe 파일이 저장되어 있는 경로
        string filePath = Path.Combine(Application.StartupPath, "todolist.xml");



        private void ToDoList_Load(object sender, EventArgs e)
        {
            //제목, 설명, 시작날짜, 종료날짜 추가
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            todoList.Columns.Add("Start", typeof(DateTime));
            todoList.Columns.Add("End", typeof(DateTime));
            todoList.Columns.Add("IsCompleted", typeof(bool));



            toDoListView.AllowUserToAddRows = false;
            toDoListView.DataSource = todoList;


            calendar.DateChanged += calendar_DateChanged;  // 날짜 클릭 이벤트 연결

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

            DataView view = new DataView(todoList);
            view.RowFilter = filter;

            toDoListView.DataSource = view;
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            using (var form = new AddScheduleForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // 일정 저장
                    todoList.Rows.Add(
                        form.ScheduleTitle,
                        form.ScheduleDescription,
                        form.StartDate,
                        form.EndDate,
                        false
                    );

                    // 달력에 시작일 강조
                    calendar.AddBoldedDate(form.StartDate);
                    calendar.UpdateBoldedDates();
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (toDoListView.CurrentCell == null || toDoListView.CurrentCell.RowIndex < 0)
                {
                    MessageBox.Show("수정할 항목을 먼저 선택하세요.");
                    return;
                }

                isEditing = true;

                var row = ((DataRowView)toDoListView.CurrentRow.DataBoundItem).Row;
                titleTextBox.Text = row["Title"].ToString();
                descriptionTextBox.Text = row["Description"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            //텍스트 박스가 비어있는 경우
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("제목과 설명이 비어있습니다.");
                return;
            }

            if (isEditing)
            {
                //edit 선택된 셀을 수정
                var row = ((DataRowView)toDoListView.CurrentRow.DataBoundItem).Row;
                row["Title"] = titleTextBox.Text;
                row["Description"] = descriptionTextBox.Text;
                row["Start"] = calendar.SelectionStart.Date;
                row["End"] = calendar.SelectionEnd.Date;
            }
            else
            {
                //열 추가
                todoList.Rows.Add(
                    titleTextBox.Text,
                    descriptionTextBox.Text,
                    calendar.SelectionStart.Date,
                    calendar.SelectionEnd.Date,
                    false
                );
            }
            //초기화
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            calendar.SelectionStart = calendar.TodayDate;
            calendar.SelectionEnd = calendar.TodayDate;
            isEditing = false;

        }
        
        //빈 셀은 체크박스 비활성화
        private void toDoListView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (toDoListView.Columns[e.ColumnIndex].Name == "IsCompleted")
            {
                var taskName = toDoListView.Rows[e.RowIndex].Cells["Title"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(taskName))
                {
                    e.Cancel = true;
                }
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
            API ApiForm = new API();

            ApiForm.ShowDialog();

        }

    }
}
