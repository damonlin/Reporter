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
        //���o�ù��ѪR��
        private int m_iScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        private int m_iScreenHeight = Screen.PrimaryScreen.Bounds.Height;

        //���o�l������Size�ܼ�
        private int m_iSubPanelWidth;
        private int m_iSubPanelHeight;

        //�P�_�����O�_�b�ୱ�W
        private bool m_bShowTable = false;

        public QuarterPanel()
        {
            InitializeComponent();

            //�{���Ұʮɥ��N��������Size���w���l�������ݩ�
            SubWidth = this.Size.Width;
            SubHeight = this.Size.Height;
        }

        private void QuarterPanel_Move(object sender, EventArgs e)
        {
            int iWidth = this.Location.X;
            int iHeight = this.Location.Y;

            //��Control���ʶW�X�ù��|��ɡA�ܤ֦b�ù����O���G�����@
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

            //��Control���ʶW�X�ù��̥k�U���ɡA�ܤ֦b�ù����O���|�����@
            if ((this.Location.X > (m_iScreenWidth - SubWidth / 2)) && (this.Location.Y > (m_iScreenHeight - SubHeight / 2)))
            {
                this.Location = new Point(((m_iScreenWidth - SubWidth / 2)), ((m_iScreenHeight - SubHeight / 2)));
            }
        }

        //���o�l������Size�ݩ�
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

        //���o�l������Size�ݩ�
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
            //���������Size�ܧ�ɡA�N�N��������Size���w���l����(������->�l����)
            SubWidth = this.Size.Width;
            SubHeight = this.Size.Height;
        }

        //Show�X�����ݩ�
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