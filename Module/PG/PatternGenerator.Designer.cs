namespace ContrelModule
{
    partial class PatternGenerator
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

            m_objRS232Protocol.Destroy();
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatternGenerator));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PatternNameComboBox = new System.Windows.Forms.ComboBox();
            this.NowColorTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NextColorTextBox = new System.Windows.Forms.TextBox();
            this.ChangePatternButton = new System.Windows.Forms.Button();
            this.PreviousColorTextBox = new System.Windows.Forms.TextBox();
            this.NextPatternButton = new System.Windows.Forms.Button();
            this.PreviousPatternButton = new System.Windows.Forms.Button();
            this.LightGroupBox = new System.Windows.Forms.GroupBox();
            this.LightOffRadioButton = new System.Windows.Forms.RadioButton();
            this.LightOnRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UncontactRadioButton = new System.Windows.Forms.RadioButton();
            this.ContactRadioButton = new System.Windows.Forms.RadioButton();
            this.OnLineCheckBox = new System.Windows.Forms.CheckBox();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TestCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.LightGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PatternNameComboBox);
            this.groupBox1.Controls.Add(this.NowColorTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NextColorTextBox);
            this.groupBox1.Controls.Add(this.ChangePatternButton);
            this.groupBox1.Controls.Add(this.PreviousColorTextBox);
            this.groupBox1.Controls.Add(this.NextPatternButton);
            this.groupBox1.Controls.Add(this.PreviousPatternButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 204);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pattern";
            // 
            // PatternNameComboBox
            // 
            this.PatternNameComboBox.FormattingEnabled = true;
            this.PatternNameComboBox.Items.AddRange(new object[] {
            "Black"});
            this.PatternNameComboBox.Location = new System.Drawing.Point(153, 150);
            this.PatternNameComboBox.Name = "PatternNameComboBox";
            this.PatternNameComboBox.Size = new System.Drawing.Size(134, 20);
            this.PatternNameComboBox.TabIndex = 22;
            this.PatternNameComboBox.Text = "Black";
            // 
            // NowColorTextBox
            // 
            this.NowColorTextBox.Enabled = false;
            this.NowColorTextBox.Location = new System.Drawing.Point(86, 33);
            this.NowColorTextBox.Name = "NowColorTextBox";
            this.NowColorTextBox.Size = new System.Drawing.Size(133, 22);
            this.NowColorTextBox.TabIndex = 20;
            this.NowColorTextBox.Text = "Black";
            this.NowColorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "Now Color";
            // 
            // NextColorTextBox
            // 
            this.NextColorTextBox.Enabled = false;
            this.NextColorTextBox.Location = new System.Drawing.Point(155, 96);
            this.NextColorTextBox.Name = "NextColorTextBox";
            this.NextColorTextBox.Size = new System.Drawing.Size(133, 22);
            this.NextColorTextBox.TabIndex = 18;
            this.NextColorTextBox.Text = "Red";
            this.NextColorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChangePatternButton
            // 
            this.ChangePatternButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangePatternButton.Image = global::ContrelModule.Properties.Resources.Button_Forward_icon;
            this.ChangePatternButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangePatternButton.Location = new System.Drawing.Point(16, 144);
            this.ChangePatternButton.Name = "ChangePatternButton";
            this.ChangePatternButton.Size = new System.Drawing.Size(133, 31);
            this.ChangePatternButton.TabIndex = 17;
            this.ChangePatternButton.Text = "Change Pattern";
            this.ChangePatternButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChangePatternButton.UseVisualStyleBackColor = true;
            this.ChangePatternButton.Click += new System.EventHandler(this.ChangePattern_Click);
            // 
            // PreviousColorTextBox
            // 
            this.PreviousColorTextBox.Enabled = false;
            this.PreviousColorTextBox.Location = new System.Drawing.Point(16, 96);
            this.PreviousColorTextBox.Name = "PreviousColorTextBox";
            this.PreviousColorTextBox.Size = new System.Drawing.Size(133, 22);
            this.PreviousColorTextBox.TabIndex = 16;
            this.PreviousColorTextBox.Text = "White";
            this.PreviousColorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NextPatternButton
            // 
            this.NextPatternButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextPatternButton.Image = global::ContrelModule.Properties.Resources.Button_Next_icon;
            this.NextPatternButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NextPatternButton.Location = new System.Drawing.Point(155, 61);
            this.NextPatternButton.Name = "NextPatternButton";
            this.NextPatternButton.Size = new System.Drawing.Size(133, 31);
            this.NextPatternButton.TabIndex = 15;
            this.NextPatternButton.Text = "Next Pattern";
            this.NextPatternButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NextPatternButton.UseVisualStyleBackColor = true;
            this.NextPatternButton.Click += new System.EventHandler(this.ChangePattern_Click);
            // 
            // PreviousPatternButton
            // 
            this.PreviousPatternButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousPatternButton.Image = global::ContrelModule.Properties.Resources.Button_Previous_icon;
            this.PreviousPatternButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PreviousPatternButton.Location = new System.Drawing.Point(16, 61);
            this.PreviousPatternButton.Name = "PreviousPatternButton";
            this.PreviousPatternButton.Size = new System.Drawing.Size(133, 31);
            this.PreviousPatternButton.TabIndex = 14;
            this.PreviousPatternButton.Text = "Previous Pattern";
            this.PreviousPatternButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PreviousPatternButton.UseVisualStyleBackColor = true;
            this.PreviousPatternButton.Click += new System.EventHandler(this.ChangePattern_Click);
            // 
            // LightGroupBox
            // 
            this.LightGroupBox.Controls.Add(this.LightOffRadioButton);
            this.LightGroupBox.Controls.Add(this.LightOnRadioButton);
            this.LightGroupBox.Location = new System.Drawing.Point(158, 40);
            this.LightGroupBox.Name = "LightGroupBox";
            this.LightGroupBox.Size = new System.Drawing.Size(149, 99);
            this.LightGroupBox.TabIndex = 17;
            this.LightGroupBox.TabStop = false;
            // 
            // LightOffRadioButton
            // 
            this.LightOffRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.LightOffRadioButton.AutoCheck = false;
            this.LightOffRadioButton.Checked = true;
            this.LightOffRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.LightOffRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LightOffRadioButton.Image = global::ContrelModule.Properties.Resources.Button_Blank_Gray_icon;
            this.LightOffRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LightOffRadioButton.Location = new System.Drawing.Point(16, 62);
            this.LightOffRadioButton.Name = "LightOffRadioButton";
            this.LightOffRadioButton.Size = new System.Drawing.Size(116, 31);
            this.LightOffRadioButton.TabIndex = 13;
            this.LightOffRadioButton.TabStop = true;
            this.LightOffRadioButton.Text = "Light Off";
            this.LightOffRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LightOffRadioButton.UseVisualStyleBackColor = true;
            this.LightOffRadioButton.Click += new System.EventHandler(this.Light_Click);
            // 
            // LightOnRadioButton
            // 
            this.LightOnRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.LightOnRadioButton.AutoCheck = false;
            this.LightOnRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.LightOnRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LightOnRadioButton.Image = global::ContrelModule.Properties.Resources.Button_Blank_Blue_icon;
            this.LightOnRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LightOnRadioButton.Location = new System.Drawing.Point(16, 21);
            this.LightOnRadioButton.Name = "LightOnRadioButton";
            this.LightOnRadioButton.Size = new System.Drawing.Size(116, 31);
            this.LightOnRadioButton.TabIndex = 12;
            this.LightOnRadioButton.Text = "Light On";
            this.LightOnRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LightOnRadioButton.UseVisualStyleBackColor = true;
            this.LightOnRadioButton.Click += new System.EventHandler(this.Light_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UncontactRadioButton);
            this.groupBox2.Controls.Add(this.ContactRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 99);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // UncontactRadioButton
            // 
            this.UncontactRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.UncontactRadioButton.AutoCheck = false;
            this.UncontactRadioButton.Checked = true;
            this.UncontactRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.UncontactRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UncontactRadioButton.Image = global::ContrelModule.Properties.Resources.Button_Blank_Red_icon;
            this.UncontactRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UncontactRadioButton.Location = new System.Drawing.Point(16, 62);
            this.UncontactRadioButton.Name = "UncontactRadioButton";
            this.UncontactRadioButton.Size = new System.Drawing.Size(116, 31);
            this.UncontactRadioButton.TabIndex = 13;
            this.UncontactRadioButton.TabStop = true;
            this.UncontactRadioButton.Text = "Uncontact";
            this.UncontactRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UncontactRadioButton.UseVisualStyleBackColor = true;
            this.UncontactRadioButton.Click += new System.EventHandler(this.Contact_Click);
            // 
            // ContactRadioButton
            // 
            this.ContactRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.ContactRadioButton.AutoCheck = false;
            this.ContactRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ContactRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContactRadioButton.Image = global::ContrelModule.Properties.Resources.Button_Blank_Green_icon;
            this.ContactRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ContactRadioButton.Location = new System.Drawing.Point(16, 21);
            this.ContactRadioButton.Name = "ContactRadioButton";
            this.ContactRadioButton.Size = new System.Drawing.Size(116, 31);
            this.ContactRadioButton.TabIndex = 12;
            this.ContactRadioButton.Text = "Contact";
            this.ContactRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ContactRadioButton.UseVisualStyleBackColor = true;
            this.ContactRadioButton.Click += new System.EventHandler(this.Contact_Click);
            // 
            // OnLineCheckBox
            // 
            this.OnLineCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.OnLineCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.OnLineCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OnLineCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OnLineCheckBox.ImageIndex = 0;
            this.OnLineCheckBox.ImageList = this.ImageList;
            this.OnLineCheckBox.Location = new System.Drawing.Point(19, 3);
            this.OnLineCheckBox.Name = "OnLineCheckBox";
            this.OnLineCheckBox.Size = new System.Drawing.Size(116, 31);
            this.OnLineCheckBox.TabIndex = 19;
            this.OnLineCheckBox.Text = "Off Line";
            this.OnLineCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OnLineCheckBox.UseVisualStyleBackColor = true;
            this.OnLineCheckBox.Click += new System.EventHandler(this.OnLineCheckBox_Click);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Button-Blank-Red-icon.png");
            this.ImageList.Images.SetKeyName(1, "Button-Blank-Green-icon.png");
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(313, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(200, 346);
            this.richTextBox1.TabIndex = 20;
            this.richTextBox1.Text = "";
            // 
            // TestCheckBox
            // 
            this.TestCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.TestCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.TestCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TestCheckBox.ImageIndex = 0;
            this.TestCheckBox.ImageList = this.ImageList;
            this.TestCheckBox.Location = new System.Drawing.Point(175, 3);
            this.TestCheckBox.Name = "TestCheckBox";
            this.TestCheckBox.Size = new System.Drawing.Size(116, 31);
            this.TestCheckBox.TabIndex = 21;
            this.TestCheckBox.Text = "Start Test";
            this.TestCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TestCheckBox.UseVisualStyleBackColor = true;
            this.TestCheckBox.CheckedChanged += new System.EventHandler(this.TestCheckBox_CheckedChanged);
            // 
            // PatternGenerator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TestCheckBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.OnLineCheckBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LightGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "PatternGenerator";
            this.Size = new System.Drawing.Size(516, 352);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.LightGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button NextPatternButton;
        private System.Windows.Forms.Button PreviousPatternButton;
        private System.Windows.Forms.GroupBox LightGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton UncontactRadioButton;
        private System.Windows.Forms.RadioButton ContactRadioButton;
        private System.Windows.Forms.Button ChangePatternButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PatternNameComboBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ImageList ImageList;
        public System.Windows.Forms.TextBox PreviousColorTextBox;
        public System.Windows.Forms.TextBox NextColorTextBox;
        public System.Windows.Forms.TextBox NowColorTextBox;
        public System.Windows.Forms.RadioButton LightOffRadioButton;
        public System.Windows.Forms.RadioButton LightOnRadioButton;
        public System.Windows.Forms.CheckBox TestCheckBox;
        public System.Windows.Forms.CheckBox OnLineCheckBox;
    }
}
