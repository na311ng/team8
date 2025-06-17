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
        public CategoryForm(IEnumerable<string> categories)
        {
            InitializeComponent();
            foreach (var category in categories.OrderBy(c => c))
            {
                checkedListBox1.Items.Add(category, false); // 기본으로 체크
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedCategories.Clear();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                SelectedCategories.Add(item.ToString());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategory = txtNewCategory.Text.Trim();

            if (!string.IsNullOrEmpty(newCategory) && !checkedListBox1.Items.Contains(newCategory))
            {
                checkedListBox1.Items.Add(newCategory, true); // 추가되면서 자동 체크
                txtNewCategory.Clear(); // 입력창 초기화
            }
            else
            {
                MessageBox.Show("중복되었거나 빈 카테고리입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
