using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class ApiKey : MaterialForm
    {
        public string EnteredApiKey => txtApiKey.Text;

        public ApiKey(string themeName)
        {
            InitializeComponent();
            ApplyMaterialTheme(themeName);
        }

        private void ApplyMaterialTheme(string theme)
        {
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;

            switch (theme)
            {
                case "Blue":
                    skinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Blue700, Primary.Blue100, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case "Red":
                    skinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.Red700, Primary.Red100, Accent.Pink200, TextShade.WHITE);
                    break;
                case "Green":
                    skinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green700, Primary.Green100, Accent.LightGreen200, TextShade.WHITE);
                    break;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApiKey.Text))
            {
                MessageBox.Show("API 키를 입력해주세요.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}