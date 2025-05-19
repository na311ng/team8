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
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.toDoListView = new System.Windows.Forms.DataGridView();
            this.timerSliding = new System.Windows.Forms.Timer(this.components);
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.panel = new System.Windows.Forms.Panel();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnApi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(408, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1065, 148);
            this.label1.TabIndex = 0;
            this.label1.Text = "To Do List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(408, 187);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(1069, 35);
            this.titleTextBox.TabIndex = 1;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(408, 256);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(1069, 35);
            this.descriptionTextBox.TabIndex = 2;
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(408, 224);
            this.Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(1067, 24);
            this.Description.TabIndex = 3;
            this.Description.Text = "Description:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(408, 157);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1067, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Title:";
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(408, 296);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(334, 64);
            this.editButton.TabIndex = 6;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(749, 296);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(363, 64);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1117, 296);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(363, 64);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toDoListView
            // 
            this.toDoListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.toDoListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toDoListView.Location = new System.Drawing.Point(408, 368);
            this.toDoListView.Margin = new System.Windows.Forms.Padding(4);
            this.toDoListView.Name = "toDoListView";
            this.toDoListView.RowHeadersWidth = 82;
            this.toDoListView.RowTemplate.Height = 37;
            this.toDoListView.Size = new System.Drawing.Size(1071, 576);
            this.toDoListView.TabIndex = 9;
            this.toDoListView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.toDoListView_CellBeginEdit);
            // 
            // timerSliding
            // 
            this.timerSliding.Interval = 10;
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(9, 8);
            this.calendar.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
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
            this.panel.Margin = new System.Windows.Forms.Padding(4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(402, 1048);
            this.panel.TabIndex = 10;
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(412, 107);
            this.btnAddSchedule.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(139, 45);
            this.btnAddSchedule.TabIndex = 11;
            this.btnAddSchedule.Text = "일정추가";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(807, 107);
            this.btnChart.Margin = new System.Windows.Forms.Padding(5);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(139, 45);
            this.btnChart.TabIndex = 12;
            this.btnChart.Text = "차트";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnApi
            // 
            this.btnApi.Location = new System.Drawing.Point(1257, 107);
            this.btnApi.Margin = new System.Windows.Forms.Padding(5);
            this.btnApi.Name = "btnApi";
            this.btnApi.Size = new System.Drawing.Size(139, 45);
            this.btnApi.TabIndex = 13;
            this.btnApi.Text = "Api";
            this.btnApi.UseVisualStyleBackColor = true;
            this.btnApi.Click += new System.EventHandler(this.btnApi_Click);
            // 
            // ToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 1048);
            this.Controls.Add(this.btnApi);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnAddSchedule);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toDoListView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ToDoList";
            this.Text = "To Do List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToDoList_FormClosed);
            this.Load += new System.EventHandler(this.ToDoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView toDoListView;
        private System.Windows.Forms.Timer timerSliding;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnApi;
    }
}

