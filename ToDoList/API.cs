using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ToDoList
{
    public partial class API : Form
    {
        private DataTable todoList;
        private string apiKey;

        public API(DataTable todoList, string apiKey)
        {
            InitializeComponent();
            this.todoList = todoList;
            this.apiKey = apiKey;
        }

        private async void btnEvaluate_Click(object sender, EventArgs e)
        {
            string jsonData = ConvertToJson(todoList);
            string feedback = await GetFeedbackFromGPTAsync(jsonData);
            txtFeedback.Text = feedback;
        }

        private string ConvertToJson(DataTable table)
        {
            var items = new List<object>();

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                items.Add(new
                {
                    title = row["Title"].ToString(),
                    start = Convert.ToDateTime(row["Start"]).ToString("yyyy-MM-dd"),
                    end = Convert.ToDateTime(row["End"]).ToString("yyyy-MM-dd"),
                    isCompleted = Convert.ToBoolean(row["IsCompleted"])
                });
            }

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(items);
        }

        private async Task<string> GetFeedbackFromGPTAsync(string jsonData)
        {
            try
            {
                // 날짜 범위 계산
                var dates = todoList.AsEnumerable()
                    .Where(r => r.RowState != DataRowState.Deleted)
                    .SelectMany(r => new[] {
                Convert.ToDateTime(r["Start"]),
                Convert.ToDateTime(r["End"])
                    });

                DateTime minDate = dates.Min();
                DateTime maxDate = dates.Max();
                string dateRange = $"{minDate:yyyy-MM-dd}~{maxDate:yyyy-MM-dd}";

                // 프롬프트 작성
                string prompt = $@"
아래 일정 데이터를 분석해서 사용자에게 보여줄 간단한 피드백을 만들어줘.

- 총 일정 수
- 완료율 (정수%)
- 짧고 직관적인 피드백 문장

JSON 형식으로 응답:
{{
  ""totalTasks"": 숫자,
  ""completionRate"": ""n%"",
  ""feedback"": ""문장""
}}

데이터:
{jsonData}";

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", apiKey);

                    var requestBody = new
                    {
                        model = "gpt-3.5-turbo",
                        messages = new[]
                        {
                    new { role = "system", content = "너는 할 일 데이터를 분석하는 AI야." },
                    new { role = "user", content = prompt }
                }
                    };

                    string requestJson = new JavaScriptSerializer().Serialize(requestBody);
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                    response.EnsureSuccessStatusCode();

                    var responseBody = await response.Content.ReadAsStringAsync();

                    // JSON 응답 파싱
                    string contentText = JObject.Parse(responseBody)["choices"][0]["message"]["content"].ToString();

                    // GPT가 응답한 JSON을 다시 파싱
                    var parsed = JObject.Parse(contentText);

                    int totalTasks = parsed["totalTasks"].ToObject<int>();
                    string completionRate = parsed["completionRate"].ToString();
                    string feedback = parsed["feedback"].ToString();

                    return $"📌 총 일정: {totalTasks}개\r\n" +
                           $"📊 완료율: {completionRate}\r\n" +
                           $"📝 피드백: {feedback}";
                }
            }
            catch (Exception ex)
            {
                return $"오류 발생: {ex.Message}";
            }
        }
    }
}
