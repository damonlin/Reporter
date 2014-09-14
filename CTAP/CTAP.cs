using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.IO;
using ContrelModule;

namespace Monitor
{
    public partial class CTAP : Form
    {
        public static CTAP singleton = null;
        private Dictionary<string, Control> navigationHashtable = new Dictionary<string, Control>();
        private string szNavigationString = "";
        
        public CTAP()
        {
            Thread th = new Thread(new ThreadStart(ShowLoadingForm));
            th.Start();

            //AlarmList.AlarmReportForm.getSingleton();
                        
            InitializeComponent();
            InitControl();
            
            SearchControl(this);           
            this.BringToFront();
            th.Abort();
        }

        public static CTAP getSingleton()
        {
            if (singleton == null)
            {
                if (MainPage.UserLoginForm.getSingleton().ShowDialog() != DialogResult.Abort)
                    singleton = new CTAP();
            }
            return singleton;
        }

        private void ShowLoadingForm()
        {
            LoadingForm objLoadingForm = new LoadingForm();
            objLoadingForm.ShowDialog();
        }

        private void InitControl()
        {                        
            //Common.Template.InfoPanelTemplate mainPagePanel = MainPage.MainPagePanel.getSingleton();
            Common.Template.InfoPanelTemplate mainPagePanel = new MainPage.InspectForm();
            Common.Template.InfoPanelTemplate ParaPanel = new Parameter.ParameterPanel();
            Common.Template.InfoPanelTemplate instantchartPanel = new InstantChart.InstantChartPanel();
            Common.Template.InfoPanelTemplate historychartPanel = new HistoryChart.HistoryChartPanel();
            Common.Template.InfoPanelTemplate userAccountPanel = MainPage.UserAccountPanelControl.getSingleton();
            

            navigationHashtable.Clear();

            navigationHashtable.Add("AutoMode", mainPagePanel);
            navigationHashtable.Add("Parameter", ParaPanel);
            navigationHashtable.Add("InstantChart", instantchartPanel);
            navigationHashtable.Add("HistoryChart", historychartPanel);
            navigationHashtable.Add("Alarm", userAccountPanel);
            

            foreach (string de in navigationHashtable.Keys)
            {
                navigationHashtable[de].Dock = System.Windows.Forms.DockStyle.Fill;
                navigationHashtable[de].Location = new System.Drawing.Point(0, 0);
                navigationHashtable[de].Name = "CTAP" + de.ToString();
                navigationHashtable[de].Tag = "";
                navigationHashtable[de].Visible = false;

                if (navigationHashtable[de] is Common.Template.InfoPanelTemplate)
                {
                    ((Common.Template.InfoPanelTemplate)navigationHashtable[de]).InitPanel();
                }

                viewPanel.Controls.Add(navigationHashtable[de]);
            }                            
        }

        private void baseTimer_Tick(object sender, EventArgs e)
        {
            if (singleton != null)
            {
                displayDateLabel.Text = DateTime.Now.ToLongDateString();
                displayTimeLabel.Text = DateTime.Now.ToLongTimeString();               
            }
        }

        private void navigatorBtn_CheckedChanged(object sender, EventArgs e)
        {
            // 顯示對應的畫面
            foreach (string de in navigationHashtable.Keys)
            {
                (navigationHashtable[de]).Visible = ((RadioButton)sender).Name.Contains((string)de) ? true : false;
                if (navigationHashtable[de].Visible == true)
                {
                    szNavigationString = de;
                }
            }
            btnDecPanel.Location = new Point(((RadioButton)sender).Location.X + ((RadioButton)sender).Size.Width / 2 - btnDecPanel.Size.Width / 2, btnDecPanel.Location.Y);
        }

        private void functionBtn_CheckedChanged(object sender, EventArgs e)
        {/*
            if (sender == ioMonitorButton)
            {
                if (Monitor.IOMonitorForm.getSingleton(ref sender).Visible == false)
                    Monitor.IOMonitorForm.getSingleton(ref sender).Show(this);
                else
                    Monitor.IOMonitorForm.getSingleton(ref sender).Activate();
            }
                
            else */

        }

        private void Alarmlist_Click(object sender, EventArgs e)
        {
           
        }

        private void Shutdown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Shutdown The Application", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // 關閉 PLC thread
                ContrelModule.CPLCInterface.GetSingleton().CloseAllThreads();               
                Application.Exit();                
            }
        }

        private void navigationBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        public static void SetOperatorID(string pszOperatorID)
        {
            singleton.operatorIDButton.Text = pszOperatorID;
        }

        private void SearchControl(Control p_Control)
        {
            foreach (Control tmpControl in p_Control.Controls)
            {
                if (tmpControl is Panel || tmpControl is Form || tmpControl is UserControl || tmpControl is GroupBox
                    || tmpControl is Dotnetrix.Controls.TabControlEX || tmpControl is SplitContainer)
                {
                    SearchControl(tmpControl);
                }
                else if (tmpControl is TreeView)
                {
                    ((TreeView)tmpControl).AfterSelect += new TreeViewEventHandler(ControlLog);
                }
                else if (tmpControl is RadioButton || tmpControl is CheckBox || tmpControl is Button)
                {
                    tmpControl.Click += new EventHandler(ControlLog);
                }
            }
        }

        private void ControlLog(object sender, EventArgs e)
        {
            string szLogInfo = "";
            if (sender is TreeView)
            {
                if (((TreeView)sender).SelectedNode != null)
                    szLogInfo = ((TreeView)sender).Name + "   " + ((TreeView)sender).SelectedNode.Text;
            }
            else
            {
                szLogInfo = ((Control)sender).Name + "   " + ((Control)sender).Text;
            }

            navigationHashtable[szNavigationString].Enabled = true;

            //if (!Maintain.UserLoginForm.getSingleton().SuperUserLoginStatus)
            {
                //string szFunctionName = "";

                /*if (navigationHashtable[szNavigationString] is Common.Template.NavigationPanelTemplate)
                {
                    szFunctionName = szNavigationString + "_" + ((Common.Template.NavigationPanelTemplate)navigationHashtable[szNavigationString]).NowGunction.FuncName;
                }
                else
                {
                    szFunctionName = szNavigationString;
                }*/

                //if (Maintain.UserAccountPanelControl.getSingleton().accessFunctionTable.ContainsFunction(szFunctionName))
                {
                    //bool bAuthority = Maintain.UserAccountPanelControl.getSingleton().accessFunctionTable.GetAccessAccountType(szFunctionName).ContainsKey(Maintain.UserLoginForm.getSingleton().NowUserAccount.AccountType.GetFirstAccountTypeName()) || Maintain.UserLoginForm.getSingleton().NowUserAccount.AccessFunction.ContainsFunction(szFunctionName);

                    //if (navigationHashtable[szNavigationString] is Common.Template.InfoPanelTemplate)
                    //{
                    //    //((Common.Template.InfoPanelTemplate)navigationHashtable[szNavigationString]).NowGunction.Control.Enabled = true;
                    //}
                    //else
                    //{
                    //    //navigationHashtable[szNavigationString].Enabled = bAuthority;
                    //}
                   
                    //if (!bAuthority)
                    //{
                     //   MessageBox.Show("Please Check Your Authority");
                    //}
                }
            }
            //else
            //{
            //    if (navigationHashtable[szNavigationString] is Common.Template.NavigationPanelTemplate)
            //    {
            //        ((Common.Template.NavigationPanelTemplate)navigationHashtable[szNavigationString]).NowGunction.Control.Enabled = true;
            //    }
            //    else
            //    {
           //         navigationHashtable[szNavigationString].Enabled = true;
            //    }
            //}
        }

        private void PrintScreen_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                    Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            string fileName = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".jpg";
            string path = System.Environment.CurrentDirectory + "\\PrintScreen\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Thread.Sleep(50);
            bitmap.Save(path + fileName, ImageFormat.Jpeg);                       
        }        
    } 
}