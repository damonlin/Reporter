using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CommunicationInterface
{
    public partial class CCTcpServerForm : Common.Template.SubInfoPanelTemplate
    {
        #region Private Member
        private CCStandardInterface m_TCPInterface = null;
        #endregion

        #region Property
        public CCStandardInterface Interface
        {
            get { return m_TCPInterface; }
        }
        #endregion

        #region Ctor
        public CCTcpServerForm()
        {
            InitializeComponent();

            // Create TCPIP Interface
            m_TCPInterface = new CCStandardInterface();
            m_TCPInterface.TextUI = rtfTerminal;            

            //m_TCPInterface.Parser = new CChromaParser();
            m_TCPInterface.Dispatcher = new CChromaDispatcher(m_TCPInterface);
        }
        #endregion

        #region Private Method              
        private void btnSend_Click(object sender, EventArgs e)
        {
            m_TCPInterface.SendMessage(this.txtSendData.Text);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtfTerminal.Clear();
        }        
        private void btnEstablish_Click(object sender, EventArgs e)
        {
            if (m_TCPInterface.Protocol != null)
                m_TCPInterface.Destroy();                

            CCTcpServerProtocol protocol = new CCTcpServerProtocol(int.Parse(txtPort.Text));
            protocol.Broadcast = true;
            m_TCPInterface.Protocol = protocol;
			
			m_TCPInterface.Create();

            // Show IP
            string[] szIP = protocol.IP.Split('.');
            txtIP1.Text = szIP[0];
            txtIP2.Text = szIP[1];
            txtIP3.Text = szIP[2];
            txtIP4.Text = szIP[3];
        }
        #endregion
    }
}
