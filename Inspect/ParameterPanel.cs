//#define PLC_ON

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.Template;
using System.Threading;
using IniTool;

namespace Parameter
{
    public partial class ParameterPanel : InfoPanelTemplate
    {
        private static ParameterPanel singleton = null;
        private const string strINIPath = "INI\\Parameter.INI";

        public ParameterPanel()
        {
            InitializeComponent();
            LoadIniFile();
        }

        public static ParameterPanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new ParameterPanel();
            }
            return singleton;
        }

        private void LoadIniFile()
        {
            IniFile iniFile = new IniFile(strINIPath);

            D0200.Text = iniFile.GetString("PARAMETER", "Cycle Run", "");
            D0201.Text = iniFile.GetString("PARAMETER", "MFC Flow Set", "");
            D0202.Text = iniFile.GetString("PARAMETER", "MFC Flow Time Set", "");
            D0203.Text = iniFile.GetString("PARAMETER", "Lock in Pressure", "");
            D0204.Text = iniFile.GetString("PARAMETER", "Lock in Pressure Alarm", "");
            D0205.Text = iniFile.GetString("PARAMETER", "Watt value Set", "");
            D0206.Text = iniFile.GetString("PARAMETER", "Watt value Alarm", "");
            D0207.Text = iniFile.GetString("PARAMETER", "Current value Set", "");
            D0208.Text = iniFile.GetString("PARAMETER", "Current value Alarm", "");
            D0209.Text = iniFile.GetString("PARAMETER", "LVG", "");
            D0210.Text = iniFile.GetString("PARAMETER", "HVG", "");   
        }

        private void SaveIniFile()
        {
            IniFile iniFile = new IniFile(strINIPath);

            iniFile.WriteValue("PARAMETER", "Cycle Run", D0200.Text);
            iniFile.WriteValue("PARAMETER", "MFC Flow Set", D0201.Text);
            iniFile.WriteValue("PARAMETER", "MFC Flow Time Set", D0202.Text);
            iniFile.WriteValue("PARAMETER", "Lock in Pressure", D0203.Text);
            iniFile.WriteValue("PARAMETER", "Lock in Pressure Alarm", D0204.Text);
            iniFile.WriteValue("PARAMETER", "Watt value Set", D0205.Text);
            iniFile.WriteValue("PARAMETER", "Watt value Alarm", D0206.Text);
            iniFile.WriteValue("PARAMETER", "Current value Set", D0207.Text);
            iniFile.WriteValue("PARAMETER", "Current value Alarm", D0208.Text);
            iniFile.WriteValue("PARAMETER", "LVG", D0209.Text);
            iniFile.WriteValue("PARAMETER", "HVG", D0210.Text);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            ContrelModule.CPLCInterface PLCInterface = ContrelModule.CPLCInterface.GetSingleton();

            StringBuilder value = new StringBuilder(100);
            
            int val = Convert.ToInt32(D0200.Text) * 10;
            value.Append( String.Format("{0:X4}", val) );

            val = Convert.ToInt32(D0201.Text);
            value.Append(String.Format("{0:X4}", val));

            val = Convert.ToInt32(D0202.Text);
            value.Append(String.Format("{0:X4}", val));

            val = Convert.ToInt32(D0203.Text);
            value.Append(String.Format("{0:X4}", val));

            val = Convert.ToInt32(D0204.Text);
            value.Append(String.Format("{0:X4}", val));

            val = Convert.ToInt32(D0205.Text);
            value.Append(String.Format("{0:X4}", val));

            val = Convert.ToInt32(D0206.Text);
            value.Append(String.Format("{0:X4}", val));

            val = Convert.ToInt32(D0207.Text);
            value.Append(String.Format("{0:X4}", val));

            val = Convert.ToInt32(D0208.Text);
            value.Append(String.Format("{0:X4}", val));

#if PLC_ON
            PLCInterface.PLCWriteWord_D("D0200", 9, value.ToString() );
#endif

            Thread.Sleep(500);
            value.Clear();

            double dwTmp = (5.625 + Math.Log(Convert.ToDouble(D0209.Text)) / Math.Log(10)) / 0.005;
            val = (int)Math.Round(dwTmp, 0);
            value.Append(String.Format("{0:X4}", val));

            dwTmp = (5.625 + Math.Log(Convert.ToDouble(D0210.Text)) / Math.Log(10)) / 0.005;
            val = (int)Math.Round(dwTmp, 0);
            value.Append(String.Format("{0:X4}", val));
#if PLC_ON
            PLCInterface.PLCWriteWord_D("D0209", 2, value.ToString() );
#endif
            SaveIniFile();

        }     
    }
}
