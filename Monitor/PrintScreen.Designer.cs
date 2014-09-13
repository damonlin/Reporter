namespace Parameter
{
    partial class ParameterPanelPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InlineStatusCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StopRadioButton = new System.Windows.Forms.RadioButton();
            this.ManualRadioButton = new System.Windows.Forms.RadioButton();
            this.AutoRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InlineStatusCheckBox);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(534, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initial";
            // 
            // InlineStatusCheckBox
            // 
            this.InlineStatusCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.InlineStatusCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.InlineStatusCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InlineStatusCheckBox.Location = new System.Drawing.Point(47, 64);
            this.InlineStatusCheckBox.Name = "InlineStatusCheckBox";
            this.InlineStatusCheckBox.Size = new System.Drawing.Size(106, 33);
            this.InlineStatusCheckBox.TabIndex = 1;
            this.InlineStatusCheckBox.Text = "LUL Offline";
            this.InlineStatusCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InlineStatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(47, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 33);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Initialize";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StopRadioButton);
            this.groupBox2.Controls.Add(this.ManualRadioButton);
            this.groupBox2.Controls.Add(this.AutoRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(534, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 159);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // StopRadioButton
            // 
            this.StopRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.StopRadioButton.Checked = true;
            this.StopRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.StopRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopRadioButton.Location = new System.Drawing.Point(47, 102);
            this.StopRadioButton.Name = "StopRadioButton";
            this.StopRadioButton.Size = new System.Drawing.Size(106, 33);
            this.StopRadioButton.TabIndex = 2;
            this.StopRadioButton.TabStop = true;
            this.StopRadioButton.Text = "STOP";
            this.StopRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StopRadioButton.UseVisualStyleBackColor = true;
         
            // 
            // ManualRadioButton
            // 
            this.ManualRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.ManualRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ManualRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManualRadioButton.Location = new System.Drawing.Point(47, 63);
            this.ManualRadioButton.Name = "ManualRadioButton";
            this.ManualRadioButton.Size = new System.Drawing.Size(106, 33);
            this.ManualRadioButton.TabIndex = 1;
            this.ManualRadioButton.Text = "Manual";
            this.ManualRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ManualRadioButton.UseVisualStyleBackColor = true;
            // 
            // AutoRadioButton
            // 
            this.AutoRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.AutoRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.AutoRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutoRadioButton.Location = new System.Drawing.Point(47, 24);
            this.AutoRadioButton.Name = "AutoRadioButton";
            this.AutoRadioButton.Size = new System.Drawing.Size(106, 33);
            this.AutoRadioButton.TabIndex = 0;
            this.AutoRadioButton.Text = "Auto";
            this.AutoRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AutoRadioButton.UseVisualStyleBackColor = true;
            // 
            // OperatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OperatePanel";
            this.Size = new System.Drawing.Size(1268, 649);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox InlineStatusCheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton AutoRadioButton;
        private System.Windows.Forms.RadioButton StopRadioButton;
        private System.Windows.Forms.RadioButton ManualRadioButton;
    }
}
