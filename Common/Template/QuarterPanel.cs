using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.Template
{
    public partial class QuarterPanel : Form
    {
        //取得螢幕解析度
        private int m_iScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        private int m_iScreenHeight = Screen.PrimaryScreen.Bounds.Height;

        //取得子視窗的Size變數
        private int m_iSubPanelWidth;
        private int m_iSubPanelHeight;

        //判斷視窗是否在桌面上
        private bool m_bShowTable = false;

        public QuarterPanel()
        {
            InitializeComponent();

            //程式啟動時先將父視窗的Size指定給子視窗的屬性
            SubWidth = this.Size.Width;
            SubHeight = this.Size.Height;
        }

        private void QuarterPanel_Move(object sender, EventArgs e)
        {
            int iWidth = this.Location.X;
            int iHeight = this.Location.Y;

            //當Control移動超出螢幕四邊時，至少在螢幕內保持二分之一
            if (this.Location.X < (0 - SubWidth / 2))
            {
                this.Location = new Point((0 - SubWidth / 2), iHeight);
            }
            else if (this.Location.X > (m_iScreenWidth - SubWidth / 2))
            {
                this.Location = new Point((m_iScreenWidth - SubWidth / 2), iHeight);
            }
            else if (this.Location.Y < (0 - SubHeight / 2))
            {
                this.Location = new Point(iWidth, (0 - m_iScreenHeight - SubHeight / 2));
            }
            else if (this.Location.Y > (m_iScreenHeight - SubHeight / 2))
            {
                this.Location = new Point(iWidth, (m_iScreenHeight - SubHeight / 2));
            }

            //當Control移動超出螢幕最右下角時，至少在螢幕內保持四分之一
            if ((this.Location.X > (m_iScreenWidth - SubWidth / 2)) && (this.Location.Y > (m_iScreenHeight - SubHeight / 2)))
            {
                this.Location = new Point(((m_iScreenWidth - SubWidth / 2)), ((m_iScreenHeight - SubHeight / 2)));
            }
        }

        //取得子視窗的Size屬性
        private int SubWidth
        {
            set
            {
                m_iSubPanelWidth = value;
            }
            get
            {
                return m_iSubPanelWidth;
            }
        }

        //取得子視窗的Size屬性
        private int SubHeight
        {
            set
            {
                m_iSubPanelHeight = value;
            }
            get
            {
                return m_iSubPanelHeight;
            }
        }

        private void QuarterPanel_SizeChanged(object sender, EventArgs e)
        {
            //當父視窗的Size變更時，就將父視窗的Size指定給子視窗(父視窗->子視窗)
            SubWidth = this.Size.Width;
            SubHeight = this.Size.Height;
        }

        //Show出視窗屬性
        public bool GetShowStatus
        {
            set
            {
                m_bShowTable = value;
            }
            get
            {
                return m_bShowTable;
            }
        }
    }
}