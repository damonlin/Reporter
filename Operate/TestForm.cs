using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MainPage
{
    public partial class TestForm : Common.Wizard.CCWizardForm
    {
        public TestForm()
        {
            InitializeComponent();

            Controls.AddRange(new Control[] {		  
                new AutoMode.TestPage1(),
                new AutoMode.TestPage2()
		        });
        }
    }
    

}
