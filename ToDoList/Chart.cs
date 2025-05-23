using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ToDoList
{
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
            CalculateCompletionRates();
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
                series.Points.AddXY(label, percent);
            }
        }
    }
}
