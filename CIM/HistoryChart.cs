using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.Template;
using ContrelModule;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace HistoryChart
{
    public partial class HistoryChartPanel : InfoPanelTemplate
    {
        private static HistoryChartPanel singleton = null;
        private List<string> m_LVGData = new List<string>();
        private List<string> m_HVGData = new List<string>();
        private int MAX_POINT = 20;
        private int m_iPointPage = 0;
        private int m_iScale = 1;
        private int m_iMaxValue = 1200;
        private int m_iMinValue = 0;

        public HistoryChartPanel()
        {
            InitializeComponent();            
        }

        public static HistoryChartPanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new HistoryChartPanel();
            }
            return singleton;
        }

        private void LoadLVGData()
        {
            string filename = dateTimePickerStart.Value.Year.ToString() + "_" +
                              dateTimePickerStart.Value.Month.ToString("D2") + "_" +
                              dateTimePickerStart.Value.Day.ToString("D2") + ".txt";

            string LVGpath = System.Environment.CurrentDirectory + "\\History\\LVG\\";

            foreach (string line in File.ReadLines(LVGpath + filename))
            {
                string[] arr = line.Split(null);

                DateTime dt = Convert.ToDateTime(arr[0]);
                DateTime startTime = Convert.ToDateTime(numberStartHour.Value.ToString() + ":" + numberStartMin.Value.ToString());
                DateTime endTime = Convert.ToDateTime(numberEndHour.Value.ToString() + ":" + numberEndMin.Value.ToString());

                if (DateTime.Compare(dt, startTime) >= 0 && DateTime.Compare(dt, endTime) <= 0)
                {
                    m_LVGData.Add(line);
                }
            }
        }

        private void LoadHVGData()
        {
            string filename = dateTimePickerStart.Value.Year.ToString() + "_" +
                              dateTimePickerStart.Value.Month.ToString("D2") + "_" +
                              dateTimePickerStart.Value.Day.ToString("D2") + ".txt";

            string LVGpath = System.Environment.CurrentDirectory + "\\History\\HVG\\";

            foreach (string line in File.ReadLines(LVGpath + filename))
            {
                string[] arr = line.Split(null);

                DateTime dt = Convert.ToDateTime(arr[0]);
                DateTime startTime = Convert.ToDateTime(numberStartHour.Value.ToString() + ":" + numberStartMin.Value.ToString());
                DateTime endTime = Convert.ToDateTime(numberEndHour.Value.ToString() + ":" + numberEndMin.Value.ToString());

                if (DateTime.Compare(dt, startTime) >= 0 && DateTime.Compare(dt, endTime) <= 0)
                {
                    m_HVGData.Add(line);
                }
            }
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            m_Chart.Series[0].Points.Clear();
            m_Chart.Series[1].Points.Clear();

            m_HVGData.Clear();
            m_LVGData.Clear();

            LoadLVGData();
            LoadHVGData();

            UpdateChart();
        }

        private void chkScientific_Click(object sender, EventArgs e)
        {
            //if (chkScientific.Checked)
            //{
            //    m_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "0.00E+00";                
            //}
            //else
            //{
            //    m_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "";
            //}
        }

        private void UpdateChart()
        {
            m_Chart.Series[0].Points.Clear();
            m_Chart.Series[1].Points.Clear();

            //if ( m_iPonitPage * MAX_POINT > m_LVGData )
            //{
            //    MessageBox.Show("搜尋不到");
            //    return;
            //}                       
            for (int iIdx = m_iPointPage * MAX_POINT; iIdx < m_iPointPage * MAX_POINT+MAX_POINT; ++iIdx)
            {
                if (iIdx >= m_LVGData.Count)
                    continue;

                string[] arr = m_LVGData[iIdx].Split(null);
                m_Chart.Series[0].Points.AddXY(arr[0], arr[1]);
            }

            for (int iIdx = m_iPointPage * MAX_POINT; iIdx < m_iPointPage * MAX_POINT + MAX_POINT; ++iIdx)
            {
                if (iIdx >= m_HVGData.Count)
                    continue;

                string[] arr = m_HVGData[iIdx].Split(null);
                m_Chart.Series[1].Points.AddXY(arr[0], arr[1]);
            }
         
            m_Chart.Invalidate();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {           
            m_iPointPage = 0;
            UpdateChart();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            m_iPointPage++;
            if (m_iPointPage >= m_LVGData.Count / MAX_POINT)
                m_iPointPage = m_LVGData.Count / MAX_POINT;
            UpdateChart();
        }

        private void btnPrevioustPage_Click(object sender, EventArgs e)
        {            
            m_iPointPage--;
            if (m_iPointPage <= 0)
                m_iPointPage = 0;
            UpdateChart();
        }     
       
        private void btnNext5Page_Click(object sender, EventArgs e)
        {
            m_iPointPage += 5;
            if (m_iPointPage >= m_LVGData.Count / MAX_POINT)
                m_iPointPage = m_LVGData.Count / MAX_POINT;
            UpdateChart();
        }

        private void btnLast5Page_Click(object sender, EventArgs e)
        {         
            m_iPointPage -= 5;
            if (m_iPointPage <= 0)
                m_iPointPage = 0;

            UpdateChart();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            m_iPointPage = m_LVGData.Count / MAX_POINT;
            UpdateChart();
        }

        private void btnScaleLarge_Click(object sender, EventArgs e)
        {            
            m_iScale++;
            if (m_iScale >= 12)
                m_iScale = 12;
           
            m_Chart.ChartAreas["Default"].Axes[1].ScaleView.Zoom( 0 , 1200/m_iScale);
        }

        private void btnScaleSmall_Click(object sender, EventArgs e)
        {
            m_iScale--;
            if (m_iScale <= 1)
                m_iScale = 1;

            m_Chart.ChartAreas["Default"].Axes[1].ScaleView.Zoom(0, 1200 / m_iScale);            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }



        private void chkScientific_CheckedChanged(object sender, EventArgs e)
        {
            if (chkScientific.Checked)
            {
                m_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "0.00E+00";
            }
            else
            {
                m_Chart.ChartAreas[0].AxisY.LabelStyle.Format = "";
            }
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() != "\r")
                return;

            int iMaxValue = Convert.ToInt32(txtMax.Text);

            if (0 <= iMaxValue && iMaxValue <= 1200)
            {
                if (iMaxValue > Convert.ToInt32(txtMin.Text))
                {
                    m_Chart.ChartAreas["Default"].AxisY.Maximum = iMaxValue;
                    m_iMaxValue = iMaxValue;
                }
                else
                {
                    MessageBox.Show("請輸入大於 Y Axis Min 的值");
                    txtMax.Text = m_iMaxValue.ToString();
                }
            }
            else
            {
                MessageBox.Show("請輸入 0 ~ 1200 的範圍");
                txtMax.Text = m_iMaxValue.ToString();
            }
        }

        private void txtMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() != "\r")
                return;

            int iMinValue = Convert.ToInt32(txtMin.Text);

            if (0 <= iMinValue && iMinValue <= 1200)
            {
                if (iMinValue < Convert.ToInt32(txtMax.Text))
                {
                    m_Chart.ChartAreas["Default"].AxisY.Minimum = iMinValue;
                    m_iMinValue = iMinValue;
                }
                else
                {
                    MessageBox.Show("請輸入小於 Y Axis Max 的值");
                    txtMin.Text = m_iMinValue.ToString();
                }
            }
            else
            {
                MessageBox.Show("請輸入 0 ~ 1200 的範圍");
                txtMin.Text = m_iMinValue.ToString();
            }
        }       
    }
}
