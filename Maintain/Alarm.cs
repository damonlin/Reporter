using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.Template;
using System.IO.Ports;

namespace Alarm
{
    public partial class AlarmPanel : InfoPanelTemplate
    {
        private static AlarmPanel singleton = null;
              
        public static AlarmPanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new AlarmPanel();
            }
            return singleton;
        }     

        #region Ctor
        public AlarmPanel()
        {
            AlarmPanel();            
        }
        #endregion
    }
}
