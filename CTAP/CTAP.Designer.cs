namespace Monitor
{
    partial class CTAP
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
            ShareMemory.CCShareData.GetSingleton().ShareMemory_DeleteDIOObject();
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTAP));
            this.baseStatusStrip = new System.Windows.Forms.StatusStrip();
            this.displayDateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.displayTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.baseTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ShutdownRadioButton = new System.Windows.Forms.RadioButton();
            this.AlarmlistRadioButton = new System.Windows.Forms.RadioButton();
            this.ParameterRadioButton = new System.Windows.Forms.RadioButton();
            this.AutoModeRadioButton = new System.Windows.Forms.RadioButton();
            this.PrintScreenRadioButton = new System.Windows.Forms.RadioButton();
            this.InstantChartRadioButton = new System.Windows.Forms.RadioButton();
            this.AlarmRadioButton = new System.Windows.Forms.RadioButton();
            this.HistoryChartRadioButton = new System.Windows.Forms.RadioButton();
            this.btnDecPanel = new System.Windows.Forms.Panel();
            this.baseStatusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseStatusStrip
            // 
            this.baseStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.baseStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayDateLabel,
            this.displayTimeLabel});
            resources.ApplyResources(this.baseStatusStrip, "baseStatusStrip");
            this.baseStatusStrip.Name = "baseStatusStrip";
            // 
            // displayDateLabel
            // 
            this.displayDateLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.displayDateLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.displayDateLabel.Name = "displayDateLabel";
            resources.ApplyResources(this.displayDateLabel, "displayDateLabel");
            // 
            // displayTimeLabel
            // 
            this.displayTimeLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.displayTimeLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.displayTimeLabel.Name = "displayTimeLabel";
            resources.ApplyResources(this.displayTimeLabel, "displayTimeLabel");
            // 
            // baseTimer
            // 
            this.baseTimer.Enabled = true;
            this.baseTimer.Interval = 1000;
            this.baseTimer.Tick += new System.EventHandler(this.baseTimer_Tick);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.viewPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // viewPanel
            // 
            resources.ApplyResources(this.viewPanel, "viewPanel");
            this.viewPanel.BackColor = System.Drawing.Color.White;
            this.viewPanel.Name = "viewPanel";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.ShutdownRadioButton);
            this.panel3.Controls.Add(this.AlarmlistRadioButton);
            this.panel3.Controls.Add(this.ParameterRadioButton);
            this.panel3.Controls.Add(this.AutoModeRadioButton);
            this.panel3.Controls.Add(this.PrintScreenRadioButton);
            this.panel3.Controls.Add(this.InstantChartRadioButton);
            this.panel3.Controls.Add(this.AlarmRadioButton);
            this.panel3.Controls.Add(this.HistoryChartRadioButton);
            this.panel3.Controls.Add(this.btnDecPanel);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // ShutdownRadioButton
            // 
            resources.ApplyResources(this.ShutdownRadioButton, "ShutdownRadioButton");
            this.ShutdownRadioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.ShutdownRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ShutdownRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.ShutdownRadioButton.Image = global::Monitor.Properties.Resources.Windows_Close_Program_icon;
            this.ShutdownRadioButton.Name = "ShutdownRadioButton";
            this.ShutdownRadioButton.TabStop = true;
            this.ShutdownRadioButton.UseVisualStyleBackColor = false;
            this.ShutdownRadioButton.Click += new System.EventHandler(this.Shutdown_Click);
            // 
            // AlarmlistRadioButton
            // 
            resources.ApplyResources(this.AlarmlistRadioButton, "AlarmlistRadioButton");
            this.AlarmlistRadioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.AlarmlistRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AlarmlistRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.AlarmlistRadioButton.Image = global::Monitor.Properties.Resources.Button_Warning_icon;
            this.AlarmlistRadioButton.Name = "AlarmlistRadioButton";
            this.AlarmlistRadioButton.TabStop = true;
            this.AlarmlistRadioButton.UseVisualStyleBackColor = false;
            // 
            // ParameterRadioButton
            // 
            resources.ApplyResources(this.ParameterRadioButton, "ParameterRadioButton");
            this.ParameterRadioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.ParameterRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ParameterRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.ParameterRadioButton.Name = "ParameterRadioButton";
            this.ParameterRadioButton.TabStop = true;
            this.ParameterRadioButton.UseVisualStyleBackColor = false;
            this.ParameterRadioButton.CheckedChanged += new System.EventHandler(this.navigatorBtn_CheckedChanged);
            // 
            // AutoModeRadioButton
            // 
            resources.ApplyResources(this.AutoModeRadioButton, "AutoModeRadioButton");
            this.AutoModeRadioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.AutoModeRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AutoModeRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.AutoModeRadioButton.Name = "AutoModeRadioButton";
            this.AutoModeRadioButton.TabStop = true;
            this.AutoModeRadioButton.UseVisualStyleBackColor = false;
            this.AutoModeRadioButton.CheckedChanged += new System.EventHandler(this.navigatorBtn_CheckedChanged);
            // 
            // PrintScreenRadioButton
            // 
            resources.ApplyResources(this.PrintScreenRadioButton, "PrintScreenRadioButton");
            this.PrintScreenRadioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.PrintScreenRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PrintScreenRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.PrintScreenRadioButton.Name = "PrintScreenRadioButton";
            this.PrintScreenRadioButton.TabStop = true;
            this.PrintScreenRadioButton.UseVisualStyleBackColor = false;
            this.PrintScreenRadioButton.CheckedChanged += new System.EventHandler(this.navigatorBtn_CheckedChanged);
            // 
            // InstantChartRadioButton
            // 
            resources.ApplyResources(this.InstantChartRadioButton, "InstantChartRadioButton");
            this.InstantChartRadioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.InstantChartRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.InstantChartRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.InstantChartRadioButton.Name = "InstantChartRadioButton";
            this.InstantChartRadioButton.TabStop = true;
            this.InstantChartRadioButton.UseVisualStyleBackColor = false;
            this.InstantChartRadioButton.CheckedChanged += new System.EventHandler(this.navigatorBtn_CheckedChanged);
            // 
            // AlarmRadioButton
            // 
            resources.ApplyResources(this.AlarmRadioButton, "AlarmRadioButton");
            this.AlarmRadioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.AlarmRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AlarmRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.AlarmRadioButton.Name = "AlarmRadioButton";
            this.AlarmRadioButton.TabStop = true;
            this.AlarmRadioButton.UseVisualStyleBackColor = false;
            this.AlarmRadioButton.CheckedChanged += new System.EventHandler(this.navigatorBtn_CheckedChanged);
            // 
            // HistoryChartRadioButton
            // 
            resources.ApplyResources(this.HistoryChartRadioButton, "HistoryChartRadioButton");
            this.HistoryChartRadioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.HistoryChartRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.HistoryChartRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.HistoryChartRadioButton.Name = "HistoryChartRadioButton";
            this.HistoryChartRadioButton.TabStop = true;
            this.HistoryChartRadioButton.UseVisualStyleBackColor = false;
            this.HistoryChartRadioButton.CheckedChanged += new System.EventHandler(this.navigatorBtn_CheckedChanged);
            // 
            // btnDecPanel
            // 
            this.btnDecPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(217)))));
            resources.ApplyResources(this.btnDecPanel, "btnDecPanel");
            this.btnDecPanel.Name = "btnDecPanel";
            // 
            // CTAP
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.baseStatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CTAP";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.baseStatusStrip.ResumeLayout(false);
            this.baseStatusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip baseStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel displayDateLabel;
        private System.Windows.Forms.ToolStripStatusLabel displayTimeLabel;
        private System.Windows.Forms.Timer baseTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton ShutdownRadioButton;
        private System.Windows.Forms.RadioButton AlarmlistRadioButton;
        private System.Windows.Forms.RadioButton ParameterRadioButton;
        private System.Windows.Forms.RadioButton AutoModeRadioButton;
        private System.Windows.Forms.RadioButton PrintScreenRadioButton;
        private System.Windows.Forms.RadioButton InstantChartRadioButton;
        private System.Windows.Forms.RadioButton AlarmRadioButton;
        private System.Windows.Forms.RadioButton HistoryChartRadioButton;
        private System.Windows.Forms.Panel btnDecPanel;
    }
}

