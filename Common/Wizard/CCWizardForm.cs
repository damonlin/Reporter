using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Common.Wizard
{    
    [Flags]
    public enum WizardButton
    {
        Back = 0x00000001,
        Next = 0x00000002,        
        Finish = 0x00000004,
        DisabledFinish = 0x00000008,
    }
    public partial class CCWizardForm : Common.Template.SubInfoPanelTemplate
    {
        #region Public Member
        public const string NextPage = "";
        public const string NoPageChange = null;
        #endregion

        #region Private Member
        private ArrayList m_pages = new ArrayList();
        private int m_selectedIndex = -1;
        #endregion

        #region Ctor
        public CCWizardForm()
        {
            InitializeComponent();

            // Ensure Finish and Next buttons are positioned similarly
            m_finishButton.Location = m_nextButton.Location;            
        }
        #endregion

        #region Private Method
        private void ActivatePage(int newIndex)
        {
            // Ensure the index is valid
            if (newIndex < 0 || newIndex >= m_pages.Count)
                throw new ArgumentOutOfRangeException();

            // Deactivate the current page if applicable
            CCWizardPage currentPage = null;
            if (m_selectedIndex != -1)
            {
                currentPage = (CCWizardPage)m_pages[m_selectedIndex];
                if (!currentPage.OnKillActive())
                    return;
            }

            // Activate the new page
            CCWizardPage newPage = (CCWizardPage)m_pages[newIndex];
            if (!newPage.OnSetActive())
                return;

            // Update state
            m_selectedIndex = newIndex;
            if (currentPage != null)
                currentPage.Visible = false;
            newPage.Visible = true;
            newPage.Focus();
        }        

        private void OnClickBack(object sender, EventArgs e)
        {
            // Ensure a page is currently selected
            if (m_selectedIndex != -1)
            {
                // Inform selected page that the Back button was clicked
                string pageName = ((CCWizardPage)m_pages[
                    m_selectedIndex]).OnWizardBack();
                switch (pageName)
                {
                    // Do nothing
                    case NoPageChange:
                        break;

                    // Activate the next appropriate page
                    case NextPage:
                        if (m_selectedIndex - 1 >= 0)
                            ActivatePage(m_selectedIndex - 1);
                        break;

                    // Activate the specified page if it exists
                    default:
                        foreach (CCWizardPage page in m_pages)
                        {
                            if (page.Name == pageName)
                                ActivatePage(m_pages.IndexOf(page));
                        }
                        break;
                }
            }
        }

        private void OnClickNext(object sender, EventArgs e)
        {
            // Ensure a page is currently selected
            if (m_selectedIndex != -1)
            {
                // Inform selected page that the Next button was clicked
                string pageName = ((CCWizardPage)m_pages[
                    m_selectedIndex]).OnWizardNext();
                switch (pageName)
                {
                    // Do nothing
                    case NoPageChange:
                        break;

                    // Activate the next appropriate page
                    case NextPage:
                        if (m_selectedIndex + 1 < m_pages.Count)
                            ActivatePage(m_selectedIndex + 1);
                        break;

                    // Activate the specified page if it exists
                    default:
                        foreach (CCWizardPage page in m_pages)
                        {
                            if (page.Name == pageName)
                                ActivatePage(m_pages.IndexOf(page));
                        }
                        break;
                }
            }
        }

        private void OnClickCancel(object sender, EventArgs e)
        {
        
        }

        private void OnClickFinish(object sender, EventArgs e)
        {
            // Ensure a page is currently selected
            if (m_selectedIndex != -1)
            {
                // Inform selected page that the Finish button was clicked
                CCWizardPage page = (CCWizardPage)m_pages[m_selectedIndex];
                if (page.OnWizardFinish())
                {
                    // Deactivate page and close wizard
                    //if (page.OnKillActive())
                    //    DialogResult = DialogResult.OK;
                }
            }
        }

        #endregion

        #region Protected Method
        protected override void OnControlAdded(ControlEventArgs e)
        {
            // Invoke base class implementation
            base.OnControlAdded(e);

            // Set default properties for all WizardPage instances added to
            // this form
            CCWizardPage page = e.Control as CCWizardPage;
            if (page != null)
            {
                page.Visible = false;
                page.Location = this.Location;
                //page.Size = new Size(Width, m_separator.Location.Y);
                page.Dock = DockStyle.Fill;

                panel1.Controls.Add(page);

                m_pages.Add(page);
                if (m_selectedIndex == -1)
                    m_selectedIndex = 0;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            // Invoke base class implementation
            base.OnLoad(e);

            // Activate the first page in the wizard
            if (m_pages.Count > 0)
                ActivatePage(0);
        }

        #endregion

        #region Public Method
        public void SetFinishText(string text)
        {
            // Set the Finish button text
            m_finishButton.Text = text;
        }

        public void SetWizardButtons(WizardButton flags)
        {
            // Enable/disable and show/hide buttons appropriately
            m_backButton.Enabled =
                (flags & WizardButton.Back) == WizardButton.Back;
            m_nextButton.Enabled =
                (flags & WizardButton.Next) == WizardButton.Next;
            m_nextButton.Visible =
                (flags & WizardButton.Finish) == 0 &&
                (flags & WizardButton.DisabledFinish) == 0;
            m_finishButton.Enabled =
                (flags & WizardButton.DisabledFinish) == 0;
            m_finishButton.Visible =
                (flags & WizardButton.Finish) == WizardButton.Finish ||
                (flags & WizardButton.DisabledFinish) == WizardButton.DisabledFinish;
        }
        #endregion
    }
}
