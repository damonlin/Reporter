using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Printing;

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
    public partial class CCWizardForm : Common.Template.InfoPanelTemplate
    {        
        #region Public Member
        public const string NextPage = "";
        public const string NoPageChange = null;
        #endregion

        #region Private Member
        private ArrayList m_pages = new ArrayList();
        private int m_selectedIndex = -1;

        // for Printing
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap[] memoryImage = new Bitmap[5];
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();
        private PageSetupDialog dlgPageSetup = new PageSetupDialog();       
        #endregion

        #region Ctor
        public CCWizardForm()
        {
            InitializeComponent();

            // Ensure Finish and Next buttons are positioned similarly
            m_finishButton.Location = m_nextButton.Location;

            printDocument1.PrintPage += new PrintPageEventHandler(PD_PrintPage);
            dlgPageSetup.Document = printDocument1;            
        }
        #endregion

        #region Private Method
        void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            //float leftMargin = (e.MarginBounds.Left) * 3 / 4;　 //左邊距
            //float topMargin = e.MarginBounds.Top * 2 / 3;　　　 //頂邊距
            //float verticalPosition = topMargin;　　　　　　　　 //初始化垂直位置，設為頂邊距
            //Font mainFont = new Font("Courier New", 10);//列印的字體

            ////每頁的行數，當列印行數超過這個時，要換頁(1.05這個值是根據實際情況中設定的，可以不要)
            //int linesPerPage = (int)(e.MarginBounds.Height * 1.05 / mainFont.GetHeight(e.Graphics));

            //e.HasMorePages = true;
            //for (int iIdx = 0; iIdx < m_pages.Count; ++iIdx)
            {
                e.Graphics.DrawImage(memoryImage[m_selectedIndex], 50, 50);
                //if (iIdx == m_pages.Count)
                //    e.HasMorePages = false;
            }
            
        }
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.panel1.Size;

            memoryImage[m_selectedIndex] = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage[m_selectedIndex]);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }

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
                CaptureScreen();

                //設定印A4的一半 直式
                printDocument1.DefaultPageSettings.Landscape = true;
                PaperSize ps =new PaperSize("A4",// 595, 842
                                            this.printDocument1.DefaultPageSettings.PaperSize.Width,
                                            this.printDocument1.DefaultPageSettings.PaperSize.Height);
                ps.RawKind = 9;
                printDocument1.DefaultPageSettings.PaperSize = ps;                             

                printPreviewDialog1.Document = printDocument1;
                dlgPageSetup.Document = printDocument1;
                dlgPageSetup.ShowDialog();
                printPreviewDialog1.ShowDialog();
                

                //// Inform selected page that the Finish button was clicked
                //CCWizardPage page = (CCWizardPage)m_pages[m_selectedIndex];
                //if (page.OnWizardFinish())
                //{
                //    // Deactivate page and close wizard
                //    //if (page.OnKillActive())
                //    //    DialogResult = DialogResult.OK;

                //}
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
