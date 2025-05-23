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
    public partial class PeriodSelectForm : Form
    {
        public string SelectedPeriod => comboBox1.SelectedItem?.ToString();

        public PeriodSelectForm()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "전체", "이번주", "이번달" });
            comboBox1.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
