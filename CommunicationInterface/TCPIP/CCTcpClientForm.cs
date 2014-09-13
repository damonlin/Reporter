using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CommunicationInterface
{
    public partial class CCTcpClientForm : Common.Template.SubInfoPanelTemplate
    {
        #region Private Member
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP4;
        private System.Windows.Forms.TextBox txtIP3;
        private System.Windows.Forms.TextBox txtIP2;
        private System.Windows.Forms.TextBox txtIP1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtfTerminal;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.CheckBox cbConnect;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDisconnect;
        private CCStandardInterface m_TCPInterface = null;
        #endregion

        #region Property
        public CCStandardInterface Interface
        {
            get { return m_TCPInterface; }
        }
        #endregion

        #region Ctor
        public CCTcpClientForm()
        {
            InitializeComponent();

            // Create TCPIP Interface
            m_TCPInterface = new CCStandardInterface();
            m_TCPInterface.TextUI = rtfTerminal;
            m_TCPInterface.EnableRetry = false;

            // Setup Parser and Dispatcher if necessary
            //m_TCPInterface.Parser = new CChromaParser();
            //m_TCPInterface.Dispatcher = new CChromaDispatcher(m_RS232Interface);
        }
        #endregion

        #region Private Method
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string szIP = txtIP1.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;

            CCTcpClientProtocol protocol = new CCTcpClientProtocol( szIP , int.Parse(txtPort.Text) );
            //protocol.Broadcast = true;
            m_TCPInterface.Protocol = protocol;

            m_TCPInterface.Create();
            //if (m_TCPInterface.Connect())
            //    cbConnect.CheckState = CheckState.Checked;
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            m_TCPInterface.Destroy();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            m_TCPInterface.SendMessage(this.txtSendData.Text);
        }        
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtfTerminal.Clear();
        }
        private void InitializeComponent()
        {
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
            this.rtfTerminal = new System.Windows.Forms.RichTextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblSend = new System.Windows.Forms.Label();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.cbConnect = new System.Windows.Forms.CheckBox();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.gbInput.SuspendLayout();
            this.gbInformation.SuspendLayout();
            this.SuspendLayout();
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
            this.gbInput.Location = new System.Drawing.Point(180, 375);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(446, 156);
            this.gbInput.TabIndex = 15;
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
            this.txtIP4.Size = new System.Drawing.Size(77, 27);
            this.txtIP4.TabIndex = 4;
            this.txtIP4.Text = "1";
            this.txtIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP3
            // 
            this.txtIP3.Location = new System.Drawing.Point(239, 29);
            this.txtIP3.Name = "txtIP3";
            this.txtIP3.Size = new System.Drawing.Size(77, 27);
            this.txtIP3.TabIndex = 3;
            this.txtIP3.Text = "0";
            this.txtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP2
            // 
            this.txtIP2.Location = new System.Drawing.Point(138, 29);
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.Size = new System.Drawing.Size(77, 27);
            this.txtIP2.TabIndex = 2;
            this.txtIP2.Text = "0";
            this.txtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP1
            // 
            this.txtIP1.Location = new System.Drawing.Point(37, 29);
            this.txtIP1.Name = "txtIP1";
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
            // rtfTerminal
            // 
            this.rtfTerminal.Location = new System.Drawing.Point(14, 3);
            this.rtfTerminal.Name = "rtfTerminal";
            this.rtfTerminal.Size = new System.Drawing.Size(716, 327);
            this.rtfTerminal.TabIndex = 12;
            this.rtfTerminal.Text = "";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnConnect.Location = new System.Drawing.Point(632, 380);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(98, 39);
            this.btnConnect.TabIndex = 18;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSend.Location = new System.Drawing.Point(632, 337);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 37);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSend.Location = new System.Drawing.Point(11, 347);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(76, 16);
            this.lblSend.TabIndex = 14;
            this.lblSend.Text = "Send &Data:";
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.cbConnect);
            this.gbInformation.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbInformation.Location = new System.Drawing.Point(14, 375);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(160, 156);
            this.gbInformation.TabIndex = 13;
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
            this.txtSendData.Location = new System.Drawing.Point(93, 347);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(533, 22);
            this.txtSendData.TabIndex = 16;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(736, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 37);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDisconnect.Location = new System.Drawing.Point(632, 425);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(98, 39);
            this.btnDisconnect.TabIndex = 20;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // CCTcpClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.rtfTerminal);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.gbInformation);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.btnClear);
            this.Name = "CCTcpClientForm";
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
