namespace ContrelModule
{
    partial class Lens
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Lens4RadioButton = new System.Windows.Forms.RadioButton();
            this.Lens3RadioButton = new System.Windows.Forms.RadioButton();
            this.Lens2RadioButton = new System.Windows.Forms.RadioButton();
            this.Lens1RadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Lens4RadioButton);
            this.groupBox3.Controls.Add(this.Lens3RadioButton);
            this.groupBox3.Controls.Add(this.Lens2RadioButton);
            this.groupBox3.Controls.Add(this.Lens1RadioButton);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 119);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lens";
            // 
            // Lens4RadioButton
            // 
            this.Lens4RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.Lens4RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lens4RadioButton.Location = new System.Drawing.Point(16, 90);
            this.Lens4RadioButton.Name = "Lens4RadioButton";
            this.Lens4RadioButton.Size = new System.Drawing.Size(92, 23);
            this.Lens4RadioButton.TabIndex = 15;
            this.Lens4RadioButton.Text = "50X";
            this.Lens4RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lens4RadioButton.UseVisualStyleBackColor = true;
            this.Lens4RadioButton.Click += new System.EventHandler(this.LensRadioButton_Click);
            // 
            // Lens3RadioButton
            // 
            this.Lens3RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.Lens3RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lens3RadioButton.Location = new System.Drawing.Point(16, 67);
            this.Lens3RadioButton.Name = "Lens3RadioButton";
            this.Lens3RadioButton.Size = new System.Drawing.Size(92, 23);
            this.Lens3RadioButton.TabIndex = 14;
            this.Lens3RadioButton.Text = "20X";
            this.Lens3RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lens3RadioButton.UseVisualStyleBackColor = true;
            this.Lens3RadioButton.Click += new System.EventHandler(this.LensRadioButton_Click);
            // 
            // Lens2RadioButton
            // 
            this.Lens2RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.Lens2RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lens2RadioButton.Location = new System.Drawing.Point(16, 44);
            this.Lens2RadioButton.Name = "Lens2RadioButton";
            this.Lens2RadioButton.Size = new System.Drawing.Size(92, 23);
            this.Lens2RadioButton.TabIndex = 13;
            this.Lens2RadioButton.Text = "10X";
            this.Lens2RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lens2RadioButton.UseVisualStyleBackColor = true;
            this.Lens2RadioButton.Click += new System.EventHandler(this.LensRadioButton_Click);
            // 
            // Lens1RadioButton
            // 
            this.Lens1RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.Lens1RadioButton.Checked = true;
            this.Lens1RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lens1RadioButton.Location = new System.Drawing.Point(16, 21);
            this.Lens1RadioButton.Name = "Lens1RadioButton";
            this.Lens1RadioButton.Size = new System.Drawing.Size(92, 23);
            this.Lens1RadioButton.TabIndex = 12;
            this.Lens1RadioButton.TabStop = true;
            this.Lens1RadioButton.Text = "2X";
            this.Lens1RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lens1RadioButton.UseVisualStyleBackColor = true;
            this.Lens1RadioButton.Click += new System.EventHandler(this.LensRadioButton_Click);
            // 
            // Lens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "Lens";
            this.Size = new System.Drawing.Size(124, 119);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.RadioButton Lens4RadioButton;
        public System.Windows.Forms.RadioButton Lens3RadioButton;
        public System.Windows.Forms.RadioButton Lens2RadioButton;
        public System.Windows.Forms.RadioButton Lens1RadioButton;
    }
}
