namespace ContrelModule
{
    partial class ZMotionControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MoveFastRadioButton = new System.Windows.Forms.RadioButton();
            this.MoveSlowRadioButton = new System.Windows.Forms.RadioButton();
            this.AFButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MoveFastRadioButton);
            this.groupBox2.Controls.Add(this.MoveSlowRadioButton);
            this.groupBox2.Controls.Add(this.AFButton);
            this.groupBox2.Controls.Add(this.MoveDownButton);
            this.groupBox2.Controls.Add(this.MoveUpButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 72);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Z Motion Control";
            // 
            // MoveFastRadioButton
            // 
            this.MoveFastRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.MoveFastRadioButton.Checked = true;
            this.MoveFastRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveFastRadioButton.Location = new System.Drawing.Point(6, 21);
            this.MoveFastRadioButton.Name = "MoveFastRadioButton";
            this.MoveFastRadioButton.Size = new System.Drawing.Size(60, 23);
            this.MoveFastRadioButton.TabIndex = 15;
            this.MoveFastRadioButton.TabStop = true;
            this.MoveFastRadioButton.Text = "Fast";
            this.MoveFastRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MoveFastRadioButton.UseVisualStyleBackColor = true;
            this.MoveFastRadioButton.CheckedChanged += new System.EventHandler(this.MoveFastRadioButton_CheckedChanged);
            // 
            // MoveSlowRadioButton
            // 
            this.MoveSlowRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.MoveSlowRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveSlowRadioButton.Location = new System.Drawing.Point(6, 43);
            this.MoveSlowRadioButton.Name = "MoveSlowRadioButton";
            this.MoveSlowRadioButton.Size = new System.Drawing.Size(60, 23);
            this.MoveSlowRadioButton.TabIndex = 14;
            this.MoveSlowRadioButton.Text = "Slow";
            this.MoveSlowRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MoveSlowRadioButton.UseVisualStyleBackColor = true;
            this.MoveSlowRadioButton.CheckedChanged += new System.EventHandler(this.MoveSlowRadioButton_CheckedChanged);
            // 
            // AFButton
            // 
            this.AFButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AFButton.Location = new System.Drawing.Point(196, 21);
            this.AFButton.Name = "AFButton";
            this.AFButton.Size = new System.Drawing.Size(60, 45);
            this.AFButton.TabIndex = 12;
            this.AFButton.Text = "AF";
            this.AFButton.UseVisualStyleBackColor = true;
            this.AFButton.Click += new System.EventHandler(this.AFButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveDownButton.Image = global::ContrelModule.Properties.Resources.Button_Download_icon;
            this.MoveDownButton.Location = new System.Drawing.Point(134, 21);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(60, 45);
            this.MoveDownButton.TabIndex = 11;
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveUpButton.Image = global::ContrelModule.Properties.Resources.Button_Upload_icon;
            this.MoveUpButton.Location = new System.Drawing.Point(72, 21);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(60, 45);
            this.MoveUpButton.TabIndex = 10;
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // ZMotionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "ZMotionControl";
            this.Size = new System.Drawing.Size(262, 72);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton MoveFastRadioButton;
        private System.Windows.Forms.RadioButton MoveSlowRadioButton;
        private System.Windows.Forms.Button AFButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveUpButton;
    }
}
