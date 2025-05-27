using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class ApiKey : Form
    {
        public string EnteredApiKey { get; private set; }

        public ApiKey()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string inputKey = txtApiKey.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputKey))
            {
                MessageBox.Show("API 키를 입력하세요.");
                return;
            }

            bool isValid = await ValidateApiKeyAsync(inputKey);

            if (isValid)
            {
                EnteredApiKey = inputKey;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("유효하지 않은 API 키입니다.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private async Task<bool> ValidateApiKeyAsync(string key)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", key);

                    var response = await client.GetAsync("https://api.openai.com/v1/models");
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
