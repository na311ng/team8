namespace ToDoList
{
    partial class Chart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCompletionChart = new System.Windows.Forms.Button();
            this.btnCategoryChart = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1143, 675);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // btnCompletionChart
            // 
            this.btnCompletionChart.Location = new System.Drawing.Point(996, 150);
            this.btnCompletionChart.Name = "btnCompletionChart";
            this.btnCompletionChart.Size = new System.Drawing.Size(125, 49);
            this.btnCompletionChart.TabIndex = 1;
            this.btnCompletionChart.Text = "이번주";
            this.btnCompletionChart.UseVisualStyleBackColor = true;
            this.btnCompletionChart.Click += new System.EventHandler(this.btnCompletionChart_Click);
            // 
            // btnCategoryChart
            // 
            this.btnCategoryChart.Location = new System.Drawing.Point(996, 221);
            this.btnCategoryChart.Name = "btnCategoryChart";
            this.btnCategoryChart.Size = new System.Drawing.Size(125, 49);
            this.btnCategoryChart.TabIndex = 2;
            this.btnCategoryChart.Text = "카테고리";
            this.btnCategoryChart.UseVisualStyleBackColor = true;
            this.btnCategoryChart.Click += new System.EventHandler(this.btnCategoryChart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(996, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "우선순위";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 675);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCategoryChart);
            this.Controls.Add(this.btnCompletionChart);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Chart";
            this.Text = "Chart";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnCompletionChart;
        private System.Windows.Forms.Button btnCategoryChart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
    }
}