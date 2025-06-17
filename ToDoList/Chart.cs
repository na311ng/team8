using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;

namespace ToDoList
{
    public enum ChartPeriod { All, Week, Month }
    public partial class Chart : Form
    {
        
        private DataTable todoList;
        private DateTime selectedDate;

        public Chart(DataTable todoList, DateTime selectedDate)
        {
            InitializeComponent();
            this.todoList = todoList;
            this.selectedDate = selectedDate.Date;
            this.Load += Chart_Load;
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            SetupChart();
            chart1.Series.Clear();      
            chart1.Titles.Clear();
        }

        private void SetupChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();

            chart1.Titles.Add("Weekly Task Completion Rate");
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisY.Title = "Completion (%)";
            chartArea.AxisX.Title = "Day";
            chartArea.AxisY.Maximum = 100;
            chartArea.AxisY.Minimum = 0;
            chart1.ChartAreas.Add(chartArea);

            Series series = new Series("Completion Rate")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.LightBlue,
                BorderWidth = 2
            };
            chart1.Series.Add(series);
        }

        private void CalculateCompletionRates()
        {
            int diff = (7 + (selectedDate.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime weekStart = selectedDate.AddDays(-diff);

            Series series = chart1.Series["Completion Rate"];
            series.Points.Clear();

            for (int i = 0; i < 7; i++)
            {
                DateTime day = weekStart.AddDays(i);
                string label = $"{day:ddd}\n({day:MM/dd})";

                int total = 0;
                int completed = 0;

                foreach (DataRow row in todoList.Rows)
                {
                    if (row.RowState == DataRowState.Deleted) continue;

                    DateTime start = Convert.ToDateTime(row["Start"]);
                    DateTime end = Convert.ToDateTime(row["End"]);

                    if (day >= start && day <= end)
                    {
                        total++;

                        if (todoList.Columns.Contains("IsCompleted") &&
                            row["IsCompleted"] != DBNull.Value &&
                            Convert.ToBoolean(row["IsCompleted"]))
                        {
                            var completedDate = row["CompletedDate"] as DateTime?;

                            // 완료한 날짜가 해당 날짜와 정확히 일치할 때만 완료로 인정
                            if (completedDate != null && completedDate.Value.Date == day.Date)
                            {
                                completed++;
                            }
                        }
                    }
                }

                double percent = total == 0 ? 0 : (double)completed / total * 100;
                int idx = series.Points.AddXY(label, percent);
                series.Points[idx].ToolTip = $"{label}: {percent:F1}% ({completed}/{total})";
            }
        }
        private void ShowPriorityCompletionChart(ChartPeriod period)
        {
            
            DateTime today = DateTime.Today;
            DateTime start = today, end = today;
            if (period == ChartPeriod.Week)
                start = today.AddDays(-6);
            else if (period == ChartPeriod.Month)
                start = new DateTime(today.Year, today.Month, 1);

            var srcRows = todoList.AsEnumerable()
                .Where(row => row.RowState != DataRowState.Deleted);

            if (period != ChartPeriod.All)
                srcRows = srcRows.Where(row =>
                    row.Field<DateTime>("Start") <= end &&
                    row.Field<DateTime>("End") >= start);

            var priorityGroups = srcRows
                .GroupBy(row => row.Field<int>("Priority"))
                .OrderBy(g => g.Key);

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("우선순위별 달성률(%)");

            Series series = new Series("달성률")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Orange
            };

            foreach (var grp in priorityGroups)
            {
                int total = grp.Count();
                int completed = grp.Count(row => row.Field<bool>("IsCompleted"));
                double percent = (total == 0) ? 0 : completed * 100.0 / total;
                int idx = series.Points.AddXY(grp.Key.ToString(), percent);
                series.Points[idx].ToolTip = $"Priority {grp.Key.ToString()}: {percent:F1}% ({completed}/{total})";
            }

            chart1.Series.Add(series);
        }
        private void btnCompletionChart_Click(object sender, EventArgs e)
        {
            SetupChart();
            CalculateCompletionRates();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new PeriodSelectForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ChartPeriod period = ChartPeriod.All;
                    string selected = form.SelectedPeriod;
                    if (selected == "이번주") period = ChartPeriod.Week;
                    else if (selected == "이번달") period = ChartPeriod.Month;

                    ShowPriorityCompletionChart(period);
                }
            }
        }

        private void btnCategoryChart_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add("Category-wise Completion Rate");

            chart1.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("CategoryArea");
            chartArea.AxisY.Title = "Completion (%)";
            chartArea.AxisX.Title = "Category";
            chartArea.AxisY.Maximum = 100;
            chartArea.AxisY.Minimum = 0;
            chart1.ChartAreas.Add(chartArea);

            Series series = new Series("Completion Rate")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.MediumSeaGreen
            };

            var validRows = todoList.AsEnumerable()
                .Where(row => row.RowState != DataRowState.Deleted &&
                              !string.IsNullOrWhiteSpace(row.Field<string>("Category")));

            var categoryGroups = validRows
                .GroupBy(row => row.Field<string>("Category"));

            foreach (var group in categoryGroups)
            {
                string category = group.Key;
                int total = group.Count();
                int completed = group.Count(row =>
                    row.Field<bool>("IsCompleted") &&
                    row["CompletedDate"] != DBNull.Value
                );

                double percent = (total == 0) ? 0 : completed * 100.0 / total;
                int pointIndex = series.Points.AddXY(category, percent);
                DataPoint point = series.Points[pointIndex];
                point.ToolTip = $"{category}: {percent:F1}% ({completed}/{total})";  // 툴팁 설정
            }

            chart1.Series.Add(series);
        }

        private ToolTip tt = new ToolTip();
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var result = chart1.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var point = chart1.Series[0].Points[result.PointIndex];
                string toolTipText = point.ToolTip;

                tt.Show(toolTipText, chart1, e.Location.X + 15, e.Location.Y - 15, 2000);
            }
            else
            {
                tt.Hide(chart1);
            }
        }
    }
}
