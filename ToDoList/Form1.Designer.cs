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
            this.toDoListView = new System.Windows.Forms.DataGridView();
            this.timerSliding = new System.Windows.Forms.Timer(this.components);
            this.btnAddSchedule1 = new MaterialSkin.Controls.MaterialButton();
            this.btnChart1 = new MaterialSkin.Controls.MaterialButton();
            this.btnApi1 = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.panelCalendar = new System.Windows.Forms.Panel();
            this.btnShop = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).BeginInit();
            this.panelCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toDoListView
            // 
            this.toDoListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.toDoListView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.toDoListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toDoListView.Location = new System.Drawing.Point(26, 114);
            this.toDoListView.Name = "toDoListView";
            this.toDoListView.RowHeadersWidth = 82;
            this.toDoListView.RowTemplate.Height = 37;
            this.toDoListView.Size = new System.Drawing.Size(1071, 612);
            this.toDoListView.TabIndex = 9;
            this.toDoListView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.toDoListView_CellContentClick);
            this.toDoListView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.toDoListView_CellDoubleClick);
            this.toDoListView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.toDoListView_CellFormatting);
            this.toDoListView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.toDoListView_CellValueChanged);
            // 
            // timerSliding
            // 
            this.timerSliding.Interval = 10;
            // 
            // btnAddSchedule1
            // 
            this.btnAddSchedule1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddSchedule1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddSchedule1.Depth = 0;
            this.btnAddSchedule1.HighEmphasis = true;
            this.btnAddSchedule1.Icon = null;
            this.btnAddSchedule1.Location = new System.Drawing.Point(1127, 382);
            this.btnAddSchedule1.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnAddSchedule1.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddSchedule1.Name = "btnAddSchedule1";
            this.btnAddSchedule1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddSchedule1.Size = new System.Drawing.Size(89, 36);
            this.btnAddSchedule1.TabIndex = 15;
            this.btnAddSchedule1.Text = "일정 추가";
            this.btnAddSchedule1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddSchedule1.UseAccentColor = false;
            this.btnAddSchedule1.UseVisualStyleBackColor = true;
            this.btnAddSchedule1.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // btnChart1
            // 
            this.btnChart1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChart1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnChart1.Depth = 0;
            this.btnChart1.HighEmphasis = true;
            this.btnChart1.Icon = null;
            this.btnChart1.Location = new System.Drawing.Point(1127, 500);
            this.btnChart1.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnChart1.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChart1.Name = "btnChart1";
            this.btnChart1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnChart1.Size = new System.Drawing.Size(89, 36);
            this.btnChart1.TabIndex = 1;
            this.btnChart1.Text = "일정 차트";
            this.btnChart1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnChart1.UseAccentColor = false;
            this.btnChart1.UseVisualStyleBackColor = true;
            this.btnChart1.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnApi1
            // 
            this.btnApi1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApi1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnApi1.Depth = 0;
            this.btnApi1.HighEmphasis = true;
            this.btnApi1.Icon = null;
            this.btnApi1.Location = new System.Drawing.Point(1314, 500);
            this.btnApi1.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnApi1.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnApi1.Name = "btnApi1";
            this.btnApi1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnApi1.Size = new System.Drawing.Size(64, 36);
            this.btnApi1.TabIndex = 2;
            this.btnApi1.Text = "API";
            this.btnApi1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnApi1.UseAccentColor = false;
            this.btnApi1.UseVisualStyleBackColor = true;
            this.btnApi1.Click += new System.EventHandler(this.btnApi_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDelete.Depth = 0;
            this.btnDelete.HighEmphasis = true;
            this.btnDelete.Icon = null;
            this.btnDelete.Location = new System.Drawing.Point(1291, 382);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDelete.Size = new System.Drawing.Size(89, 36);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "일정 삭제";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDelete.UseAccentColor = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(0, 0);
            this.calendar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // panelCalendar
            // 
            this.panelCalendar.Controls.Add(this.calendar);
            this.panelCalendar.Location = new System.Drawing.Point(1124, 114);
            this.panelCalendar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCalendar.Name = "panelCalendar";
            this.panelCalendar.Size = new System.Drawing.Size(314, 243);
            this.panelCalendar.TabIndex = 18;
            // 
            // btnShop
            // 
            this.btnShop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShop.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnShop.Depth = 0;
            this.btnShop.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnShop.HighEmphasis = true;
            this.btnShop.Icon = null;
            this.btnShop.Location = new System.Drawing.Point(1210, 614);
            this.btnShop.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnShop.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShop.Name = "btnShop";
            this.btnShop.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnShop.Size = new System.Drawing.Size(105, 36);
            this.btnShop.TabIndex = 1;
            this.btnShop.Text = "포인트 상점";
            this.btnShop.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnShop.UseAccentColor = false;
            this.btnShop.UseVisualStyleBackColor = true;
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // ToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 770);
            this.Controls.Add(this.btnShop);
            this.Controls.Add(this.panelCalendar);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnChart1);
            this.Controls.Add(this.btnApi1);
            this.Controls.Add(this.btnAddSchedule1);
            this.Controls.Add(this.toDoListView);
            this.Name = "ToDoList";
            this.Padding = new System.Windows.Forms.Padding(4, 96, 4, 4);
            this.Text = "To Do List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToDoList_FormClosed);
            this.Load += new System.EventHandler(this.ToDoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).EndInit();
            this.panelCalendar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView toDoListView;
        private System.Windows.Forms.Timer timerSliding;
        private MaterialSkin.Controls.MaterialButton btnAddSchedule1;
        private MaterialSkin.Controls.MaterialButton btnChart1;
        private MaterialSkin.Controls.MaterialButton btnApi1;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Panel panelCalendar;
        private MaterialSkin.Controls.MaterialButton btnShop;
    }
}

