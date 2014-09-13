using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.Template;

namespace PrintScreen
{
    public partial class PrintScreenPanel : InfoPanelTemplate
    {
        private static PrintScreenPanel singleton = null;

        public PrintScreenPanel()
        {
            InitializeComponent();
        }

        public static PrintScreenPanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new PrintScreenPanel();
            }
            return singleton;
        }     
    }
}
