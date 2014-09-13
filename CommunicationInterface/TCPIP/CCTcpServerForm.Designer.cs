namespace CommunicationInterface
{
    partial class CCTcpServerForm
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
            this.rtfTerminal = new System.Windows.Forms.RichTextBox();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.cbConnect = new System.Windows.Forms.CheckBox();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.lblSend = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnEstablish = new System.Windows.Forms.Button();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP4 = new System.Windows.Forms.TextBox();
            this.txtIP3 = new System.Windows.Forms.TextBox();
            this.txtIP2 = new System.Windows.Forms.TextBox();
            this.txtIP1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbInformation.SuspendLayout();
            this.gbInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtfTerminal
            // 
            this.rtfTerminal.Location = new System.Drawing.Point(12, 13);
            this.rtfTerminal.Name = "rtfTerminal";
            this.rtfTerminal.Size = new System.Drawing.Size(716, 327);
            this.rtfTerminal.TabIndex = 1;
            this.rtfTerminal.Text = "";
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.cbConnect);
            this.gbInformation.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbInformation.Location = new System.Drawing.Point(12, 385);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(160, 156);
            this.gbInformation.TabIndex = 2;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Connection Status";
            // 
            // cbConnect
            // 
            this.cbConnect.AutoSize = true;
            this.cbConnect.Location = new System.Drawing.Point(32, 29);
            this.cbConnect.Name = "cbConnect";
            this.cbConnect.Size = new System.Drawing.Size(79, 20);
            this.cbConnect.TabIndex = 0;
            this.cbConnect.Text = "Connect";
            this.cbConnect.UseVisualStyleBackColor = true;
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(91, 357);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(533, 22);
            this.txtSendData.TabIndex = 4;
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSend.Location = new System.Drawing.Point(9, 357);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(76, 16);
            this.lblSend.TabIndex = 3;
            this.lblSend.Text = "Send &Data:";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSend.Location = new System.Drawing.Point(630, 347);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 37);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnEstablish
            // 
            this.btnEstablish.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEstablish.Location = new System.Drawing.Point(630, 408);
            this.btnEstablish.Name = "btnEstablish";
            this.btnEstablish.Size = new System.Drawing.Size(98, 39);
            this.btnEstablish.TabIndex = 9;
            this.btnEstablish.Text = "Establish";
            this.btnEstablish.UseVisualStyleBackColor = true;
            this.btnEstablish.Click += new System.EventHandler(this.btnEstablish_Click);
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.txtPort);
            this.gbInput.Controls.Add(this.label5);
            this.gbInput.Controls.Add(this.label4);
            this.gbInput.Controls.Add(this.label3);
            this.gbInput.Controls.Add(this.label2);
            this.gbInput.Controls.Add(this.txtIP4);
            this.gbInput.Controls.Add(this.txtIP3);
            this.gbInput.Controls.Add(this.txtIP2);
            this.gbInput.Controls.Add(this.txtIP1);
            this.gbInput.Controls.Add(this.label1);
            this.gbInput.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbInput.Location = new System.Drawing.Point(178, 385);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(446, 156);
            this.gbInput.TabIndex = 3;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "IP && Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(50, 106);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(94, 27);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "4000";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = ".";
            // 
            // txtIP4
            // 
            this.txtIP4.Location = new System.Drawing.Point(340, 29);
            this.txtIP4.Name = "txtIP4";
            this.txtIP4.ReadOnly = true;
            this.txtIP4.Size = new System.Drawing.Size(77, 27);
            this.txtIP4.TabIndex = 4;
            this.txtIP4.Text = "1";
            this.txtIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP3
            // 
            this.txtIP3.Location = new System.Drawing.Point(239, 29);
            this.txtIP3.Name = "txtIP3";
            this.txtIP3.ReadOnly = true;
            this.txtIP3.Size = new System.Drawing.Size(77, 27);
            this.txtIP3.TabIndex = 3;
            this.txtIP3.Text = "0";
            this.txtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP2
            // 
            this.txtIP2.Location = new System.Drawing.Point(138, 29);
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.ReadOnly = true;
            this.txtIP2.Size = new System.Drawing.Size(77, 27);
            this.txtIP2.TabIndex = 2;
            this.txtIP2.Text = "0";
            this.txtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP1
            // 
            this.txtIP1.Location = new System.Drawing.Point(37, 29);
            this.txtIP1.Name = "txtIP1";
            this.txtIP1.ReadOnly = true;
            this.txtIP1.Size = new System.Drawing.Size(77, 27);
            this.txtIP1.TabIndex = 1;
            this.txtIP1.Text = "127";
            this.txtIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(734, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 37);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // CCTcpServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.btnEstablish);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.gbInformation);
            this.Controls.Add(this.rtfTerminal);
            this.Name = "CCTcpServerForm";
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfTerminal;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox cbConnect;
        private System.Windows.Forms.Button btnEstablish;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP4;
        private System.Windows.Forms.TextBox txtIP3;
        private System.Windows.Forms.TextBox txtIP2;
        private System.Windows.Forms.TextBox txtIP1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
    }
}
