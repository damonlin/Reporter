using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MainPage
{
    public partial class UserLoginForm : Form
    {
        static UserLoginForm singleton = null;
        static bool bFirstLogin = true;
        //private static UserActivityHook actHook = null;

        private UserAccount objUserAccount = new MainPage.UserAccount();
        private bool bSuperUserLogin = false;

        public UserLoginForm()
        {
            InitializeComponent();
        }

        public static UserLoginForm getSingleton()
        {
            if (singleton == null)
            {
                singleton = new UserLoginForm();

                //actHook = new UserActivityHook(); // crate an instance with global hooks
                //actHook.OnMouseActivity += new MouseEventHandler(singleton.MouseMoved);
                //actHook.KeyDown += new KeyEventHandler(singleton.MyKeyDown);
            }
            singleton.FastLoginButton.Visible = Common.CTAPSetup.FastLogin;
            return singleton;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginIDTextBox.Text.Length == 0 || passwordTextBox.Text.Length == 0)
            {
                MessageBox.Show("Login ID And Password Can't Be Empty");
                return;
            }

            if (loginIDTextBox.Text == "Contrel" && passwordTextBox.Text == "bgao/s")
            {
                bFirstLogin = false;
                bSuperUserLogin = true;
                Common.CTAPSetup.NowUserName = loginIDTextBox.Text;
                singleton.Hide();
                return;
            }

            foreach (MainPage.UserAccount user in MainPage.UserAccountPanelControl.getSingleton().userAccountList)
            {
                if (user.LoginID == loginIDTextBox.Text && user.Password == passwordTextBox.Text)
                {
                    bFirstLogin = false;
                    objUserAccount = user;
                    bSuperUserLogin = false;
                    Common.CTAPSetup.NowUserName = user.LoginID;
                    singleton.Hide();
                    return;
                }
            }

            MessageBox.Show("Please Check Login ID And Password");
        }

        private void UserLoginForm_Load(object sender, EventArgs e)
        {
            loginIDTextBox.Text = "";
            passwordTextBox.Text = "";
            CardIDTextBox.Text = "";
            //cardReader1.TextBoxForSetCardID = CardIDTextBox;
            loginIDTextBox.Select();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                loginButton_Click(null, EventArgs.Empty);
            }
        }

        private void FastLoginButton_Click(object sender, EventArgs e)
        {
            loginIDTextBox.Text = "Contrel";
            passwordTextBox.Text = "bgao/s";
            loginButton_Click(null, EventArgs.Empty);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (bFirstLogin)
            {
                Application.Exit();
                DialogResult = DialogResult.Abort;
            }
        }

        public bool SuperUserLoginStatus
        {
            get { return bSuperUserLogin; }
        }

        public MainPage.UserAccount NowUserAccount
        {
            get { return objUserAccount; }
        }


        public void MouseMoved(object sender, MouseEventArgs e)
        {
            Common.CTAPSetup.AutoLogoutCount = 0;
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            Common.CTAPSetup.AutoLogoutCount = 0;
        }

        private void CardIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CardIDTextBox.Text != "" &&CardIDTextBox.Text != "Card Isn`t Exist")
            {
                foreach (MainPage.UserAccount user in MainPage.UserAccountPanelControl.getSingleton().userAccountList)
                {
                    if (user.CardID == CardIDTextBox.Text)
                    {
                        bFirstLogin = false;
                        objUserAccount = user;
                        bSuperUserLogin = false;
                        Common.CTAPSetup.NowUserName = user.LoginID;
                        singleton.Hide();
                        return;
                    }
                }
                CardIDTextBox.Text = "Card Isn`t Exist";
            }
        }
    }
}