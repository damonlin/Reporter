using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace CommunicationInterface
{
    public class CCRS232Protocol : CCBaseProtocol
    {
        #region Private Member
        private SerialPort m_SerialPort = null;
        #endregion

        #region Ctor
        public CCRS232Protocol() : base(PrototcolType.RS232_TYPE)
        {
            m_SerialPort = new SerialPort();

            //m_SerialPort.Encoding = new UnicodeEncoding();

            // Set Default COM Port
            if (SerialPort.GetPortNames().Length > 0 )
                PortNumber = SerialPort.GetPortNames()[0];
        }
        #endregion

        #region properties

        // COM port
        public string PortNumber
        {
            get { return m_SerialPort.PortName; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.PortName = value;
            }
        }

        // Port Boudrate
        public int PortBoudrate
        {
            get { return m_SerialPort.BaudRate; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.BaudRate = value;
            }
        }

        // Port DataBits
        public int PortDataBits
        {
            get { return m_SerialPort.DataBits; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.DataBits = value;
            }
        }

        // Port StopBits
        public StopBits PortStopBits
        {
            get { return m_SerialPort.StopBits; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.StopBits = value;
            }
        }

        // Port Parity
        public Parity PortParity
        {
            get { return m_SerialPort.Parity; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.Parity = value;
            }
        }

        // Port DataReceived        
        public override SerialDataReceivedEventHandler DataReceiveHandler
        {
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.DataReceived += value;
            }
        }

        #endregion        

        #region Public Method
        public override bool Create()
        {
            if (m_SerialPort.IsOpen)
                m_SerialPort.Close();

            try
            {
                m_SerialPort.Open();
                m_ConnectHandler(this, null);
            }
            catch (Exception e)
            {
                MessageBox.Show( "[" + e.Message+ "]"+ " Can't Open : " + m_SerialPort.PortName);
                return false;
            }

            return true;
        }
        public override bool Destroy()
        {
            if (!m_SerialPort.IsOpen)
                return true;

            try
            {
                m_SerialPort.Close();
                m_DisconnectHandler(this, null);
            }
            catch (Exception e)
            {
                MessageBox.Show("[" + e.Message + "]" + "Can't Close : " + m_SerialPort.PortName);
                return false;
            }

            return true;
        }
        public override void Send(string p_szMsg)
        {
            if (m_SerialPort.IsOpen == false)
                m_SerialPort.Open();
            
            //byte[] sendBytes = System.Text.Encoding.Unicode.GetBytes(p_szMsg);            
            byte[] sendBytes = Convert.FromBase64String(p_szMsg);
            m_SerialPort.Write(sendBytes, 0, sendBytes.Length);           
        }

        public override string Receive()
        {
            Thread.Sleep(500);   
            int bytes = m_SerialPort.BytesToRead;
            byte[] receiveBuf = new byte[bytes];
            m_SerialPort.Read(receiveBuf, 0, bytes);
            return Convert.ToBase64String(receiveBuf);
        }    
        #endregion
    }
}
