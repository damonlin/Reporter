using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace ContrelModule
{
    public partial class LightControl : UserControl
    {
        private LightInfo m_LightInfo = new LightInfo();
        private string[] m_aszLightChannelString = new string[2];
        private SerialPort m_LightRs232Port = null;
        public NumericUpDown[] m_aiLightTextControl = new NumericUpDown[2];
        private TrackBar[] m_aiLightTrackControl = new TrackBar[2];
        private bool m_bLightEnable = true;
        
        public LightControl()
        {
            InitializeComponent();

            m_aiLightTrackControl = new TrackBar[] { Light1TrackBar, Light2TrackBar };
            m_aiLightTextControl = new NumericUpDown[] { Light1NumericUpDown, Light2NumericUpDown };

            for (int iCount = 0; iCount < 2; iCount++)
            {
                m_aiLightTextControl[iCount].Enabled = iCount < m_LightInfo._00_LightCount;
                m_aiLightTextControl[iCount].Visible = iCount < m_LightInfo._00_LightCount;

                m_aiLightTrackControl[iCount].Enabled = iCount < m_LightInfo._00_LightCount;
                m_aiLightTrackControl[iCount].Visible = iCount < m_LightInfo._00_LightCount;
            }
            
            /*if (!this.DesignMode && System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && m_bLightEnable)
            {
                InitLightRS232Connect();
            }
            */

            
        }

        private void LightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //if (m_bLightEnable)
            {
                NumericUpDown LightNumeric = (NumericUpDown)sender;
                switch (m_LightInfo._01_LightControlType)
                {
                    case enumLightControlType.Rs232:
                        int iValue = ((int)LightNumeric.Value) * 4096 / 100;

                        if (LightNumeric == m_aiLightTextControl[0])
                        {
                            if (iValue != 0)
                            {
                                if (m_LightInfo._00_LightCount != 1 && m_LightInfo._04_LightValue[1] != 0)
                                {
                                    SendCommand("10", "0003");
                                }
                                else
                                {
                                    SendCommand("10", "0001");
                                }

                                Thread.Sleep(50);

                                string szCmd = string.Format("{0}{1:X4}", m_aszLightChannelString[0], iValue);
                                SendCommand("12", szCmd);
                            }
                            else
                            {
                                if (m_LightInfo._00_LightCount != 1 && m_LightInfo._04_LightValue[1] != 0)
                                {
                                    SendCommand("10", "0000");
                                }
                                else
                                {
                                    SendCommand("10", "0002");
                                }
                            }
                            Thread.Sleep(50);
                            m_LightInfo._04_LightValue[0] = iValue;

                        }
                        else
                        {
                            if (iValue != 0)
                            {
                                if (m_LightInfo._04_LightValue[1] != 0)
                                {
                                    SendCommand("10", "0003");
                                }
                                else
                                {
                                    SendCommand("10", "0002");
                                }

                                Thread.Sleep(50);

                                string szCmd = string.Format("{0}{1:X4}", m_aszLightChannelString[1], iValue);
                                SendCommand("12", szCmd);
                            }
                            else
                            {
                                if (m_LightInfo._04_LightValue[1] != 0)
                                {
                                    SendCommand("10", "0000");
                                }
                                else
                                {
                                    SendCommand("10", "0001");
                                }
                            }
                            m_LightInfo._04_LightValue[1] = iValue;
                            Thread.Sleep(50);
                        }
                        break;
                }
            }
        }

        private void LightTrackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar ScrollBar = (TrackBar)sender;

            if (ScrollBar == m_aiLightTrackControl[0])
            {
                m_aiLightTextControl[0].Value = ScrollBar.Value;
            }
            else
            {
                m_aiLightTextControl[1].Value = ScrollBar.Value;
            }
        }

        private void InitLightRS232Connect()
        {
            m_LightRs232Port = new SerialPort(string.Format("COM{0:D}", m_LightInfo._02_LightRs232PortInfo.PortNumber), 
                                                                        9600,
                                                                        //m_LightInfo._02_LightRs232PortInfo.PortBoudrate, 
                                                                        m_LightInfo._02_LightRs232PortInfo.PortParity, 
                                                                        m_LightInfo._02_LightRs232PortInfo.PortDataBits, 
                                                                        m_LightInfo._02_LightRs232PortInfo.PortStopBits);

            if (m_LightRs232Port.IsOpen)
            {
                MessageBox.Show("Light RS232 Port Opened");
            }
            else
            {
                try
                {
                    m_LightRs232Port.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            switch (m_LightInfo._03_LightChannel[0])
            {
                case 1:
                    m_aszLightChannelString[0] = "00";
                    break;

                case 2:
                    m_aszLightChannelString[0] = "01";
                    break;

                case 3:
                    m_aszLightChannelString[0] = "02";
                    break;

                case 4:
                    m_aszLightChannelString[0] = "03";
                    break;
            }

            if (m_LightInfo._00_LightCount == 2)
            {
                switch (m_LightInfo._03_LightChannel[1])
                {
                    case 1:
                        m_aszLightChannelString[1] = "10";
                        break;

                    case 2:
                        m_aszLightChannelString[1] = "11";
                        break;

                    case 3:
                        m_aszLightChannelString[1] = "12";
                        break;

                    case 4:
                        m_aszLightChannelString[1] = "13";
                        break;
                }
            }
        }

        private void SendCommand(string szCmd, string szMsg)
        {
            string temp = "";

            byte btCmd = Convert.ToByte(szCmd, 16);
            byte[] data = new byte[280];

            int iDataSize = szMsg.Length / 2;
            for (int iCount = 0; iCount < iDataSize; iCount++)
            {
                temp = szMsg.Substring(iCount * 2, 2);
                data[iCount] = Convert.ToByte(temp, 16);
            }

            byte[] dataForSend = new byte[280];
            dataForSend[0] = 0x30;
            dataForSend[1] = (byte)iDataSize;
            dataForSend[2] = btCmd;

            for (int iCount = 0; iCount < iDataSize; iCount++)
            {
                dataForSend[3 + iCount] = data[iCount];
            }

            ushort CRC = GetCRC(dataForSend, 1, 2 + iDataSize);
            int iCRC_Index = 3 + iDataSize;
            dataForSend[iCRC_Index] = (byte)(CRC >> 8);
            dataForSend[iCRC_Index + 1] = (byte)(CRC & 0x00FF);

            dataForSend[iCRC_Index + 2] = 0x30;

            int iStrLen = 1 + 1 + 1 + iDataSize + 2 + 1;

            m_LightRs232Port.Write(dataForSend, 0, iStrLen);
        }

        private ushort GetCRC(byte[] str, int idx, int istrLen)
        {
            ushort CRC_acc = 0xFFFF;
            for (int iCount = 0; iCount < istrLen; iCount++)
            {
                CRC_acc = UpdateCRC(CRC_acc, str[iCount + idx]);
            }
            return CRC_acc;
        }

        private ushort UpdateCRC(ushort CRC_acc, byte CRC_Input)
        {
            uint POLY = 0x1021;

            CRC_acc = (ushort)(CRC_acc ^ (CRC_Input << 8));

            for (int iCount = 0; iCount < 8; iCount++)
            {
                if ((CRC_acc & 0x8000) == 0x8000)
                {
                    CRC_acc = (ushort)(CRC_acc << 1);
                    CRC_acc = (ushort)(CRC_acc ^ POLY);
                }
                else
                {
                    CRC_acc = (ushort)(CRC_acc << 1);
                }
            }

            return CRC_acc;
        }

        public void LightAdj(int iLightIdx, int iValue)
        {
            if (m_bLightEnable)
            {
                if (iLightIdx > 0 && iLightIdx < m_LightInfo._00_LightCount)
                {
                    m_aiLightTextControl[iLightIdx].Value = iValue;
                }
            }
        }

        [TypeConverterAttribute(typeof(LightInfo))]
        public LightInfo Info
        {
            get { return m_LightInfo; }
            set { m_LightInfo = value; }
        }



        public bool LightEnable
        {
            get { return m_bLightEnable; }
            set
            {
                m_bLightEnable = value;


                if (!this.DesignMode && System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && m_bLightEnable)
                {
                    InitLightRS232Connect();
                }

            }
        }


    }

    public class LightInfo : ExpandableObjectConverter
    {
        private int m_iLightCount = 2;
        private enumLightControlType m_eumLightControlType = enumLightControlType.Rs232;
        private RS232Info m_LightRs232PortInfo = new RS232Info();
        private int[] m_aiLightChannel = { 0, 0 };
        private int[] m_aiLightValue = { 0, 0 };

        public int _00_LightCount
        {
            get { return m_iLightCount; }
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                m_iLightCount = value;
            }
        }

        public enumLightControlType _01_LightControlType
        {
            get { return m_eumLightControlType; }
            set { m_eumLightControlType = value; }
        }

        [TypeConverterAttribute(typeof(RS232Info))]
        public RS232Info _02_LightRs232PortInfo
        {
            get { return m_LightRs232PortInfo; }
            set
            {
                m_LightRs232PortInfo = value;
            }
        }

        public int[] _03_LightChannel
        {
            get { return m_aiLightChannel; }
            set
            {
                if (value.Length == 2)
                {
                    
                        if (value[0] != value[1])
                        {
                            m_aiLightChannel = value;
                        }
                        else
                        {
                            MessageBox.Show("Channel Must Be Different");
                        }
                }
                else
                {
                    m_aiLightChannel = value;
                }
            }
        }

        public int[] _04_LightValue
        {
            get { return m_aiLightValue; }
            set { m_aiLightValue = value; }
        }
    }


    public enum enumLightControlType
    {
        Rs232 = 0,
        AD = 1
    }
}
