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
    public partial class CategoryForm : Form
    {
        public List<string> SelectedCategories { get; private set; } = new List<string>();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedCategories.Clear();

            if (chkWork.Checked) SelectedCategories.Add("Work");
            if (chkStudy.Checked) SelectedCategories.Add("Study");
            if (chkHealth.Checked) SelectedCategories.Add("Health");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
