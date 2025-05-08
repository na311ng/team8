using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        DataTable todoList = new DataTable();
        //현재 데이터를 수정 중인가 
        bool isEditing = false;
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
                        form.EndDate
                    );

                    // 달력에 시작일 강조
                    calendar.AddBoldedDate(form.StartDate);
                    calendar.UpdateBoldedDates();
                }
            }
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            //제목, 설명, 시작날짜, 종료날짜 추가
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            todoList.Columns.Add("Start", typeof(DateTime));
            todoList.Columns.Add("End",typeof(DateTime));

            //체크박스 추가
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "완료 여부";
            checkBoxColumn.Name = "IsCompleted";
            toDoListView.Columns.Add(checkBoxColumn);

            toDoListView.AllowUserToAddRows = false;

            toDoListView.DataSource = todoList;

            //체크박스 열의 너비 수정, 그리드에 데이터를 넣은 후에 너비 설정
            toDoListView.Columns[0].Width = 100;
            toDoListView.RowHeadersWidth = 80;
        }

        private void editButton_Click(object sender, EventArgs e)
        {

            try
            {
                //셀을 선택하지 않았거나 항목이 존재하지 않는 경우
                if (toDoListView.CurrentCell == null || toDoListView.CurrentCell.RowIndex < 0)
                {
                    MessageBox.Show("수정할 항목을 먼저 선택하세요.");
                    return;
                }

                isEditing = true;

                //선택된 셀들을 텍스트 박스로 올림
                titleTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
                descriptionTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                //셀을 선택하지 않았거나 항목이 존재하지 않는 경우
                if (toDoListView.CurrentCell == null || toDoListView.CurrentCell.RowIndex < 0)
                {
                    MessageBox.Show("삭제될 항목을 먼저 선택하세요.");
                    return;
                }

                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete(); //선택 셀 삭제
            }
            catch(Exception ex)
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
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextBox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Start"] = calendar.SelectionStart.Date;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["End"] = calendar.SelectionEnd.Date;
            }
            else
            {
                //열 추가
                todoList.Rows.Add(
                    titleTextBox.Text,
                    descriptionTextBox.Text,
                    calendar.SelectionStart.Date,
                    calendar.SelectionEnd.Date
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

            Chart ChartForm = new Chart();
            
            ChartForm.ShowDialog(); 

        }

        private void btnApi_Click(object sender, EventArgs e)
        {
            API ApiForm = new API();

            ApiForm.ShowDialog();

        }
    }
}
