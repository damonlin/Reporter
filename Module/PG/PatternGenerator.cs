using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using CommunicationInterface;

namespace ContrelModule
{
    public partial class PatternGenerator : UserControl
    {
        private enumPGType m_enumPGType = enumPGType.Chroma;
        private CCStandardInterface m_objInterface = new CCStandardInterface();
        private RS232Info m_objRS232Info = new RS232Info();
        private CCRS232Protocol m_objRS232Protocol = new CCRS232Protocol();
        private CCQuickFunction m_ObjQuickFunction = new CCQuickFunction();
        private string[] m_aszFspString = { "", "" };
        private bool bEnable = false;

        public PatternGenerator()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && bEnable)
            {
                switch (m_enumPGType)
                {
                    case enumPGType.Chroma:
                        m_objRS232Protocol.PortNumber = string.Format("COM{0:d}", m_objRS232Info.PortNumber);
                        m_objRS232Protocol.PortDataBits = m_objRS232Info.PortDataBits;
                        m_objRS232Protocol.PortBoudrate = m_objRS232Info.PortBoudrate;
                        m_objRS232Protocol.PortParity = m_objRS232Info.PortParity;
                        m_objRS232Protocol.PortStopBits = m_objRS232Info.PortStopBits;

                        m_objInterface.Protocol = m_objRS232Protocol;
                        m_objInterface.Parser = new CChromaParser();
                        CChromaDispatcher ChromaDispatcher = new CChromaDispatcher(m_objInterface);
                        ChromaDispatcher.UI = this;
                        m_objInterface.Dispatcher = ChromaDispatcher;
                        m_objInterface.TextUI = richTextBox1;
                        m_objInterface.Create();
                        break;
                }
            }
        }

        private void ChangePattern_Click(object sender, EventArgs e)
        {
            switch(m_enumPGType)
            {
                case enumPGType.Chroma:
                    if (sender == ChangePatternButton)
                    {
                        m_objInterface.SendMessage("PatternChange:" + PatternNameComboBox.Text);
                    }
                    else if (sender == PreviousPatternButton)
                    {
                        m_objInterface.SendMessage("PrevPattern:");
                    }
                    else if (sender == NextPatternButton)
                    {
                        m_objInterface.SendMessage("NextPattern:");
                    }
                    break;
            }
        }

        private void OnLineCheckBox_Click(object sender, EventArgs e)
        {
            switch (m_enumPGType)
            {
                case enumPGType.Chroma:
                    if (((CheckBox)sender).Checked)
                    {
                        m_objInterface.SendMessage("OnLine:" + "BPRS");
                    }
                    else
                    {
                        //m_objInterface.SendMessage("PanelUnload:" + );
                    }
                    break;
            }
        }
        
        private void Light_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                return;
            }

            switch (m_enumPGType)
            {
                case enumPGType.Chroma:
                    if (sender == LightOnRadioButton)
                    {
                        if (ContactRadioButton.Checked == true)
                        {
                            //if (Common.GlobalValue.GlassProcessStatus[1])
                            {
                                //m_objInterface.SendMessage("OnContact:" + Common.GlobalValue.GlassData1.GlassID.ToString());
                                m_objInterface.SendMessage("OnContact:" + "GGG");
                            }
                            //else if (Common.GlobalValue.GlassProcessStatus[2])
                            {
                                //m_objInterface.SendMessage("OnContact:" + Common.GlobalValue.GlassData2.GlassID.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Contact First");
                        }
                    }
                    else if (sender == LightOffRadioButton)
                    {
                        m_objInterface.SendMessage("PanelUnload:");
                    }
                    break;
            }
        }

        private void Contact_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                return;
            }

            switch (m_enumPGType)
            {
                case enumPGType.Chroma:
                    if (sender == ContactRadioButton)
                    {
                        ContactRadioButton.Checked = true;
                        UncontactRadioButton.Checked = false;
                    }
                    else if (sender == UncontactRadioButton)
                    {
                        if (LightOffRadioButton.Checked == true)
                        {
                            ContactRadioButton.Checked = false;
                            UncontactRadioButton.Checked = true;
                        }
                        else
                        {
                            MessageBox.Show("Please Light Off First");
                        }
                    }
                    break;
            }
        }

        public enumPGType _0_PatternGeneratorType_
        {
            get { return m_enumPGType; }
            set { m_enumPGType = value; }
        }

        [TypeConverterAttribute(typeof(RS232Info))]
        public RS232Info _1_RS232Protocol_
        {
            get { return m_objRS232Info; }
            set { m_objRS232Info = value; }
        }

        [TypeConverterAttribute(typeof(CCQuickFunction))]
        public CCQuickFunction _2_QuickFunction_
        {
            get { return m_ObjQuickFunction; }
            set { m_ObjQuickFunction = value; }
        }

        public bool _3_Enable_
        {
            get { return bEnable; }
            set { 
                bEnable = value;

                if (!this.DesignMode && System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && bEnable)
                {
                    switch (m_enumPGType)
                    {
                        case enumPGType.Chroma:
                            m_objRS232Protocol.PortNumber = string.Format("COM{0:d}", m_objRS232Info.PortNumber);
                            m_objRS232Protocol.PortDataBits = m_objRS232Info.PortDataBits;
                            m_objRS232Protocol.PortBoudrate = m_objRS232Info.PortBoudrate;
                            m_objRS232Protocol.PortParity = m_objRS232Info.PortParity;
                            m_objRS232Protocol.PortStopBits = m_objRS232Info.PortStopBits;

                            m_objInterface.EnableRetry = false;
                            m_objInterface.Protocol = m_objRS232Protocol;
                            m_objInterface.Parser = new CChromaParser();
                            CChromaDispatcher ChromaDispatcher = new CChromaDispatcher(m_objInterface);
                            ChromaDispatcher.UI = this;
                            m_objInterface.Dispatcher = ChromaDispatcher;
                            m_objInterface.TextUI = richTextBox1;
                            m_objInterface.Create();
                            break;
                    }
                }
            }
        }

        private void TestCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TestCheckBox.Checked)
            {
                m_objInterface.SendMessage("Ping:Chroma");
            }
            else
            {
            }
        }
    }

    #region PG Setup
    public enum enumPGType
    {
        Chroma = 0
    }

    public class RS232Info : ExpandableObjectConverter
    {
        private int iPortNumber = 2;
        private int iPortBoudrate = 19200;
        private int iPortDataBits = 8;
        private StopBits objPortStopBits = StopBits.One;
        private Parity objParity = Parity.None;
        private int iRetryTimes = 3;

        // COM port
        public int PortNumber
        {
            get { return iPortNumber; }
            set { iPortNumber = value; }
        }

        // Port Boudrate
        public int PortBoudrate
        {
            get { return iPortBoudrate; }
            set { iPortBoudrate = value; }
        }

        // Port DataBits
        public int PortDataBits
        {
            get { return iPortDataBits; }
            set { iPortDataBits = value; }
        }
        
        // Port StopBits
        public StopBits PortStopBits
        {
            get { return objPortStopBits; }
            set { objPortStopBits = value; }
        }

        // Port Parity
        public Parity PortParity
        {
            get { return objParity; }
            set { objParity = value; }
        }

        public int ReteyTimes
        {
            get { return iRetryTimes; }
            set { iRetryTimes = value; }
        }
    }

    #region Quick Function Setup
    public enum enuFunctionType
    {
        FSP = 0,
        DIO = 1,
        VIO = 2
    }

    public class CCQuickFunctionType : ExpandableObjectConverter
    {
        private enuFunctionType[] aenuContactFunctionType = { enuFunctionType.VIO, enuFunctionType.VIO };

        public enuFunctionType ContactFunctionType
        {
            get { return aenuContactFunctionType[0]; }
            set { aenuContactFunctionType[0] = value; }
        }

        public enuFunctionType UncontactFunctionType
        {
            get { return aenuContactFunctionType[1]; }
            set { aenuContactFunctionType[1] = value; }
        }
    }

    public class CCQuickFSPString : ExpandableObjectConverter
    {
        private string[] aszQuickFSPString = { "", "" };

        public string ContactFSP
        {
            get { return aszQuickFSPString[0]; }
            set { aszQuickFSPString[0] = value; }
        }

        public string UncontactFSP
        {
            get { return aszQuickFSPString[1]; }
            set { aszQuickFSPString[1] = value; }
        }
    }

    public class CCIOFunctionInfo : ExpandableObjectConverter
    {
        private int[] aiIOPoint = { 0, 0 };
        private bool[] aiIOValue ={ false, false };

        public int ContactIOPoint
        {
            get { return aiIOPoint[0]; }
            set { aiIOPoint[0] = value; }
        }

        public bool ContactIOVlaue
        {
            get { return aiIOValue[0]; }
            set { aiIOValue[0] = value; }
        }

        public int UncontactIOPoint
        {
            get { return aiIOPoint[1]; }
            set { aiIOPoint[1] = value; }
        }

        public bool UncontactIOVlaue
        {
            get { return aiIOValue[1]; }
            set { aiIOValue[1] = value; }
        }
    }

    public class CCQuickFunction : ExpandableObjectConverter
    {
        private CCQuickFunctionType objQuickFunctionType = new CCQuickFunctionType();
        private CCQuickFSPString objQuickFSPString = new CCQuickFSPString();
        private CCIOFunctionInfo objIOFunctionInfo = new CCIOFunctionInfo();

        [TypeConverterAttribute(typeof(CCQuickFunctionType))]
        public CCQuickFunctionType QuickFunctionType
        {
            get { return objQuickFunctionType; }
            set { objQuickFunctionType = value; }
        }
        
        [TypeConverterAttribute(typeof(CCQuickFSPString))]
        public CCQuickFSPString QuickFSPString
        {
            get { return objQuickFSPString; }
            set { objQuickFSPString = value; }
        }

        [TypeConverterAttribute(typeof(CCIOFunctionInfo))]
        public CCIOFunctionInfo IOFunctionInfo
        {
            get { return objIOFunctionInfo; }
            set { objIOFunctionInfo = value; }
        }
    }
    #endregion
    #endregion
}
