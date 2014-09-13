using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Common.Wizard
{
    public partial class CCWizardPage : UserControl
    {
        #region Property
        protected CCWizardForm Wizard
        {
            get
            {
                // Return the parent WizardForm
                return (CCWizardForm)Parent.Parent;
            }
        }
        #endregion

        #region Ctor
        public CCWizardPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Protected Internal Methods
        protected internal virtual bool OnKillActive()
        {
            // Deactivate if validation successful
            return Validate();
        }
        protected internal virtual bool OnSetActive()
        {
            // Activate the page
            return true;
        }
        protected internal virtual string OnWizardBack()
        {
            // Move to the default previous page in the wizard
            return CCWizardForm.NextPage;
        }
        protected internal virtual bool OnWizardFinish()
        {
            // Finish the wizard
            return true;
        }
        protected internal virtual string OnWizardNext()
        {
            // Move to the default next page in the wizard
            return CCWizardForm.NextPage;
        }
        #endregion
    }
}
