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
            this.selectedDate = selectedDate;
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

            Series series = new Series("Completion Rate");
            series.ChartType = SeriesChartType.Column; // Bar → horizontal, Column → vertical
            series.Color = Color.LightBlue;
            series.BorderWidth = 2;
            chart1.Series.Add(series);
        }

        private void CalculateCompletionRates()
        {
            // 기준일로부터 이번 주 월요일 계산
            int diff = (7 + (selectedDate.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime weekStart = selectedDate.AddDays(-1 * diff); // 월요일

            Series series = chart1.Series["Completion Rate"];

            for (int i = 0; i < 7; i++)
            {
                DateTime day = weekStart.AddDays(i);
                string label = $"{day:ddd}\n({day:MM/dd})"; // e.g., Mon\n(05/06)

                int total = 0;
                int completed = 0;

                foreach (DataRow row in todoList.Rows)
                {
                    if (row.RowState == DataRowState.Deleted) continue;

                    DateTime start = Convert.ToDateTime(row["Start"]);
                    DateTime end = Convert.ToDateTime(row["End"]);

                    // 이 날짜에 해당하는 일정만 집계
                    if (day >= start && day <= end)
                    {
                        total++;
                        if (todoList.Columns.Contains("IsCompleted") &&
                            row["IsCompleted"] != DBNull.Value &&
                            Convert.ToBoolean(row["IsCompleted"]))
                        {
                            completed++;
                        }
                    }
                }

                double percent = (total == 0) ? 0 : (completed * 100.0 / total);
                series.Points.AddXY(label, percent);
            }
        }
    }
}
