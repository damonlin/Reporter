using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.Template;
using System.IO.Ports;

namespace HistoryChart
{
    public partial class HistoryChartPanel : InfoPanelTemplate
    {
        private static HistoryChartPanel singleton = null;
              
        public static HistoryChartPanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new HistoryChartPanel();
            }
            return singleton;
        }     

        #region Ctor
        public HistoryChartPanel()
        {
            InitializeComponent();            
        }
        #endregion
    }
}
