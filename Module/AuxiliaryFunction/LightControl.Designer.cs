namespace ContrelModule
{
    partial class LightControl
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

            /*if (m_LightRs232Port.IsOpen)
            {
                m_LightRs232Port.Close();
            }*/

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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Light2NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Light1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Light2TrackBar = new System.Windows.Forms.TrackBar();
            this.Light1TrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Light2NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light1NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light2TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light1TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Light2NumericUpDown);
            this.groupBox4.Controls.Add(this.Light1NumericUpDown);
            this.groupBox4.Controls.Add(this.Light2TrackBar);
            this.groupBox4.Controls.Add(this.Light1TrackBar);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(132, 163);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Light Control";
            // 
            // Light2NumericUpDown
            // 
            this.Light2NumericUpDown.Location = new System.Drawing.Point(74, 131);
            this.Light2NumericUpDown.Name = "Light2NumericUpDown";
            this.Light2NumericUpDown.Size = new System.Drawing.Size(45, 22);
            this.Light2NumericUpDown.TabIndex = 16;
            this.Light2NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Light2NumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.Light2NumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Light2NumericUpDown.ValueChanged += new System.EventHandler(this.LightNumericUpDown_ValueChanged);
            // 
            // Light1NumericUpDown
            // 
            this.Light1NumericUpDown.Location = new System.Drawing.Point(14, 131);
            this.Light1NumericUpDown.Name = "Light1NumericUpDown";
            this.Light1NumericUpDown.Size = new System.Drawing.Size(45, 22);
            this.Light1NumericUpDown.TabIndex = 15;
            this.Light1NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Light1NumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.Light1NumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Light1NumericUpDown.ValueChanged += new System.EventHandler(this.LightNumericUpDown_ValueChanged);
            // 
            // Light2TrackBar
            // 
            this.Light2TrackBar.Location = new System.Drawing.Point(74, 21);
            this.Light2TrackBar.Maximum = 100;
            this.Light2TrackBar.Name = "Light2TrackBar";
            this.Light2TrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Light2TrackBar.Size = new System.Drawing.Size(42, 104);
            this.Light2TrackBar.TabIndex = 6;
            this.Light2TrackBar.TickFrequency = 0;
            this.Light2TrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Light2TrackBar.Scroll += new System.EventHandler(this.LightTrackBar_Scroll);
            // 
            // Light1TrackBar
            // 
            this.Light1TrackBar.Location = new System.Drawing.Point(14, 21);
            this.Light1TrackBar.Maximum = 100;
            this.Light1TrackBar.Name = "Light1TrackBar";
            this.Light1TrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Light1TrackBar.Size = new System.Drawing.Size(42, 104);
            this.Light1TrackBar.TabIndex = 0;
            this.Light1TrackBar.TickFrequency = 0;
            this.Light1TrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Light1TrackBar.Scroll += new System.EventHandler(this.LightTrackBar_Scroll);
            // 
            // LightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Name = "LightControl";
            this.Size = new System.Drawing.Size(132, 163);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Light2NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light1NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light2TrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light1TrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown Light2NumericUpDown;
        private System.Windows.Forms.NumericUpDown Light1NumericUpDown;
        private System.Windows.Forms.TrackBar Light2TrackBar;
        private System.Windows.Forms.TrackBar Light1TrackBar;
    }
}
