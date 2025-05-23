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
    public partial class AddScheduleForm : Form
    {

        private void ToDoList_Load(object sender, EventArgs e)
        {

        }
        
        DataTable todoList = new DataTable();
        public string ScheduleTitle
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }

        public string ScheduleDescription
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public DateTime StartDate
        {
            get { return dtpStart.Value; }
            set { dtpStart.Value = value; }
        }

        public DateTime EndDate
        {
            get { return dtpEnd.Value; }
            set { dtpEnd.Value = value; }
        }



        public AddScheduleForm()
        {
            InitializeComponent();
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("제목을 입력하세요.");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public int Priority
        {
            get { return int.Parse(domainUpDownPriority.Text); }
            set { domainUpDownPriority.Text = value.ToString(); }
        }
        // 폼 열릴 때 현재 할 일 개수에 맞게 세팅 (외부에서 todoCount 받아도 되고, 넘겨받아야 더 안전)
        public void SetPriorityRange(int todoCount)
        {
            domainUpDownPriority.Items.Clear();
            for (int i = 1; i <= todoCount + 1; i++) // 새 할 일 추가시 +1
                domainUpDownPriority.Items.Add(i.ToString());
            domainUpDownPriority.Text = "1";
        }
    }

}
