using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.Template;
using System.IO.Ports;

namespace MainPage
{
    public partial class MainPagePanel : Common.Wizard.CCWizardForm
    {
        private static MainPagePanel singleton = null;
              
        public static MainPagePanel getSingleton()
        {
            if (singleton == null)
            {
                singleton = new MainPagePanel();
            }
            return singleton;
        }     

        #region Ctor
        public MainPagePanel()
        {
            InitializeComponent();

            Controls.AddRange(new Control[] {		  
                
                new AutoMode.InspectPage1(),
                new AutoMode.InspectPage1()
		        });
        }
        #endregion
    }
}
