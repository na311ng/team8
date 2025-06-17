using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class API : MaterialForm
    {
        private DataTable todoList;
        private string apiKey;
        private string themeName;

        public API(DataTable todoList, string apiKey, string themeName)
        {
            InitializeComponent();
            this.todoList = todoList;
            this.apiKey = apiKey;
            this.themeName = themeName;
            ApplyMaterialTheme(themeName);

            // DateTimePicker 초기화
            dtpStart.Value = DateTime.Today.AddDays(-7);
            dtpEnd.Value = DateTime.Today;

            //피드백 텍스트박스 폰트 키우기 왜 안되지
            txtFeedback.Font = new Font("맑은 고딕", 12, FontStyle.Regular);
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

        private async void btnEvaluate_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("종료 날짜는 시작 날짜보다 뒤여야 합니다.");
                return;
            }

            string jsonData = ConvertToJson(todoList, startDate, endDate);
            string feedback = await GetFeedbackFromGPTAsync(jsonData, startDate, endDate);
            txtFeedback.Text = FormatFeedback(feedback);
        }

        private string ConvertToJson(DataTable table, DateTime start, DateTime end)
        {
            var filteredData = new List<object>();

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                DateTime taskStart = Convert.ToDateTime(row["Start"]);
                DateTime taskEnd = Convert.ToDateTime(row["End"]);

                if (taskEnd < start || taskStart > end) continue;

                filteredData.Add(new
                {
                    Title = row["Title"].ToString(),
                    Start = taskStart.ToString("yyyy-MM-dd"),
                    End = taskEnd.ToString("yyyy-MM-dd"),
                    IsCompleted = Convert.ToBoolean(row["IsCompleted"]),
                    Category = row["Category"].ToString(),
                    Priority = Convert.ToInt32(row["Priority"]),
                    CompletedDate = row["CompletedDate"] is DBNull ? null :
                                   ((DateTime)row["CompletedDate"]).ToString("yyyy-MM-dd")
                });
            }

            return new JavaScriptSerializer().Serialize(filteredData);
        }

        private string FormatFeedback(string jsonFeedback)
        {
            try
            {
                dynamic data = JObject.Parse(jsonFeedback);
                StringBuilder sb = new StringBuilder();

                // 1. 핵심 지표
                sb.AppendLine($"📌 완료율: {data.completionRate?.ToString() ?? "N/A"}");

                // 카테고리 처리 (빈 값 방지)
                string weakestCategory = data.weakestCategory?.ToString();
                if (!string.IsNullOrEmpty(weakestCategory))
                {
                    sb.AppendLine($"📊 완료율이 낮은 카테고리: {weakestCategory} " +
                                 $"({data.categories[weakestCategory]?.rate?.ToString() ?? "N/A"})");
                }

                string mostCommonCategory = data.mostCommonCategory?.ToString();
                if (!string.IsNullOrEmpty(mostCommonCategory))
                {
                    sb.AppendLine($"📈 가장 많은 항목: {mostCommonCategory} " +
                                 $"({data.categories[mostCommonCategory]?.count?.ToString() ?? "N/A"}개)");
                }

                // 주차 정보
                sb.AppendLine($"🗓 집중 주차: {data.focusWeek?.ToString() ?? "N/A"} " +
                             $"({data.weekStart?.ToString() ?? ""} ~ {data.weekEnd?.ToString() ?? ""})");

                // 우선순위
                sb.AppendLine($"🔥 우선순위 완료율: {data.highPriority?.rate?.ToString() ?? "N/A"}");

                // 2. 미완료 항목
                sb.AppendLine("\n❌ 미완료 항목:");
                if (data.incompleteItems != null)
                {
                    foreach (var item in data.incompleteItems)
                    {
                        sb.AppendLine($"- {item.date?.ToString() ?? "N/A"}: " +
                                     $"{item.title?.ToString() ?? "N/A"} " +
                                     $"(우선순위: {item.priority?.ToString() ?? "N/A"})");
                    }
                }

                // 3. 피드백
                sb.AppendLine("\n📝 분석:");
                sb.AppendLine(data.feedback?.ToString() ?? "피드백 내용이 없습니다.");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return $"⚠️ 피드백 포맷팅 오류: {ex.Message}\n\n원본 응답:\n{jsonFeedback}";
            }
        }

        private async Task<string> GetFeedbackFromGPTAsync(string jsonData, DateTime start, DateTime end)
        {
            try
            {
                string prompt = $@"
사용자의 {start:yyyy-MM-dd} ~ {end:yyyy-MM-dd} 일정 데이터를 분석하세요. 반드시 다음 구조로 JSON을 반환합니다:

{{
  ""completionRate"": ""n%"",
  ""incompleteItems"": [{{""date"": ""yyyy-MM-dd"", ""title"": ""..."", ""priority"": n}}],
  ""categories"": {{""카테고리명"": {{""count"": n, ""rate"": ""n%""}}}},
  ""weakestCategory"": ""..."",
  ""mostCommonCategory"": ""..."",
  ""focusWeek"": ""yyyy-MM월 n주차"",
  ""weekStart"": ""yyyy-MM-dd"",
  ""weekEnd"": ""yyyy-MM-dd"",
  ""weekComparison"": ""n주차는 다른 주보다 일정이 n% 많았습니다."",
  ""highPriority"": {{""rate"": ""n%"", ""incomplete"": [{{""title"": ""..."", ""priority"": n}}]}},
  ""feedback"": ""아래 내용을 포함한 서술형 문장으로 작성 :\n1. 주차/요일 분석 (숫자 필수)\n2. 취약 카테고리 진단\n3. 우선순위 평가와 개선 조언""
}}

데이터:
{jsonData}";

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", apiKey);

                    var body = new
                    {
                        model = "gpt-3.5-turbo",
                        messages = new[]
                        {
                            new { role = "system", content = "정확한 숫자와 날짜만 사용하세요. JSON 형식을 반드시 지켜주세요." },
                            new { role = "user", content = prompt }
                        },
                        temperature = 0.3
                    };

                    var response = await client.PostAsync(
                        "https://api.openai.com/v1/chat/completions",
                        new StringContent(
                            new JavaScriptSerializer().Serialize(body),
                            Encoding.UTF8,
                            "application/json"
                        )
                    );

                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(responseBody)["choices"][0]["message"]["content"].ToString();
                }
            }
            catch (Exception ex)
            {
                return $"API 오류: {ex.Message}";
            }
        }
    }
}