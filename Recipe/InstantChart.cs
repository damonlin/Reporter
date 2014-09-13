using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.Template;
using System.Windows.Forms.DataVisualization;
using System.Threading;

namespace InstantChart
{
    public partial class InstantChartPanel : InfoPanelTemplate
    {
        private static InstantChartPanel singleton = null;
        private Random random = new Random();
        private int pointIndex = 0;
        private AutoMode.AutoModePanel m_AutoPanel = AutoMode.AutoModePanel.getSingleton();
        private int m_iScale = 1;
        private int m_iY1MaxValue = 1200;
        private int m_iY1MinValue = 0;
        private int m_iY2MaxValue = 1200;
        private int m_iY2MinValue = 0;

        public InstantChartPanel()
        {
            InitializeComponent();
        }

        public static InstantChartPanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new InstantChartPanel();
            }
            return singleton;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            ProcessChart(0, m_AutoPanel.GetLVG());
            ProcessChart(1, m_AutoPanel.GetHVG());
            ProcessChart(2, m_AutoPanel.GetPumping());
        }

        private void ProcessChart(int iSeriesIdx, string value)
        {
            int numberOfPointsInChart = 15;
            int numberOfPointsAfterRemoval = 15;

            //int newX = pointIndex + 1;
            int newY = random.Next(100, 1000);
           
            DateTime now = DateTime.Now;

            //chart.Series[iSeriesIdx].Points.AddXY(now.ToString("HH:mm:ss"), value);      
            m_Chart.Series[iSeriesIdx].Points.AddXY(now.ToString("HH:mm:ss"), newY.ToString());
       
            ++pointIndex;

            m_Chart.ResetAutoValues();
            if (m_Chart.ChartAreas["Default"].AxisX.Maximum < pointIndex)
            {
                m_Chart.ChartAreas["Default"].AxisX.Maximum = pointIndex;
            }

            // Keep a constant number of points by removing them from the left
            while (m_Chart.Series[iSeriesIdx].Points.Count > numberOfPointsInChart)
            {
                // Remove data points on the left side
                while (m_Chart.Series[iSeriesIdx].Points.Count > numberOfPointsAfterRemoval)
                {
                    m_Chart.Series[iSeriesIdx].Points.RemoveAt(0);
                }

                // Adjust X axis scale
                //m_LVGChart.ChartAreas["Default"].AxisX.Minimum = pointIndex - numberOfPointsAfterRemoval;
                //m_LVGChart.ChartAreas["Default"].AxisX.Maximum = m_LVGChart.ChartAreas["Default"].AxisX.Minimum + numberOfPointsInChart;
            }

            // Redraw chart
            m_Chart.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }    

        private void txtY1Max_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() != "\r")
                return;

            int iMaxValue = Convert.ToInt32(txtY1Max.Text);

            if (0 <= iMaxValue && iMaxValue <= 1200)
            {
                if (iMaxValue > Convert.ToInt32(txtY1Min.Text))
                {
                    m_Chart.ChartAreas["Default"].AxisY.Maximum = iMaxValue;
                    m_iY1MaxValue = iMaxValue;
                }
                else
                {
                    MessageBox.Show("請輸入大於 Y1 Min 的值");
                    txtY1Max.Text = m_iY1MaxValue.ToString();
                }
            }
            else
            {
                MessageBox.Show("請輸入 0 ~ 1200 的範圍");
                txtY1Max.Text = m_iY1MaxValue.ToString();
            }
        }

        private void txtY1Min_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() != "\r")
                return;

            int iMinValue = Convert.ToInt32(txtY1Min.Text);

            if (0 <= iMinValue && iMinValue <= 1200)
            {
                if (iMinValue < Convert.ToInt32(txtY1Max.Text))
                {
                    m_Chart.ChartAreas["Default"].AxisY.Minimum = iMinValue;
                    m_iY1MinValue = iMinValue;
                }
                else
                {
                    MessageBox.Show("請輸入小於 Y1 Max 的值");
                    txtY1Min.Text = m_iY1MinValue.ToString();
                }
            }
            else
            {
                MessageBox.Show("請輸入 0 ~ 1200 的範圍");
                txtY1Min.Text = m_iY1MinValue.ToString();
            }
        }

        private void txtY2Max_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() != "\r")
                return;

            int iMaxValue = Convert.ToInt32(txtY2Max.Text);

            if (0 <= iMaxValue && iMaxValue <= 1200)
            {
                if (iMaxValue > Convert.ToInt32(txtY2Min.Text))
                {
                    m_Chart.ChartAreas["Default"].AxisY2.Maximum = iMaxValue;
                    m_iY2MaxValue = iMaxValue;
                }
                else
                {
                    MessageBox.Show("請輸入大於 Y2 Min 的值");
                    txtY2Max.Text = m_iY2MaxValue.ToString();
                }
            }
            else
            {
                MessageBox.Show("請輸入 0 ~ 1200 的範圍");
                txtY2Max.Text = m_iY2MaxValue.ToString();
            }
        }

        private void txtY2Min_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() != "\r")
                return;

            int iMinValue = Convert.ToInt32(txtY2Min.Text);

            if (0 <= iMinValue && iMinValue <= 1200)
            {
                if (iMinValue < Convert.ToInt32(txtY2Max.Text))
                {
                    m_Chart.ChartAreas["Default"].AxisY.Minimum = iMinValue;
                    m_iY2MinValue = iMinValue;
                }
                else
                {
                    MessageBox.Show("請輸入小於 Y2 Max 的值");
                    txtY2Min.Text = m_iY2MinValue.ToString();
                }
            }
            else
            {
                MessageBox.Show("請輸入 0 ~ 1200 的範圍");
                txtY2Min.Text = m_iY2MinValue.ToString();
            }
        }

        private void btnScaleLarge_Click(object sender, EventArgs e)
        {
            m_iScale++;
            if (m_iScale >= 12)
                m_iScale = 12;

            m_Chart.ChartAreas["Default"].Axes[1].ScaleView.Zoom(0, 1200 / m_iScale);
        }

        private void btnScaleSmall_Click(object sender, EventArgs e)
        {
            m_iScale--;
            if (m_iScale <= 1)
                m_iScale = 1;

            m_Chart.ChartAreas["Default"].Axes[1].ScaleView.Zoom(0, 1200 / m_iScale);
        }
    }
}
