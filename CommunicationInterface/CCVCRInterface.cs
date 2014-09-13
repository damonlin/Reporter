using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;

namespace Motor
{
   public class CPLCInterface
    {
        #region Private Member
        private  SerialPort m_SerialPort = null;
        static private CCVCRInterface Singleton;
        #endregion       

        #region Ctor
        protected CCVCRInterface()
        {
            m_SerialPort = new SerialPort();
            m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(this.VCRDataReceived);            
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
        public SerialDataReceivedEventHandler DataReceiveHandler
        {
            set
            {
                //if (m_SerialPort.IsOpen == false)
                    m_SerialPort.DataReceived += value;
            }            
        }        
        #endregion

        #region Public Method

       public static CCVCRInterface GetSingleton()
       {
           if (Singleton == null)
               Singleton = new CCVCRInterface();
           return Singleton;
       }

       public void Open()
        {
            m_SerialPort.Open();
        }

       public void Close()
        {
            m_SerialPort.Close();
        }

       public byte[] Receive()
        {
            int nbytes = m_SerialPort.BytesToRead;
            byte[] data = new byte[nbytes];
            m_SerialPort.Read(data, 0, data.Length);
            return data;
        }

       public void ReadVCR()
        {
            byte[] msg = new byte[5] { 0x1B, (byte)'P', 0x00, 0xFF, 0x0D };
            m_SerialPort.Write(msg, 0, msg.Length);
        }

       public void StartContinusReadVCR()
        {
            byte[] initialVCR = new byte[2] { (byte)'g', 0x0D };
            m_SerialPort.Write(initialVCR, 0, initialVCR.Length);
            Thread.Sleep(10);

            byte[] continusCMD = new byte[8 + 1] { (byte)'c', (byte)'o', (byte)'n', (byte)'t', (byte)'i', (byte)'n', (byte)'u', (byte)'e', 0x0D };            
            m_SerialPort.Write(continusCMD, 0, continusCMD.Length);
        }

        public void StopContinueReadVCR()
        {
            byte[] continusCMD = new byte[4 + 1] { (byte)'s', (byte)'t', (byte)'o', (byte)'p', 0x0D };
            m_SerialPort.Write(continusCMD, 0, continusCMD.Length);
        }

        #region Private Method
        public void VCRDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = Receive();
            int iOffset = 0;

            if (data.Length <= 0)
                return;

            switch (data[iOffset])
            {
                case 0x56: // 'V'
                case 0x44: // 'D'

                    // 1. Header
                    iOffset++;

                    // 2. Data Length
                    int iDatalen = Convert.ToInt16(data[iOffset]);
                    iOffset += 2;

                    // 3. ID
                    byte[] id = new byte[iDatalen];
                    Array.Copy(data, iOffset, id,0, id.Length);
                    string panelID = Encoding.Default.GetString(id);

                    MessageBox.Show("讀取ID: " + panelID);

                    
                    break;

                case 0x52: // 'R'
                    // TODO: Retry
                    break;
            }
        }

        #endregion
       
        #endregion

    }
}
