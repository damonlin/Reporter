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
   public partial class NewUserAccountForm : Form
   {
      public enum FormType { NEW_FORM = 0, MODIFY_FORM};
      private UserAccount userAccount = new UserAccount();
      private UserAccountPanelControl userAccountPanelControl;// = new UserAccountPanelControl();
      private FormType formType;

      public NewUserAccountForm(UserAccountPanelControl userAccountPanelControl, FormType formType, ref UserAccount userAccount)
      {
         InitializeComponent();

         this.userAccount = userAccount;
         this.userAccountPanelControl = userAccountPanelControl;

         // 填入Account Type資料
         foreach (string accountTypeName in userAccountPanelControl.accountTypeTable.Keys)
            accountTypeComboBox.Items.Add(accountTypeName);
         // 填入Access Function資料
         foreach (AccessFunction accessFunction in userAccountPanelControl.accessFunctionTable)
            advancedAccessCheckedListBox.Items.Add(accessFunction.AccessFunctionName);
         // 填入Department資料
         foreach (string departmentName in userAccountPanelControl.departmentList)
            departmentComboBox.Items.Add(departmentName);

         this.formType = formType;
         switch (formType)
         {
         case FormType.NEW_FORM:
            titleLabel.Text = "New User Account";
         	break;
         case FormType.MODIFY_FORM:
            titleLabel.Text = string.Format("Modify Account for {0}", userAccount.LoginID);
            loginIDTextBox.Enabled = false;

            SetDataToUI();
            break;
         }

            //cardReader1.TextBoxForSetCardID = CardIDTextBox;
      }

      private bool GetDataFromUI()
      {
         switch (formType)
         {
            case FormType.NEW_FORM:
               for (int i = 0; i < userAccountPanelControl.userAccountList.Count; i++)
               {
                  if (((UserAccount)userAccountPanelControl.userAccountList[i]).LoginID.Equals(loginIDTextBox.Text) == true)
                  {
                     MessageBox.Show(loginIDTextBox.Text + " is not available. Please try a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return false;
                  }
               }
               break;
            case FormType.MODIFY_FORM:
               break;
         }

         if (passwordTextBox.Text.Length==0 || confirmPasswordTextBox.Text.Length==0 || passwordTextBox.Text.Equals(confirmPasswordTextBox.Text)==false)
         {
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
         }

         //if (accountTypeComboBox.SelectedIndex==-1 || ((string)(accountTypeComboBox.SelectedItem)).Length == 0)
         //{
         //   MessageBox.Show("Account type must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         //   return false;
         //}

         userAccount.LoginID = loginIDTextBox.Text;
         userAccount.Password = passwordTextBox.Text;
         userAccount.Department = (string)departmentComboBox.SelectedItem;
         userAccount.UserName = userNameTextBox.Text;
         userAccount.Description = descriptionTextBox.Text;
         //userAccount.CardID = CardIDTextBox.Text;

         //this.userAccount.AccountType.Clear();
         //this.userAccount.AccountType.AddType((string)(accountTypeComboBox.SelectedItem), (int)(userAccountPanelControl.accountTypeTable[accountTypeComboBox.SelectedItem]));

         //userAccount.EnableAdvancedAccess = advancedFunctionAccessCheckBox.Checked;

         //for (int i = 0; i < userAccountPanelControl.accessFunctionTable.Count; i++ )
         //{
         //   if (advancedAccessCheckedListBox.GetItemChecked(i)==true)
         //      //userAccount.AccessFunction.Add(userAccountPanelControl.accessFunctionTable[i]);
         //      userAccount.AccessFunction.AddFunction((AccessFunction)userAccountPanelControl.accessFunctionTable[i]);
         //}         

         return true;
      }

      private bool SetDataToUI()
      {
         loginIDTextBox.Text = userAccount.LoginID;
         departmentComboBox.SelectedItem = userAccount.Department;
         userNameTextBox.Text = userAccount.UserName;
         descriptionTextBox.Text = userAccount.Description;
            CardIDTextBox.Text = userAccount.CardID.ToString();
         foreach (string accountTypeName in userAccount.AccountType.Keys)
            accountTypeComboBox.SelectedItem = accountTypeName;

         advancedFunctionAccessCheckBox.Checked = userAccount.EnableAdvancedAccess;

         for (int i = 0; i < userAccountPanelControl.accessFunctionTable.Count; i++)
         {
            for (int j = 0; j < userAccount.AccessFunction.Count; j++)
            {
               if (((AccessFunction)userAccountPanelControl.accessFunctionTable[i]).AccessFunctionName.Equals(((AccessFunction)userAccount.AccessFunction[j]).AccessFunctionName)==true)
               {
                  advancedAccessCheckedListBox.SetItemChecked(i, true);
                  break;
               }
            }
         }      

         return true;
      }

      private void cancelButton_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
         this.Dispose();
      }

      private void saveButton_Click(object sender, EventArgs e)
      {
         if (GetDataFromUI()==true)
         {
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
         }
      }

      private void advancedFunctionAccessCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         advancedAccessCheckedListBox.Enabled = advancedFunctionAccessCheckBox.Checked;
      }

       private void NewUserAccountForm_Load(object sender, EventArgs e)
       {
           advancedFunctionAccessCheckBox_CheckedChanged(advancedFunctionAccessCheckBox, EventArgs.Empty);
       }


        public void AfterReadCard(int iCardID)
        {
            CardIDTextBox.Text = iCardID.ToString();
        }
   }
}