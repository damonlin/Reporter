using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using Common.Template;
using ContrelModule;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace AutoMode
{
    public partial class AutoModePanel : InfoPanelTemplate
    {
        private static AutoModePanel singleton = null;
        private ContrelModule.CPLCInterface m_PLCInterface = ContrelModule.CPLCInterface.GetSingleton();

        private Random random = new Random();
        private int pointIndex = 0;

        private bool bRVON = false;
        private bool bVVON = false;
        private bool bAuto = false;

        //private FileStream m_HVGFile = null;
        //private StreamWriter m_HVGWriter = null;

        private FileStream m_LVGFile = null;
        private StreamWriter m_LVGWriter = null;

        public AutoModePanel()
        {
            InitializeComponent();
           
            try
            {
                m_PLCInterface.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("[" + e.Message + "]" + " Can't Open : " + m_PLCInterface.PortNumber);
            }         
        }     

        public static AutoModePanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new AutoModePanel();
            }
            return singleton;
        }

        public string GetHVG()
        {
            return labelHVG.Text;
        }

        public string GetLVG()
        {
            return labelLVG.Text;
        }

        public string GetPumping()
        {
            return labelPumping.Text;
        }

        private void plcTimer_Tick(object sender, EventArgs e)
        {
            m_PLCInterface.PLCReadWord_D();

            CPLCInterface.PLCData data = m_PLCInterface.PLCRcvData;
            if (data != null )
            {
                if (data.m_DataType == CPLCInterface.DATA_TYPE.M_Type)
                {
                    bRVON = data.m_RcvData[0] == '1' ? false : true; // M2120
                    if (bRVON)
                        btnRVSwitch.BackColor = Color.Green;
                    else
                        btnRVSwitch.BackColor = Color.Red;

                    bVVON = data.m_RcvData[2] == '1' ? false : true; // M2122
                    if (bVVON)
                        btnVVSwitch.BackColor = Color.Green;
                    else
                        btnVVSwitch.BackColor = Color.Red;

                    bAuto = data.m_RcvData[4] == '1' ? true : false; // M2123
                    if (bAuto)
                    {
                        btnAuto.BackColor = Color.Green;
                        btnAuto.Enabled = false;

                        btnManual.BackColor = Color.Red;
                        btnManual.Enabled = true;
                    }
                    else
                    {
                        btnAuto.BackColor = Color.Red;
                        btnAuto.Enabled = true;

                        btnManual.BackColor = Color.Green;
                        btnManual.Enabled = false;
                    }
                }         
            }
            ProcessChart(m_LVGChart, labelLVG.Text);
            ProcessChart(m_HVGChart, labelHVG.Text);
        }

        private void ProcessChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, string value )
        {
            int numberOfPointsInChart = 7;
            int numberOfPointsAfterRemoval = 7;

            //int newX = pointIndex + 1;
            int newY = random.Next(100, 1000);
            
            DateTime now = DateTime.Now;
            //chart.Series[0].Points.AddXY(now.ToString("HH:mm:ss"), value);      
            chart.Series[0].Points.AddXY(now.ToString("HH:mm:ss"), newY.ToString());

            string path = System.Environment.CurrentDirectory + "\\History\\" + chart.Text + "\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
         
            FileStream myFile = File.Open(path + fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter myWriter = new StreamWriter(myFile);
            myWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + newY.ToString() + " " + txtID.Text);
            //myWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + value + " " + txtID.Text);
            myWriter.Dispose();
            myFile.Dispose();

            ++pointIndex;

            chart.ResetAutoValues();
            if (chart.ChartAreas["Default"].AxisX.Maximum < pointIndex)
            {
                chart.ChartAreas["Default"].AxisX.Maximum = pointIndex;
            }

            // Keep a constant number of points by removing them from the left
            while (chart.Series[0].Points.Count > numberOfPointsInChart)
            {
                // Remove data points on the left side
                while (chart.Series[0].Points.Count > numberOfPointsAfterRemoval)
                {
                    chart.Series[0].Points.RemoveAt(0);
                }

                // Adjust X axis scale
                //m_LVGChart.ChartAreas["Default"].AxisX.Minimum = pointIndex - numberOfPointsAfterRemoval;
                //m_LVGChart.ChartAreas["Default"].AxisX.Maximum = m_LVGChart.ChartAreas["Default"].AxisX.Minimum + numberOfPointsInChart;
            }

            // Redraw chart
            chart.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //m_PLCInterface.PLCWriteWord_D("aa");
            //ConvertToTorr("AB12");
        }     

        private string ConvertToTorr(string value)
        {            
            double voltage = Convert.ToInt32(value,16) * 0.005;
            return Math.Round(Math.Pow(10, voltage - 5.625), 3).ToString("E2");
        }
      
        private void btnRVSwitch_Click(object sender, EventArgs e)
        {
            if (bAuto)
            {
                MessageBox.Show("叫ち传 Manual 家Α");
                return;
            }

            ConfirmDialog dlg = new ConfirmDialog(bRVON);
            DialogResult retval = dlg.ShowDialog();
            bRVON = dlg.ON;
            m_PLCInterface.PLCWriteBit_M("M2020", 2, bRVON);
        }

        private void btnVVSwitch_Click(object sender, EventArgs e)
        {
            if (bAuto)
            {
                MessageBox.Show("叫ち传 Manual 家Α");
                return;
            }

            ConfirmDialog dlg = new ConfirmDialog(bVVON);
            DialogResult retval = dlg.ShowDialog();
            bVVON = dlg.ON;
            m_PLCInterface.PLCWriteBit_M("M2022", 2, bVVON);
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {            
            bAuto = !bAuto;

            if (bAuto)
            {
                btnAuto.BackColor = Color.Green;
                btnAuto.Enabled = false;

                btnManual.BackColor = Color.Red;
                btnManual.Enabled = true;
            }
            else
            {
                btnAuto.BackColor = Color.Red;
                btnAuto.Enabled = true;

                btnManual.BackColor = Color.Green;
                btnManual.Enabled = false;
            }

            m_PLCInterface.PLCWriteBit_M("M2000", 2, bAuto);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //m_PLCInterface.PLCReadWord_D();
            m_PLCInterface.PLCReadBit_M();

            CPLCInterface.PLCData data = m_PLCInterface.PLCRcvData;
            if (data == null)
                return;
            
            if (data.m_DataType == CPLCInterface.DATA_TYPE.D_Type)
                {
                    int aa = Convert.ToInt32(data.m_RcvData.Substring(0, 4), 16);
                    double tmp = (double)aa / 10.0; // D1616
                    labelPumping.Text = tmp.ToString("0.0");

                    labelCycle.Text = Convert.ToInt32(data.m_RcvData.Substring(4, 4), 16).ToString(); // D1617

                    labelLVG.Text = ConvertToTorr(data.m_RcvData.Substring(8, 4));  // D1618
                    labelHVG.Text = ConvertToTorr(data.m_RcvData.Substring(12, 4)); // D1619             
                }
        }
    }
}
