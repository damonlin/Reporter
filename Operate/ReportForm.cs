using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MainPage
{
    public partial class ReportForm : Common.Wizard.CCWizardForm
    {
        public ReportForm()
        {
            InitializeComponent();

            Controls.AddRange(new Control[] {		  
                new AutoMode.ReportPage1(),
                new AutoMode.ReportPage2()
                });
        }
    }
    

}
