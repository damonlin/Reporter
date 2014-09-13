using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ContrelModule
{
    public partial class ZMotionControl : UserControl
    {
        #region Private Member
        private RS232Info m_ZMotionInfo = new RS232Info();
        private bool m_bEnable = false;
        private int m_iSpeedPower = 1;
        #endregion

        #region Public Property
        [TypeConverterAttribute(typeof(ZMotionInfo))]
        public RS232Info _0_Info
        {
            get { return m_ZMotionInfo; }
            set { m_ZMotionInfo = value; }
        }
        #endregion

        public ZMotionControl()
        {
            InitializeComponent();
        }

        private void Init()
        {
            //ZMotion模組初始化  
            ZMotion.ZMInitPortInf((uint)m_ZMotionInfo.PortNumber,
                                                   m_ZMotionInfo.PortBoudrate,
                                                   m_ZMotionInfo.PortDataBits,
                                                   //m_ZMotionInfo.PortParity.ToString()[0],                                                   
                                                   'n',
                                                   (int)m_ZMotionInfo.PortStopBits); //5, 9600, 8, ... 預設值

            //ZMotion.ZMRegestCallbackFunc(ZMotionCallback);
            ZMotion.ZMInitial(false);
            ZMotion.AFOpenConnection();
            ZMotion.ZMDoorInterlock(false);  //  FALSE 表示safe
            ZMotion.ZMPowerSwitch(true);

            ZMotion.ZMHome(true);

        }

        private void AFButton_Click(object sender, EventArgs e)
        {
            ZMotion.ZMAutofocus();
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            //double nowPos = ZMotion.ZMGetCurrentPosition();
            //double newPos = nowPos - 10000.0;
            ZMotion.ZMRelMove(-1000 / m_iSpeedPower);
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            //double newPos = ZMotion.ZMGetCurrentPosition() + 10000.0;
            ZMotion.ZMRelMove(1000 / m_iSpeedPower);            
        }

        public void AF()
        {
            ZMotion.ZMAutofocus();
        }

        public bool Ready()
        {
            return ZMotion.ZMReady();
        }

        public bool Enable
        {
            get { return m_bEnable; }
            set
            {
                m_bEnable = value;

                if (!this.DesignMode && System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && m_bEnable)
                {
                    Init();
                }
            }
        }

        private void MoveFastRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_iSpeedPower = 1;
        }

        private void MoveSlowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            m_iSpeedPower = 100;
        }
    }

    public class ZMotionInfo : ExpandableObjectConverter
    {
        private RS232Info m_ZMotionRs232PortInfo = new RS232Info();

        [TypeConverterAttribute(typeof(RS232Info))]
        public RS232Info _01_ZMotionRs232PortInfo
        {
            get { return m_ZMotionRs232PortInfo; }
            set
            {
                m_ZMotionRs232PortInfo = value;
            }
        }

    }
}
