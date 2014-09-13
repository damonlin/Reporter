using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SDDEMsg;

namespace ContrelModule
{
    public partial class Lens : UserControl
    {
        //LensInfo m_Info = new LensInfo();
        LensInfo m_Info =null;// new LensInfo();
        public RadioButton[] m_aiLenControl = null;

        public Lens()
        {
            InitializeComponent();


            m_Info = new LensInfo();
            m_aiLenControl = new RadioButton[4] { Lens1RadioButton, Lens2RadioButton, Lens3RadioButton, Lens4RadioButton };

        }

        [TypeConverterAttribute(typeof(LensInfo))]
        public LensInfo _LensInfo_
        {
            get { return m_Info; }
            set {
                if ((!this.DesignMode && System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime))
                {
                    m_Info = value;

                    for (int iCount = 0; iCount < 4; iCount++)
                    {
                        if (iCount < m_Info._00_LensCount)
                        {
                            m_aiLenControl[iCount].Text = m_Info._01_LensName[iCount];
                        }
                        else
                        {
                            m_aiLenControl[iCount].Text = "";
                            m_aiLenControl[iCount].Enabled = false;
                            m_aiLenControl[iCount].Visible = false;
                        }
                    }
                }
            }
        }

        private void LensRadioButton_Click(object sender, EventArgs e)
        {
            if (m_Info._08_LensEnable)
            {
                RadioButton ClickButton = (RadioButton)sender;
                //if (Common.CTAPSetup.EnableTK)
                {
                    for (int iCount = 0; iCount < m_Info._00_LensCount; iCount++)
                    {
                        if (m_aiLenControl[iCount] == ClickButton)
                        {
                            switch (m_Info._03_LensTriggerType)
                            {
                                case enumLensTriggerType.DIO:
                                    //TK.CCTKform.TK_DIO.CCDioModule_SetDO(m_Info._04_LensTriggerDIO[iCount], m_Info._06_LensTriggerIOValue[iCount]);
                                    break;

                                case enumLensTriggerType.VIO:
                                    //TK.CCTKform.TK_VIO.CCVioModule_SetVIO(m_Info._05_LensTriggerVIO[iCount], m_Info._06_LensTriggerIOValue[iCount]);
                                    break;

                                case enumLensTriggerType.Command:
                                    SDDE.GetSingleton().SendMessageToTK(m_Info._07_LensTriggerCmd[iCount].ToString());                                    
                                    break;
                            }

                            // ¬ö¿ý Len ½s¸¹
                            Common.GlobalValue.Lens = iCount;

                            // ¸ÉÀv Len ¤Á´«¶ZÂ÷
                            int[] aiOffset = { 0, 0, 0 };
                            Common.GlobalValue.GetLensOffset(ref aiOffset[0], ref aiOffset[1], ref aiOffset[2]);
                            SDDE.GetSingleton().SendMessageToTK(string.Format("C401,{0:d},{1:d},{1:d},1000,300,300,0", aiOffset[0], aiOffset[1]));

                            // ³]©wZ¶b¦ì¸m
                            ContrelModule.ZMotion.ZMAbsMove((double)aiOffset[2]);
                        }
                    }
                }
            }
        }

        public void LensSwitch(int iLensIdx)
        {
            if (m_Info._08_LensEnable)
            {
                LensRadioButton_Click(m_aiLenControl[iLensIdx], EventArgs.Empty);
                m_aiLenControl[iLensIdx].Checked = true;
            }
        }
    }

    public class LensInfo: ExpandableObjectConverter
    {
        #region Lens Used
        private int m_iLensCount = 4;
        private string[] m_aiLensName = new string[4] { "2X", "5X", "20X", "50X" };
        private enumLensType m_eumLensType = enumLensType.LineType;
        private enumLensTriggerType m_eumLensTriggerType = enumLensTriggerType.Command;
        private int[] m_aiLensTriggerDIO = new int[4] { 0, 0, 0, 0 };
        private int[] m_aiLensTriggerVIO = new int[4] { 0, 0, 0, 0 };
        private bool[] m_aiLensTriggerIOValue = new bool[4] { false, false, false, false };
        private string[] m_aiLensTriggerCmd = new string[4] { "C101,1", "C101,2", "C101,3", "C101,4" };
        private bool m_bLensEnable = true;
        #endregion

        public int _00_LensCount
        {
            get { return m_iLensCount; }
            set
            {
                if (value > 4)
                    value = 4;
                m_iLensCount = value;
            }
        }

        public string[] _01_LensName
        {
            get { return m_aiLensName; }
            set
            {
                m_aiLensName = value;
            }
        }

        public enumLensType _02_LensType
        {
            get { return m_eumLensType; }
            set { m_eumLensType = value; }
        }

        public enumLensTriggerType _03_LensTriggerType
        {
            get { return m_eumLensTriggerType; }
            set { m_eumLensTriggerType = value; }
        }

        public int[] _04_LensTriggerDIO
        {
            get { return m_aiLensTriggerDIO; }
            set { m_aiLensTriggerDIO = value; }
        }

        public int[] _05_LensTriggerVIO
        {
            get { return m_aiLensTriggerVIO; }
            set { m_aiLensTriggerVIO = value; }
        }

        public bool[] _06_LensTriggerIOValue
        {
            get { return m_aiLensTriggerIOValue; }
            set { m_aiLensTriggerIOValue = value; }
        }

        public string[] _07_LensTriggerCmd
        {
            get { return m_aiLensTriggerCmd; }
            set { m_aiLensTriggerCmd = value; }
        }

        public bool _08_LensEnable
        {
            get { return m_bLensEnable; }
            set { m_bLensEnable = value; }
        }
    }

    public enum enumLensType
    {
        LineType = 0,
        Turret = 1
    }

    public enum enumLensTriggerType
    {
        DIO = 0,
        VIO = 1,
        Command = 2
    }
}
