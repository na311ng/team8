namespace ToDoList
{
    partial class ToDoList
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.toDoListView = new System.Windows.Forms.DataGridView();
            this.timerSliding = new System.Windows.Forms.Timer(this.components);
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.panel = new System.Windows.Forms.Panel();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnApi = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(350, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(819, 111);
            this.label1.TabIndex = 0;
            this.label1.Text = "To Do List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toDoListView
            // 
            this.toDoListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.toDoListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toDoListView.Location = new System.Drawing.Point(379, 172);
            this.toDoListView.Name = "toDoListView";
            this.toDoListView.RowHeadersWidth = 82;
            this.toDoListView.RowTemplate.Height = 37;
            this.toDoListView.Size = new System.Drawing.Size(771, 380);
            this.toDoListView.TabIndex = 9;
            this.toDoListView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.toDoListView_CellDoubleClick);
            this.toDoListView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.toDoListView_CellFormatting);
            this.toDoListView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.toDoListView_CellValueChanged);
            // 
            // timerSliding
            // 
            this.timerSliding.Interval = 10;
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(20, 20);
            this.calendar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.calendar);
            this.panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(344, 786);
            this.panel.TabIndex = 10;
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(379, 600);
            this.btnAddSchedule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(163, 98);
            this.btnAddSchedule.TabIndex = 11;
            this.btnAddSchedule.Text = "일정 추가";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(677, 600);
            this.btnChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(163, 98);
            this.btnChart.TabIndex = 12;
            this.btnChart.Text = "차트";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnApi
            // 
            this.btnApi.Location = new System.Drawing.Point(987, 600);
            this.btnApi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnApi.Name = "btnApi";
            this.btnApi.Size = new System.Drawing.Size(163, 98);
            this.btnApi.TabIndex = 13;
            this.btnApi.Text = "Api";
            this.btnApi.UseVisualStyleBackColor = true;
            this.btnApi.Click += new System.EventHandler(this.btnApi_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(1043, 114);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(107, 34);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "일정 삭제";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // ToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 786);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.btnApi);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnAddSchedule);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toDoListView);
            this.Controls.Add(this.label1);
            this.Name = "ToDoList";
            this.Text = "To Do List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToDoList_FormClosed);
            this.Load += new System.EventHandler(this.ToDoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView toDoListView;
        private System.Windows.Forms.Timer timerSliding;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnApi;
        private System.Windows.Forms.Button deleteButton;
    }
}

