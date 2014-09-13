using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

// Get the default values
using CommunicationInterface.Properties;

namespace CommunicationInterface
{
    public partial class CCRs232Form : Common.Template.SubInfoPanelTemplate
    {
        private CCStandardInterface m_RS232Interface = null;

        public CCRs232Form()
        {
            InitializeComponent();

            // Restore the users settings
            InitializeControlValues();

            // Create RS232 Interface
            m_RS232Interface = new CCStandardInterface();
            m_RS232Interface.Parser = new CChromaParser();
            m_RS232Interface.Dispatcher = new CChromaDispatcher(m_RS232Interface);
        }

        /// <summary> Populate the form's controls with default settings. </summary>
        private void InitializeControlValues()
        {                       
            cmbParity.Text = Settings.Default.Parity.ToString();
            cmbStopBits.Text = Settings.Default.StopBits.ToString();
            cmbDataBits.Text = Settings.Default.DataBits.ToString();
            cmbParity.Text = Settings.Default.Parity.ToString();
            cmbBaudRate.Text = Settings.Default.BaudRate.ToString();
            cmbCommand.Text = Settings.Default.Command.ToString();

            cmbPortName.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
                cmbPortName.Items.Add(s);
            cmbPortName.Text = cmbPortName.Items[2] as string;
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            CCRS232Protocol protocol = new CCRS232Protocol();

            protocol.PortBoudrate = int.Parse(this.cmbBaudRate.Text);
            protocol.PortDataBits = int.Parse(this.cmbDataBits.Text);
            protocol.PortNumber = this.cmbPortName.Text;

            // ¦r¦êÂà«¬¦¨Enum
            protocol.PortStopBits = (StopBits)Enum.Parse(typeof(StopBits), this.cmbStopBits.Text);
            protocol.PortParity = (Parity)Enum.Parse(typeof(Parity), this.cmbParity.Text);

            m_RS232Interface.TextUI = rtfTerminal;

            m_RS232Interface.Protocol = protocol;

            m_RS232Interface.EnableRetry = false;

            m_RS232Interface.Create();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            m_RS232Interface.SendMessage(this.cmbCommand.Text + ":" + this.txtSendData.Text);
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            m_RS232Interface.Destroy();
        }

        private void SaveSettings()
        {
            Settings.Default.BaudRate = int.Parse(cmbBaudRate.Text);
            Settings.Default.DataBits = int.Parse(cmbDataBits.Text);
            Settings.Default.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
            Settings.Default.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
            Settings.Default.PortName = cmbPortName.Text;

            Settings.Default.Save();
        }
        

    }
}