namespace ToDoList
{
    partial class CategoryForm
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
            this.chkWork = new System.Windows.Forms.CheckBox();
            this.chkStudy = new System.Windows.Forms.CheckBox();
            this.chkHealth = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkWork
            // 
            this.chkWork.AutoSize = true;
            this.chkWork.Location = new System.Drawing.Point(27, 48);
            this.chkWork.Name = "chkWork";
            this.chkWork.Size = new System.Drawing.Size(75, 22);
            this.chkWork.TabIndex = 0;
            this.chkWork.Text = "Work";
            this.chkWork.UseVisualStyleBackColor = true;
            // 
            // chkStudy
            // 
            this.chkStudy.AutoSize = true;
            this.chkStudy.Location = new System.Drawing.Point(27, 96);
            this.chkStudy.Name = "chkStudy";
            this.chkStudy.Size = new System.Drawing.Size(80, 22);
            this.chkStudy.TabIndex = 1;
            this.chkStudy.Text = "Study";
            this.chkStudy.UseVisualStyleBackColor = true;
            // 
            // chkHealth
            // 
            this.chkHealth.AutoSize = true;
            this.chkHealth.Location = new System.Drawing.Point(27, 145);
            this.chkHealth.Name = "chkHealth";
            this.chkHealth.Size = new System.Drawing.Size(83, 22);
            this.chkHealth.TabIndex = 2;
            this.chkHealth.Text = "Health";
            this.chkHealth.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(27, 197);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 65);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(180, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 65);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 320);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkHealth);
            this.Controls.Add(this.chkStudy);
            this.Controls.Add(this.chkWork);
            this.Name = "CategoryForm";
            this.Text = "CategoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkWork;
        private System.Windows.Forms.CheckBox chkStudy;
        private System.Windows.Forms.CheckBox chkHealth;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}