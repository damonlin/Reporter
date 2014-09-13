namespace CommunicationInterface
{
    partial class CCRs232Form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region 元件設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.rtfTerminal = new System.Windows.Forms.RichTextBox();
            this.lblSend = new System.Windows.Forms.Label();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.lblComPort = new System.Windows.Forms.GroupBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnClosePort = new System.Windows.Forms.Button();
            this.cmbCommand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblComPort.SuspendLayout();
            this.gbMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtfTerminal
            // 
            this.rtfTerminal.Location = new System.Drawing.Point(3, 3);
            this.rtfTerminal.Name = "rtfTerminal";
            this.rtfTerminal.Size = new System.Drawing.Size(716, 327);
            this.rtfTerminal.TabIndex = 0;
            this.rtfTerminal.Text = "";
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSend.Location = new System.Drawing.Point(3, 343);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(76, 16);
            this.lblSend.TabIndex = 1;
            this.lblSend.Text = "Send &Data:";
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(316, 340);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(309, 22);
            this.txtSendData.TabIndex = 2;
            // 
            // lblComPort
            // 
            this.lblComPort.Controls.Add(this.cmbStopBits);
            this.lblComPort.Controls.Add(this.cmbDataBits);
            this.lblComPort.Controls.Add(this.cmbParity);
            this.lblComPort.Controls.Add(this.cmbBaudRate);
            this.lblComPort.Controls.Add(this.cmbPortName);
            this.lblComPort.Controls.Add(this.lblStopBits);
            this.lblComPort.Controls.Add(this.lblDataBits);
            this.lblComPort.Controls.Add(this.lblParity);
            this.lblComPort.Controls.Add(this.lblBaudRate);
            this.lblComPort.Controls.Add(this.label1);
            this.lblComPort.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblComPort.Location = new System.Drawing.Point(6, 403);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(457, 136);
            this.lblComPort.TabIndex = 4;
            this.lblComPort.TabStop = false;
            this.lblComPort.Text = "Serial Port &Settings";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbStopBits.Location = new System.Drawing.Point(367, 85);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(75, 24);
            this.cmbStopBits.TabIndex = 9;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbDataBits.Location = new System.Drawing.Point(277, 85);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(75, 24);
            this.cmbDataBits.TabIndex = 8;
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(187, 85);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(75, 24);
            this.cmbParity.TabIndex = 7;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
            this.cmbBaudRate.Location = new System.Drawing.Point(97, 85);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(75, 24);
            this.cmbBaudRate.TabIndex = 6;
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cmbPortName.Location = new System.Drawing.Point(7, 85);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(75, 24);
            this.cmbPortName.TabIndex = 5;
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(364, 49);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(68, 16);
            this.lblStopBits.TabIndex = 4;
            this.lblStopBits.Text = "Stop Bits:";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(274, 49);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(69, 16);
            this.lblDataBits.TabIndex = 3;
            this.lblDataBits.Text = "Data Bits:";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(184, 49);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(48, 16);
            this.lblParity.TabIndex = 2;
            this.lblParity.Text = "Parity:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(95, 49);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(77, 16);
            this.lblBaudRate.TabIndex = 1;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port:";
            // 
            // gbMode
            // 
            this.gbMode.Controls.Add(this.rbHex);
            this.gbMode.Controls.Add(this.rbText);
            this.gbMode.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbMode.Location = new System.Drawing.Point(470, 403);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(155, 136);
            this.gbMode.TabIndex = 5;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Data &Mode";
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Location = new System.Drawing.Point(17, 85);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(52, 20);
            this.rbHex.TabIndex = 1;
            this.rbHex.TabStop = true;
            this.rbHex.Text = "Hex";
            this.rbHex.UseVisualStyleBackColor = true;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(15, 45);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(54, 20);
            this.rbText.TabIndex = 0;
            this.rbText.TabStop = true;
            this.rbText.Text = "Text";
            this.rbText.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSend.Location = new System.Drawing.Point(631, 336);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(88, 51);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOpenPort.Location = new System.Drawing.Point(631, 393);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(88, 53);
            this.btnOpenPort.TabIndex = 7;
            this.btnOpenPort.Text = "Open Port";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnClosePort
            // 
            this.btnClosePort.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClosePort.Location = new System.Drawing.Point(631, 452);
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.Size = new System.Drawing.Size(88, 53);
            this.btnClosePort.TabIndex = 8;
            this.btnClosePort.Text = "Close Port";
            this.btnClosePort.UseVisualStyleBackColor = true;
            this.btnClosePort.Click += new System.EventHandler(this.btnClosePort_Click);
            // 
            // cmbCommand
            // 
            this.cmbCommand.FormattingEnabled = true;
            this.cmbCommand.Items.AddRange(new object[] {
            "OnLine",
            "RecipeChange",
            "OnContact",
            "PatternChange",
            "DefectData",
            "PanelUnload",
            "ReContact",
            "UserID",
            "NextPatten",
            "PrevPatten",
            "StartTestingLR",
            "EndTestingLR",
            "Ori_final_Grade"});
            this.cmbCommand.Location = new System.Drawing.Point(103, 341);
            this.cmbCommand.Name = "cmbCommand";
            this.cmbCommand.Size = new System.Drawing.Size(192, 20);
            this.cmbCommand.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = ":";
            // 
            // CCRs232Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCommand);
            this.Controls.Add(this.btnClosePort);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.gbMode);
            this.Controls.Add(this.lblComPort);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.rtfTerminal);
            this.Name = "CCRs232Form";
            this.lblComPort.ResumeLayout(false);
            this.lblComPort.PerformLayout();
            this.gbMode.ResumeLayout(false);
            this.gbMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfTerminal;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.GroupBox lblComPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Button btnClosePort;
        private System.Windows.Forms.ComboBox cmbCommand;
        private System.Windows.Forms.Label label2;


    }
}
