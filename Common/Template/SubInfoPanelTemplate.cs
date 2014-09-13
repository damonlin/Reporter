using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Common.Template
{
    public partial class SubInfoPanelTemplate : InfoPanelTemplate
    {
        //父視窗尺寸變數
        private double m_iBasePanelSizeWidth = 0.0;
        private double m_iBasePanelSizeHeight = 0.0;
        //計算子視窗變大或縮小的比例變數
        private double iWidthPercentage = 0.0, iHeightPercentage = 0.0;

        private DPI systemDPI = DPI._1024_768_;

        public SubInfoPanelTemplate()
        {
            InitializeComponent();

            this.AutoSize = false;

            //先取得父視窗的尺寸
            m_iBasePanelSizeWidth = System.Convert.ToDouble(this.Size.Width);
            m_iBasePanelSizeHeight = System.Convert.ToDouble(this.Size.Height);
        }

        private void SubInfoPanelTemplate_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void SubInfoPanelTemplate_DragDrop(object sender, DragEventArgs e)
        {
            if (this.AllowDrop)
            {
                Control DragControl = (Control)e.Data.GetData(e.Data.GetFormats()[0]);
                DragControl.Location = this.PointToClient(new Point(e.X, e.Y));
            }
        }

        private void SubInfoPanelTemplate_SizeChanged(object sender, EventArgs e)
        {

            bool bSizeChange = false;

            //子視窗寬度變窄
            if (((UserControl)sender).Size.Width < m_iBasePanelSizeWidth)
            {
                iWidthPercentage = 1.00000 + ((((UserControl)sender).Size.Width - m_iBasePanelSizeWidth) / m_iBasePanelSizeWidth);
                bSizeChange = true;
            }
            //子視窗寬度變寬
            else if (((UserControl)sender).Size.Width > m_iBasePanelSizeWidth)
            {
                iWidthPercentage = 1.00000 + ((((UserControl)sender).Size.Width - m_iBasePanelSizeWidth) / m_iBasePanelSizeWidth);
                bSizeChange = true;
            }
            else iWidthPercentage = 1;

            //子視窗高度變矮
            if (((UserControl)sender).Size.Height < m_iBasePanelSizeHeight)
            {
                iHeightPercentage = 1.00000 + ((((UserControl)sender).Size.Height - m_iBasePanelSizeHeight) / m_iBasePanelSizeHeight);
                //bSizeChange = true;
            }
            //子視窗高度變高
            else if (((UserControl)sender).Size.Height > m_iBasePanelSizeHeight)
            {
                iHeightPercentage = 1.00000 + ((((UserControl)sender).Size.Height - m_iBasePanelSizeHeight) / m_iBasePanelSizeHeight);
                //bSizeChange = true;
            }
            else
            {
                iHeightPercentage = 1;
            }

            m_iBasePanelSizeWidth = ((UserControl)sender).Size.Width;
            m_iBasePanelSizeHeight = ((UserControl)sender).Size.Height;

            if (bSizeChange)
            {
                SubInfoPanelTemplate_FixControlSize((UserControl)sender);
            }

        }

        private void SubInfoPanelTemplate_FixControlSize(Control p_ParentControl)
        {
            foreach (Control NowControl in p_ParentControl.Controls)
            {
                if(NowControl is Panel || NowControl is UserControl)
                {
                    SubInfoPanelTemplate_FixControlSize(NowControl);
                }

                //重新配置子視窗內的元件尺寸和位置
                NowControl.Size = new Size(System.Convert.ToInt32(NowControl.Size.Width * iWidthPercentage), System.Convert.ToInt32(NowControl.Size.Height * iHeightPercentage));
                NowControl.Location = new Point(System.Convert.ToInt32(NowControl.Location.X * iWidthPercentage), System.Convert.ToInt32(NowControl.Location.Y * iHeightPercentage));

                //再重新配置子視窗內的子視窗元件尺寸和位置
                try
                {
                    foreach (Control subNowSize in NowControl.Controls)
                    {
                        subNowSize.Size = new Size(System.Convert.ToInt32(subNowSize.Size.Width * iWidthPercentage), System.Convert.ToInt32(subNowSize.Size.Height * iHeightPercentage));
                        subNowSize.Location = new Point(System.Convert.ToInt32(subNowSize.Location.X * iWidthPercentage), System.Convert.ToInt32(subNowSize.Location.Y * iHeightPercentage));
                        subNowSize.Font = new Font(subNowSize.Font.Name, subNowSize.Font.Size * (float)iWidthPercentage);
                    }
                }
                catch (Exception ex)
                {
                }

            }
        }
        
        public DPI SystemDPI
        {
            get { return systemDPI; }
            set
            {
                systemDPI = value;
                
                switch (systemDPI)
                {
                    case DPI._1024_768_:
                        this.Size = new Size(889 + 2, 812 + 2);
                        break;

                    case DPI._1280_1024_:
                        this.Size = new Size(1111 + 2, 1068 + 2);
                        break;
                }
            }
        }
    }

    public enum DPI
    {
        _1024_768_ = 0, 
        _1280_1024_ = 1
    }
}
