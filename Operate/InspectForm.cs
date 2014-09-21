using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MainPage
{
    public partial class InspectForm : Common.Wizard.CCWizardForm
    {
        public InspectForm()
        {
            InitializeComponent();

            Controls.AddRange(new Control[] {		  
                new AutoMode.InspectPage1(),
                new AutoMode.InspectPage2(),
                new AutoMode.InspectPage3()
		        });
        }
    }
    

}
