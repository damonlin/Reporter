using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IniTool;

namespace AutoMode
{
    public partial class ReportPage1 : Common.Wizard.CCInteriorWizardPage
    {
        private const string strINIPath = "INI\\ReportPage1.INI";
        private List<ComboBox> m_cbList = new List<ComboBox>();

        public ReportPage1()
        {
            InitializeComponent();

            InitializeComboxList();

            // 修正 TableLayout 閃爍問題
            MakeTablelayoutSmooth();

            LoadIniFile();
        }

        private void InitializeComboxList()
        {
            m_cbList.Add(CustomerName);
            m_cbList.Add(CustomAddress);
            m_cbList.Add(CustomExtension);
            m_cbList.Add(Salesman);
            m_cbList.Add(DisEngineer);
            m_cbList.Add(PumpType);
            m_cbList.Add(PumpSeries);
            m_cbList.Add(MeasureEngineer);
            m_cbList.Add(RunSpeed);
            m_cbList.Add(Equipment);
            m_cbList.Add(DrySeries);
            m_cbList.Add(RootsSeries);
            m_cbList.Add(PumpVoltage);

        }

        private void LoadIniFile()
        {
            IniFile iniFile = new IniFile(strINIPath);

            foreach (ComboBox cb in m_cbList)
            {
                List<KeyValuePair<string, string>> KeyValuePair = iniFile.GetSectionValuesAsList(cb.Name);

                foreach (KeyValuePair<string, string> val in KeyValuePair)
                {
                    cb.Items.Add(val.Value);
                }
            }
        }

        private void SaveIniFile(ComboBox cb)
        {
            IniFile iniFile = new IniFile(strINIPath);

            for (int iIdx = 1; iIdx < cb.Items.Count; ++iIdx)
            {
                iniFile.WriteValue(cb.Name, iIdx.ToString(), cb.Items[iIdx].ToString());
            }
        }

        private void MakeTablelayoutSmooth()
        {
            tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel1, true, null);
            tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
            tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel3, true, null);
            tableLayoutPanel4.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel4, true, null);
            tableLayoutPanel5.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel5, true, null);
            tableLayoutPanel6.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel6, true, null);
            tableLayoutPanel7.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel7, true, null);
            tableLayoutPanel8.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel8, true, null);
            tableLayoutPanel9.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel9, true, null);
            tableLayoutPanel10.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel10, true, null);            
            tableLayoutPanel16.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel16, true, null);
            tableLayoutPanel17.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel17, true, null);
            tableLayoutPanel18.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel18, true, null);
            tableLayoutPanel19.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel19, true, null);
            tableLayoutPanel20.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel20, true, null);
            tableLayoutPanel21.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel21, true, null);

        }
    }
}
