using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.Template;
using System.IO.Ports;

namespace InstantChart
{
    public partial class InstantChartPanel : InfoPanelTemplate
    {
        private static InstantChartPanel singleton = null;
              
        public static InstantChartPanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new InstantChartPanel();
            }
            return singleton;
        }     

        #region Ctor
        public InstantChartPanel()
        {
            InitializeComponent();            
        }
        #endregion
    }
}
