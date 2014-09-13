using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Common.Template
{
    public partial class InfoPanelTemplate : UserControl
    {
        public InfoPanelTemplate()
        {
            InitializeComponent();
        }

        public virtual int LoadParaFromINI(string strIniPath)
        {
            return 0;
        }

        public virtual int SaveParaToINI(string strIniPath)
        {
            return 0;
        }

        public virtual int GetParaFromUI()
        {
            return 0;
        }

        public virtual int SetParaToUI()
        {
            return 0;
        }

        public void Auth()
        {

        }

        public void InitPanel()
        {            
        }

        private void InfoPanelTemplate_DragEnter(object sender, DragEventArgs e)
        {
            if (this.AllowDrop)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void InfoPanelTemplate_DragDrop(object sender, DragEventArgs e)
        {
            if (this.AllowDrop)
            {
                Control DragControl = (Control)e.Data.GetData(e.Data.GetFormats()[0]);
                DragControl.Location = this.PointToClient(new Point(e.X, e.Y));
            }
        }
    }
}
