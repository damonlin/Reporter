using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.Template;
using System.IO.Ports;

namespace PrintScreen
{
    public partial class PrintScreenPanel : InfoPanelTemplate
    {
        private static PrintScreenPanel singleton = null;
              
        public static PrintScreenPanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new PrintScreenPanel();
            }
            return singleton;
        }     

        #region Ctor
        public PrintScreenPanel()
        {
            InitializeComponent();            
        }
        #endregion
    }
}
