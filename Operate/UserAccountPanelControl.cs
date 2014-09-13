using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using Common.Template;

namespace MainPage
{
    public partial class UserAccountPanelControl : InfoPanelTemplate
    {
        private const string strINIPath = "INI\\UserAccount.INI";
        private static UserAccountPanelControl singleton;
        private bool bInit = false;

        //取得accessLevelNumeric的值
        private static int miLevelValue = 0;
        //取得accessLevelNumeric的初始值
        private static int miInitLevelValue = 0;

        public ArrayList userAccountList = new ArrayList();
        public AccountTypeTable accountTypeTable = new AccountTypeTable();
        public AccessFunctionTable accessFunctionTable = new AccessFunctionTable();
        public ArrayList departmentList = new ArrayList();
        public int iAutoLogoutTime = 0;

        public UserAccount newUserAccount = new UserAccount();

        public UserAccountPanelControl()
        {
            InitializeComponent();
            LoadParaFromIniFile(strINIPath);
        }

        public static UserAccountPanelControl getSingleton()
        {
            if (singleton == null)
            {
                singleton = new UserAccountPanelControl();
            }
            return singleton;
        }

        private bool SaveParaToIniFile(string iniFilePath)
        {
            FileStream output;
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                output = new FileStream(strINIPath, FileMode.Create, FileAccess.ReadWrite);

                formatter.Serialize(output, accountTypeTable);
                formatter.Serialize(output, departmentList);
                formatter.Serialize(output, accessFunctionTable);
                formatter.Serialize(output, userAccountList);
                formatter.Serialize(output, iAutoLogoutTime);


                if (output != null)
                {
                    // close file
                    output.Close();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        private bool LoadParaFromIniFile(string iniFilePath)
        {
            FileStream input;
            BinaryFormatter reader = new BinaryFormatter();

            try
            {
                input = new FileStream(strINIPath, FileMode.Open, FileAccess.Read);

                AccountTypeTable hs = new AccountTypeTable();
                hs = (AccountTypeTable)reader.Deserialize(input);
                accountTypeTable = hs;

                ArrayList dl = new ArrayList();
                dl = (ArrayList)reader.Deserialize(input);
                departmentList = dl;

                
                AccessFunctionTable af = new AccessFunctionTable();
                af = (AccessFunctionTable)reader.Deserialize(input);
                accessFunctionTable = af;
                

                ArrayList ul = new ArrayList();
                ul = (ArrayList)reader.Deserialize(input);
                userAccountList = ul;

                int iT = 0;
                iT = (int)reader.Deserialize(input);
                iAutoLogoutTime = iT;

                if (input != null)
                {
                    // close file
                    input.Close();
                }
            }

            catch (SerializationException)
            {
                MessageBox.Show("Error reading from file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        private void SetParaToDepartmentUI(ref DataGridView dataGridView, Object obj)
        {
            dataGridView.Rows.Clear();

            if (dataGridView.Equals(editDepartmentDataGridView) == true)
            {
                if (((ArrayList)obj).Count > 0)
                {
                    dataGridView.Rows.Add(((ArrayList)obj).Count);
                    for (int i = 0; i < ((ArrayList)obj).Count; i++)
                        dataGridView.Rows[i].SetValues(((ArrayList)obj)[i]);
                }
            }
            else if (dataGridView.Equals(accountTypeDataGridView) == true)
            {
                if (((AccountTypeTable)obj).Count > 0)
                {
                    dataGridView.Rows.Add(((AccountTypeTable)obj).Count);
                    int idx = 0;
                    foreach (string accountName in ((AccountTypeTable)obj).Keys)
                    {
                        dataGridView.Rows[idx].SetValues(accountName, ((AccountTypeTable)obj)[accountName]);
                        idx++;
                    }
                }
            }
            else if (dataGridView.Equals(accessFunctionDataGridView) == true)
            {
                if (((AccessFunctionTable)obj).Count > 0)
                {
                    dataGridView.Rows.Add(((AccessFunctionTable)obj).Count);

                    for (int idx = 0; idx < ((AccessFunctionTable)obj).Count; idx++)
                    {
                        dataGridView.Rows[idx].SetValues(((AccessFunction)((AccessFunctionTable)obj)[idx]).AccessFunctionName);
                    }
                }
            }
            else if (dataGridView.Equals(userAccountDataGridView) == true)
            {
                dataGridView.Rows.Clear();
                if (((ArrayList)obj).Count > 0)
                {
                    dataGridView.Rows.Add(((ArrayList)obj).Count);

                    for (int idx = 0; idx < ((ArrayList)obj).Count; idx++)
                    {
                        dataGridView.Rows[idx].SetValues(idx + 1, ((UserAccount)((ArrayList)obj)[idx]).LoginID,
                                                                  ((UserAccount)((ArrayList)obj)[idx]).Department,
                                                                  ((UserAccount)((ArrayList)obj)[idx]).UserName,
                                                                  ((UserAccount)((ArrayList)obj)[idx]).AccountType.GetFirstAccountTypeName(),
                                                                  ((UserAccount)((ArrayList)obj)[idx]).Description);
                    }
                    dataGridView_Sorted(userAccountDataGridView, null);
                }
            }
            else if (dataGridView.Equals(functionAccessDataGridView) == true)
            {
                if (((AccessFunctionTable)obj).Count > 0)
                {
                    System.Windows.Forms.DataGridViewColumn[] dataGridColumn = new System.Windows.Forms.DataGridViewColumn[accountTypeTable.Count];

                    AccountTypeTable accountTypeTableTemp = new AccountTypeTable();
                    foreach (string strAccount in accountTypeTable.Keys)
                        accountTypeTableTemp.AddType(strAccount, (int)(accountTypeTable[strAccount]));

                    int iColumnIdx = 0;
                    for (int i = 100; i >= 0; i--)
                    {
                        foreach (string strAccount in accountTypeTableTemp.Keys)
                        {
                            if (((int)accountTypeTableTemp[strAccount]) == i)
                            {
                                accountTypeTableTemp.Remove(strAccount);

                                System.Windows.Forms.DataGridViewCheckBoxColumn column = new System.Windows.Forms.DataGridViewCheckBoxColumn();

                                column.HeaderText = strAccount;
                                column.Name = "AccessFuncColumn" + i;
                                column.Width = 100;
                                column.ReadOnly = true;

                                dataGridColumn[iColumnIdx] = column;
                                iColumnIdx++;

                                //避免重複印出
                                foreach (DataGridViewColumn ExistColumn in this.functionAccessDataGridView.Columns)
                                {
                                    if (ExistColumn.HeaderText == strAccount)
                                    {
                                        this.functionAccessDataGridView.Columns.Remove(ExistColumn);
                                        break;
                                    }
                                }

                                break;
                            }
                        }
                    }

                    this.functionAccessDataGridView.Columns.AddRange(dataGridColumn);

                    dataGridView.Rows.Add(((AccessFunctionTable)obj).Count);
                    for (int idx = 0; idx < ((AccessFunctionTable)obj).Count; idx++)
                    {
                        dataGridView.Rows[idx].SetValues(idx + 1, ((AccessFunction)((AccessFunctionTable)obj)[idx]).AccessFunctionName);
                        foreach (string strAccount in ((AccessFunction)accessFunctionTable[idx]).AccountType.Keys)
                        {
                            for (int columnIdx = 2; columnIdx < functionAccessDataGridView.ColumnCount; columnIdx++)
                            {
                                if (strAccount.Equals(functionAccessDataGridView.Columns[columnIdx].HeaderText))
                                {
                                    functionAccessDataGridView.Rows[idx].Cells[columnIdx].Value = true;
                                }
                                //functionAccessDataGridView.Rows[idx].Cells[columnIdx].ReadOnly = strAccount.Equals(functionAccessDataGridView.Columns[columnIdx].HeaderText);
                            }
                        }
                    }
                }
            }
        }

        private void UserAccountPanelControl_Load(object sender, EventArgs e)
        {
            dataGridView_Sorted(userAccountDataGridView, null);

            SetParaToDepartmentUI(ref userAccountDataGridView, (Object)userAccountList);
            SetParaToDepartmentUI(ref editDepartmentDataGridView, (Object)departmentList);
            SetParaToDepartmentUI(ref accessFunctionDataGridView, (Object)accessFunctionTable);
            SetParaToDepartmentUI(ref accountTypeDataGridView, (Object)accountTypeTable);
            SetParaToDepartmentUI(ref functionAccessDataGridView, (Object)accessFunctionTable);

            AutoLogoutNumericUpDown.Value = iAutoLogoutTime;

            bInit = true;
        }

        private void NewAccountButton_Click(object sender, EventArgs e)
        {
            newUserAccount = new UserAccount();
            if (new NewUserAccountForm(this, NewUserAccountForm.FormType.NEW_FORM, ref newUserAccount).ShowDialog(this) == DialogResult.OK)
            {
                userAccountDataGridView.Rows.Add(1);
                int iRowIdx = userAccountDataGridView.Rows.Count - 1;
                userAccountDataGridView.Rows[iRowIdx].SetValues(iRowIdx + 1,
                   newUserAccount.LoginID, newUserAccount.Department, newUserAccount.UserName, newUserAccount.AccountType.GetFirstAccountTypeName(), newUserAccount.Description);

                dataGridView_Sorted(userAccountDataGridView, null);

                // Save as file
                userAccountList.Add(newUserAccount);
                SaveParaToIniFile(strINIPath);
            }
        }

        private void modifyAccountButton_Click(object sender, EventArgs e)
        {
            if (userAccountDataGridView.SelectedRows.Count == 1)
            {
                UserAccount modifyUserAccount = new UserAccount();

                modifyUserAccount = (UserAccount)userAccountList[userAccountDataGridView.SelectedRows[0].Index];

                if (new NewUserAccountForm(this, NewUserAccountForm.FormType.MODIFY_FORM, ref modifyUserAccount).ShowDialog(this) == DialogResult.OK)
                {
                    userAccountList[userAccountDataGridView.SelectedRows[0].Index] = modifyUserAccount;

                    // Save as file
                    SaveParaToIniFile(strINIPath);
                    SetParaToDepartmentUI(ref userAccountDataGridView, (Object)userAccountList);

                    dataGridView_Sorted(userAccountDataGridView, null);
                }
            }
        }

        private void deleteAccountButton_Click(object sender, EventArgs e)
        {
            if (userAccountDataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show(this, "Are you sure to remove this account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    userAccountList.RemoveAt(userAccountDataGridView.SelectedRows[0].Index);

                    // Save as file
                    SaveParaToIniFile(strINIPath);
                    SetParaToDepartmentUI(ref userAccountDataGridView, (Object)userAccountList);

                    dataGridView_Sorted(userAccountDataGridView, null);
                }
            }
        }

        private void showItemButton_Click(object sender, EventArgs e)
        {
            if (userAccountDataGridView.Rows.Count > 0)
            {
                if (sender == firstItemButton)
                {
                }
                else if (sender == prevItemButton)
                {
                }
                else if (sender == nextItemButton)
                {
                }
            }
        }

        private void departmentMoveSequenceButton_Click(object sender, EventArgs e)
        {
            if (editDepartmentDataGridView.SelectedRows.Count == 1)
            {

                int selectIdx = editDepartmentDataGridView.SelectedRows[0].Index;
                int targetIdx = editDepartmentDataGridView.SelectedRows[0].Index;

                object strSelect = departmentList[selectIdx];

                if (sender == departmentMoveUpButton)
                {
                    targetIdx = selectIdx - 1;
                    if (targetIdx < 0)
                        targetIdx++;
                }
                else if (sender == departmentMoveDownButton)
                {
                    targetIdx = selectIdx + 1;
                    if (targetIdx == departmentList.Count)
                        targetIdx--;
                }

                object strTarget = departmentList[targetIdx];

                departmentList[targetIdx] = strSelect;
                departmentList[selectIdx] = strTarget;

                SetParaToDepartmentUI(ref editDepartmentDataGridView, (Object)departmentList);
                SaveParaToIniFile(strINIPath);

                editDepartmentDataGridView.Rows[0].Selected = false;
                editDepartmentDataGridView.Rows[targetIdx].Selected = true;
            }
        }

        private void dataGridView_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            Int32 preferredNormalContentHeight =
                e.Row.GetPreferredHeight(e.Row.Index,
                DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
                e.Row.DefaultCellStyle.Padding.Bottom;

            // Specify a new padding.
            Padding newPadding = e.Row.DefaultCellStyle.Padding;
            newPadding.Bottom = e.Row.Height - preferredNormalContentHeight;
            e.Row.DefaultCellStyle.Padding = newPadding;
        }

        private void dataGridView_Sorted(object sender, EventArgs e)
        {
            // 自動更新每一個Row的高度
            for (int i = 0; i < ((DataGridView)sender).Rows.Count; i++)
            {
                Int32 preferredNormalContentHeight =
                    ((DataGridView)sender).Rows[i].GetPreferredHeight(((DataGridView)sender).Rows[i].Index,
                    DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
                    ((DataGridView)sender).Rows[i].DefaultCellStyle.Padding.Bottom;

                ((DataGridView)sender).Rows[i].Height = preferredNormalContentHeight;
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (((DataGridView)sender).SelectedRows.Count == 1)
            {
                if (sender == editDepartmentDataGridView)
                {
                    departmentTextBox.Text = (string)((DataGridView)sender).Rows[((DataGridView)sender).SelectedRows[0].Index].Cells[0].Value;
                }
                else if (sender == accessFunctionDataGridView)
                {
                    accessFunctionTextBox.Text = (string)((DataGridView)sender).Rows[((DataGridView)sender).SelectedRows[0].Index].Cells[0].Value;
                }
                else if (sender == accountTypeDataGridView)
                {
                    accountNameTextBox.Text = (string)((DataGridView)sender).Rows[((DataGridView)sender).SelectedRows[0].Index].Cells[0].Value;
                    //accessLevelNumeric.Value = (int)((DataGridView)sender).Rows[((DataGridView)sender).SelectedRows[0].Index].Cells[1].;
                }
            }
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            if (sender == addAccountTypeButton)
            {
                for (int i = 0; i < accountTypeDataGridView.RowCount; i++)
                {
                    if (accessLevelNumeric.Value == System.Convert.ToInt32(accountTypeDataGridView.Rows[i].Cells[1].Value))
                    {
                        MessageBox.Show("Access Level 值不可重覆！   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (sender == addDepartmentButton)
            {
                if (departmentTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Invalid format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (departmentList.Contains(departmentTextBox.Text) == true)
                {
                    MessageBox.Show("The department has been existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                departmentList.Add(departmentTextBox.Text);
                SetParaToDepartmentUI(ref editDepartmentDataGridView, (Object)departmentList);
                SaveParaToIniFile(strINIPath);
            }
            else if (sender == addAccountTypeButton)
            {
                if (accountNameTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Invalid format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (accountTypeTable.ContainsKey(accountNameTextBox.Text) == true)
                {
                    MessageBox.Show("The department has been existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                accountTypeTable.AddType(accountNameTextBox.Text, (int)accessLevelNumeric.Value);
                SetParaToDepartmentUI(ref accountTypeDataGridView, (Object)accountTypeTable);
                SetParaToDepartmentUI(ref functionAccessDataGridView, (Object)accessFunctionTable);
                SaveParaToIniFile(strINIPath);
            }
            else if (sender == addAccessFunctionButton)
            {
                if (accessFunctionTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Invalid format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (AccessFunction accessFunction in accessFunctionTable)
                {
                    if (accessFunction.AccessFunctionName.Equals(accessFunctionTextBox.Text) == true)
                    {
                        MessageBox.Show("The function has been existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                accessFunctionTable.AddFunction(accessFunctionTextBox.Text);
                SetParaToDepartmentUI(ref accessFunctionDataGridView, (Object)accessFunctionTable);
                SaveParaToIniFile(strINIPath);
            }
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            if (sender == removeDepartmentButton)
            {
                if (editDepartmentDataGridView.Rows.Count >= 1 && editDepartmentDataGridView.SelectedRows.Count == 1)
                {
                    departmentList.RemoveAt(editDepartmentDataGridView.SelectedRows[0].Index);
                    SetParaToDepartmentUI(ref editDepartmentDataGridView, (Object)departmentList);
                    SaveParaToIniFile(strINIPath);
                }
            }
            else if (sender == removeAccountTypeButton)
            {
                if (accountTypeDataGridView.Rows.Count >= 1 && accountTypeDataGridView.SelectedRows.Count == 1)
                {
                    if (accountTypeTable.ContainsKey(accountTypeDataGridView.SelectedRows[0].Cells[0].Value) == true)
                        accountTypeTable.Remove(accountTypeDataGridView.SelectedRows[0].Cells[0].Value);

                    SetParaToDepartmentUI(ref accountTypeDataGridView, (Object)accountTypeTable);
                    SaveParaToIniFile(strINIPath);
                }
            }
            else if (sender == removeAccessFunctionButton)
            {
                if (accessFunctionDataGridView.Rows.Count >= 1 && accessFunctionDataGridView.SelectedRows.Count == 1)
                {
                    foreach (AccessFunction accessFunction in accessFunctionTable)
                    {
                        if (accessFunction.AccessFunctionName.Equals(accessFunctionDataGridView.SelectedRows[0].Cells[0].Value) == true)
                        {
                            accessFunctionTable.Remove(accessFunction);
                            break;
                        }
                    }

                    SetParaToDepartmentUI(ref accessFunctionDataGridView, (Object)accessFunctionTable);
                    SaveParaToIniFile(strINIPath);
                }
            }
        }

        private void functionAccessDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (bInit == true && e.ColumnIndex >= 2 && e.RowIndex >= 0)
            {
                if ((bool)(functionAccessDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                {
                    functionAccessDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    for (int i = 2; i < functionAccessDataGridView.ColumnCount; i++)
                    {
                        if (i == e.ColumnIndex)
                            continue;
                        functionAccessDataGridView.Rows[e.RowIndex].Cells[i].Value = false;
                        functionAccessDataGridView.Rows[e.RowIndex].Cells[i].ReadOnly = false;
                    }

                    AccountTypeTable accountType = new AccountTypeTable();
                    accountType.AddType(functionAccessDataGridView.Columns[e.ColumnIndex].HeaderText, (int)(accountTypeTable[functionAccessDataGridView.Columns[e.ColumnIndex].HeaderText]));
                    accessFunctionTable.UpdateFunction(((AccessFunction)accessFunctionTable[e.RowIndex]).AccessFunctionName, accountType);

                    SaveParaToIniFile(strINIPath);
                }
            }
            */
        }

        private void accessLevelNumeric_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < accountTypeDataGridView.RowCount; i++)
            {
                if (accessLevelNumeric.Value > (accessLevelNumeric.Value - 1))
                {
                    if (accessLevelNumeric.Value == System.Convert.ToInt32(accountTypeDataGridView.Rows[i].Cells[1].Value))
                    {
                        //AccessLevelNumeric遞增
                        if (miLevelValue < accessLevelNumeric.Value)
                        {
                            accessLevelNumeric.Value += 1;
                            miLevelValue = System.Convert.ToInt32(accessLevelNumeric.Value);
                            //AccessLevelNumeric最大值不得超過99，而100為東捷開發人員專用
                            if (accessLevelNumeric.Value >= 100)
                            {
                                //AccessLevelNumeric回到初始值
                                accessLevelNumeric.Value = miInitLevelValue;
                                miLevelValue = miInitLevelValue;
                                return;
                            }
                        }
                        //AccessLevelNumeric遞減
                        else if (miLevelValue > accessLevelNumeric.Value)
                        {
                            //AccessLevelNumeric最小值不得為0
                            if (accessLevelNumeric.Value - 1 <= 0)
                            {
                                //AccessLevelNumeric回到初始值
                                accessLevelNumeric.Value = miInitLevelValue;
                                miLevelValue = miInitLevelValue;
                                return;
                            }
                            accessLevelNumeric.Value -= 1;
                            miLevelValue = System.Convert.ToInt32(accessLevelNumeric.Value);
                        }
                    }
                }
            }

        }

        //取得AccessLevelNumeric上顯示的值
        public void GgtAccessLevelNumeric()
        {
            for (int i = 0; i < accountTypeDataGridView.RowCount; i++)
            {
                if (accessLevelNumeric.Value == System.Convert.ToInt32(accountTypeDataGridView.Rows[i].Cells[1].Value))
                {
                    accessLevelNumeric.Value += 1;
                    miLevelValue = System.Convert.ToInt32(accessLevelNumeric.Value);
                    miInitLevelValue = System.Convert.ToInt32(accessLevelNumeric.Value);
                }
            }
        }

        public void SetSupervisor(string AccoutName, int AccessLevel)
        {
            if (AccessLevel == 100)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
            }
            else if (AccessLevel >= 41 && AccessLevel <= 60)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
            else if (AccessLevel >= 21 && AccessLevel <= 40)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        public void ListFunctionTable(Dictionary<string, Control> navigationHashtable)
        {
            foreach(string de in navigationHashtable.Keys)
            {
                if (navigationHashtable[de] is Common.Template.InfoPanelTemplate)
                {
                    AddToFunctionTable( de.ToString());
                }
                else if (navigationHashtable[de] is Common.Template.NavigationPanelTemplate)
                {

                    Common.Template.FunctionTemplate[] aobjAllFunction = ((Common.Template.NavigationPanelTemplate)navigationHashtable[de]).AllFunction.ToArray();
                    foreach (Common.Template.FunctionTemplate objsubFunc in aobjAllFunction)
                    {
                        AddToFunctionTable(de.ToString() + "_" + objsubFunc.FuncName[Thread.CurrentThread.CurrentUICulture]);
                    }
                }
            }
        }

        private bool CheckFunctionExist(string p_szFunctionName)
        {
            foreach (AccessFunction accessFunction in accessFunctionTable)
            {
                if (accessFunction.AccessFunctionName.Equals(p_szFunctionName) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddToFunctionTable(string p_szFunctionName)
        {
            if (CheckFunctionExist(p_szFunctionName) != true)
            {
                accessFunctionTable.AddFunction(p_szFunctionName);
                SetParaToDepartmentUI(ref accessFunctionDataGridView, (Object)accessFunctionTable);
                SaveParaToIniFile(strINIPath);
            }
        }

        private void functionAccessDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 2)
            {
                if (functionAccessDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    functionAccessDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
                else
                {
                    functionAccessDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)functionAccessDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }

                AccountTypeTable tmpAccountType = new AccountTypeTable();

                for (int iCellCount = 2; iCellCount < functionAccessDataGridView.Columns.Count; iCellCount++)
                {
                    if (functionAccessDataGridView.Rows[e.RowIndex].Cells[iCellCount].Value != null)
                    {
                        if (((bool)functionAccessDataGridView.Rows[e.RowIndex].Cells[iCellCount].Value) == true)
                        {
                            tmpAccountType.AddType(functionAccessDataGridView.Columns[iCellCount].HeaderCell.Value.ToString(), (int)accountTypeTable[functionAccessDataGridView.Columns[iCellCount].HeaderCell.Value.ToString()]);
                        }
                    }
                }

                accessFunctionTable.UpdateFunction(functionAccessDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString(), tmpAccountType);
                SaveParaToIniFile(strINIPath);
            }
        }

        private void AutoLogoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Common.CTAPSetup.AutoLogoutTime = (int)AutoLogoutNumericUpDown.Value;
        }
    }

    [Serializable]
    public class UserAccount : ISerializable
    {
        private string loginID = "";
        private string password = "";
        private string department = "";
        private string userName = "";
        private string description = "";
        private string cardID = "";

        protected AccountTypeTable accountType = new AccountTypeTable();
        private bool enableAdvancedAccess = false;
        protected AccessFunctionTable accessFunctionTable = new AccessFunctionTable();

        public UserAccount()
        {
        }

        public UserAccount(SerializationInfo info, StreamingContext context)
        {
            //開始反序列化工作，丟入自行定義的 key 將之前被序列化的資料讀出   
            loginID = info.GetString("loginID");
            password = info.GetString("password");
            department = info.GetString("department");
            userName = info.GetString("userName");
            description = info.GetString("description");
            cardID = info.GetString("cardID");


            enableAdvancedAccess = info.GetBoolean("enableAdvancedAccess");

            int count = info.GetInt32("accountType_count");
            for (int i = 0; i < count; i++)
            {
                accountType.Add(info.GetString("accountType_id_" + i), info.GetString("accountType_value_" + i));
            }

            accessFunctionTable = new AccessFunctionTable(info, context);
        }

        //實作 ISerializable 裡定義的 method　，來達到序列化的工作   
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //自行定義對應的key(userid, username..)，並將變數存入 SerializationInfo 中   
            info.AddValue("loginID", loginID);
            info.AddValue("password", password);
            info.AddValue("department", department);
            info.AddValue("userName", userName);
            info.AddValue("description", description);
            info.AddValue("cardID", cardID);

            info.AddValue("enableAdvancedAccess", enableAdvancedAccess);

            //由於hashtable中有多筆資料，所以先存一個count 供反序列之用，   
            //並利用迴圈來將資料存入   
            info.AddValue("accountType_count", accountType.Count);
            int index = 0;
            foreach (DictionaryEntry entry in accountType)
            {
                info.AddValue("accountType_id_" + index, entry.Key);
                info.AddValue("accountType_value_" + index, entry.Value);
                index++;
            }

            //由於hashtable中有多筆資料，所以先存一個count 供反序列之用，   
            //並利用迴圈來將資料存入   
            accessFunctionTable.GetObjectData(info, context);
        }

        public string LoginID
        {
            get
            {
                return loginID;
            }
            set
            {
                loginID = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public AccountTypeTable AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                accountType = value;
            }
        }
        public bool EnableAdvancedAccess
        {
            get
            {
                return enableAdvancedAccess;
            }
            set
            {
                enableAdvancedAccess = value;
            }
        }
        public AccessFunctionTable AccessFunction
        {
            get
            {
                return accessFunctionTable;
            }
            set
            {
                accessFunctionTable = value;
            }
        }
        public string CardID
        {
            get
            {
                return cardID;
            }
            set
            {
                cardID = value;
            }
        }
    }

    [Serializable]
    public class AccountTypeTable : Hashtable
    {
        public AccountTypeTable()
        {
        }

        public AccountTypeTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        public bool AddType(string accountTypeName, int level)
        {
            this.Add(accountTypeName, level);
            return true;
        }

        public string GetFirstAccountTypeName()
        {
            foreach (string accountTypeName in this.Keys)
            {
                return accountTypeName;
            }
            return "";
        }

        public string GetAccessLevel()
        {
            foreach (string accessLevel in this.Values)
            {
                return accessLevel;
            }
            return "1";
        }

    }

    [Serializable]
    public class AccessFunctionTable : ArrayList, ISerializable
    {
        public AccessFunctionTable()
        {

        }

        public AccessFunctionTable(SerializationInfo info, StreamingContext context)
        {
            int count = info.GetInt32("accessFunction_count");
            for (int i = 0; i < count; i++)
                this.Add(new AccessFunction(info, context, i));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("accessFunction_count", this.Count);
            for (int i = 0; i < this.Count; i++)
                ((AccessFunction)this[i]).GetObjectData(info, context);
        }

        public bool AddFunction(string functionName)
        {
            if (this.Contains(functionName) == false)
            {
                AccessFunction accessFunction = new AccessFunction();
                accessFunction.ID = this.Count;
                accessFunction.AccessFunctionName = functionName;
                this.Add(accessFunction);
                return true;
            }
            else
                return false;
        }

        public bool AddFunction(AccessFunction accessFunctionEx)
        {
            foreach (AccessFunction accessFunction in this)
            {
                if (accessFunction.AccessFunctionName.Equals(accessFunctionEx.AccessFunctionName) == true)
                    return false;
            }
            AccessFunction accessFunctionTemp = new AccessFunction();
            accessFunctionTemp.ID = this.Count;
            accessFunctionTemp.AccessFunctionName = accessFunctionEx.AccessFunctionName;
            accessFunctionTemp.AccountType = accessFunctionEx.AccountType;
            this.Add(accessFunctionTemp);
            return true;
        }

        public bool UpdateFunction(string functionName, AccountTypeTable accountType)
        {
            foreach (AccessFunction accessFunction in this)
            {
                if (accessFunction.AccessFunctionName.Equals(functionName) == true)
                {
                    accessFunction.AccountType = accountType;
                    return true;
                }
            }
            return false;
        }

        public AccountTypeTable GetAccessAccountType(string functionName)
        {
            foreach (AccessFunction accessFunction in this)
            {
                if (accessFunction.AccessFunctionName.Equals(functionName) == true)
                    return accessFunction.AccountType;
            }
            return null;
        }

        public bool ContainsFunction(string functionName)
        {
            foreach (AccessFunction accessFunction in this)
            {
                if (accessFunction.AccessFunctionName.CompareTo(functionName) == 0)
                    return true;
            }
            return false;
        }
    }
    [Serializable]
    public class AccessFunction : ISerializable
    {
        private int id;
        private string accessFunctionName = "";
        private AccountTypeTable accountType = new AccountTypeTable();

        public AccessFunction()
        {
        }

        public AccessFunction(SerializationInfo info, StreamingContext context, int idx)
        {
            //id = info.GetInt32("id_id_" + idx);
            id = idx;
            accessFunctionName = info.GetString("accessFunctionName_id_" + id);

            int count = info.GetInt32("accountType_count_id_" + id);

            for (int i = 0; i < count; i++)
                accountType.Add(info.GetString("accountType_id_" + id + "_" + i), info.GetString("accountType_value_" + id + "_" + i));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //開始反序列化工作，丟入自行定義的 key 將之前被序列化的資料讀出  
            //info.AddValue("id_id_"+id, id);
            info.AddValue("accessFunctionName_id_" + id, accessFunctionName);

            int index = 0;
            info.AddValue("accountType_count_id_" + id, accountType.Count);
            foreach (DictionaryEntry entry in accountType)
            {
                info.AddValue("accountType_id_" + id + "_" + index, entry.Key);
                info.AddValue("accountType_value_" + id + "_" + index, entry.Value);
                index++;
            }
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string AccessFunctionName
        {
            get
            {
                return accessFunctionName;
            }
            set
            {
                accessFunctionName = value;
            }
        }

        public AccountTypeTable AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                accountType = value;
            }
        }
    }
}
