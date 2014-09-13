using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using IniTool;

namespace AlarmList
{
    public partial class AlarmListPanelControl : UserControl
    {
        static private AlarmListPanelControl singleton;
        private const string strINIPath = "INI\\AlarmList.INI";
        private List<AlarmObject> alarmList = new List<AlarmObject>();
        private bool bInit = false;

        protected AlarmListPanelControl()
        {
            InitializeComponent();
            LoadIniFile(strINIPath);
        }

        public static AlarmListPanelControl getSingleton()
        {
            if (singleton == null)
                singleton = new AlarmListPanelControl();
            return singleton;
        }

        private void LoadIniFile(string iniFilePath)
        {
            IniFile iniFile = new IniFile(iniFilePath);

            for (int i = 0; i < iniFile.GetSectionNames().Length; i++)
            {
                AlarmObject alarmObj = new AlarmObject(iniFile.GetSectionNames()[i]);

                alarmObj.Level = iniFile.GetString(iniFile.GetSectionNames()[i], "Level", "");
                alarmObj.Type = iniFile.GetString(iniFile.GetSectionNames()[i], "Type", "");
                alarmObj.Reset = (iniFile.GetInt32(iniFile.GetSectionNames()[i], "Reset", 0) == 1) ? true : false;
                alarmObj.Retry = (iniFile.GetInt32(iniFile.GetSectionNames()[i], "Retry", 0) == 1) ? true : false;
                alarmObj.Skip = (iniFile.GetInt32(iniFile.GetSectionNames()[i], "Skip", 0) == 1) ? true : false;
                alarmObj.Continue = (iniFile.GetInt32(iniFile.GetSectionNames()[i], "Continue", 0) == 1) ? true : false;
                alarmObj.Message = iniFile.GetString(iniFile.GetSectionNames()[i], "Message", "");
                alarmObj.TroubleShooting = iniFile.GetString(iniFile.GetSectionNames()[i], "Troubleshooting", "");
                alarmObj.ReleaseTime = "";
                alarmObj.ReportTime = "";
                alarmObj.Message = alarmObj.Message.Replace("**********", "\r\n");
                alarmObj.TroubleShooting = alarmObj.TroubleShooting.Replace("**********", "\r\n");

                alarmList.Add(alarmObj);
            }
        }

        private void SaveToIniFile(string iniFilePath)
        {
            IniFile iniFile = new IniFile(iniFilePath);

            for (int i = 0; i < alarmList.Count; i++)
            {
                iniFile.WriteValue(alarmList[i].AlarmCode, "Level", alarmList[i].Level);
                iniFile.WriteValue(alarmList[i].AlarmCode, "Type", alarmList[i].Type);
                iniFile.WriteValue(alarmList[i].AlarmCode, "Reset", alarmList[i].Reset == true ? 1 : 0);
                iniFile.WriteValue(alarmList[i].AlarmCode, "Retry", alarmList[i].Retry == true ? 1 : 0);
                iniFile.WriteValue(alarmList[i].AlarmCode, "Skip", alarmList[i].Skip == true ? 1 : 0);
                iniFile.WriteValue(alarmList[i].AlarmCode, "Continue", alarmList[i].Continue == true ? 1 : 0);

                string strReplaceMessage = alarmList[i].Message.Replace("\r\n", "**********");
                iniFile.WriteValue(alarmList[i].AlarmCode, "Message", strReplaceMessage);

                string strReplaceTroubleShooting = alarmList[i].TroubleShooting.Replace("\r\n", "**********");
                iniFile.WriteValue(alarmList[i].AlarmCode, "Troubleshooting", strReplaceTroubleShooting);
            }
        }

        private void SetDataToUI()
        {
            alarmListDataGridView.Rows.Clear();
            if (alarmList.Count > 0)
            {
                alarmListDataGridView.Rows.Add(alarmList.Count);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    alarmListDataGridView.Rows[i].SetValues(alarmList[i].AlarmCode,
                                                            alarmList[i].Level,
                                                            alarmList[i].Type,
                                                            alarmList[i].Reset,
                                                            alarmList[i].Retry,
                                                            alarmList[i].Skip,
                                                            alarmList[i].Continue,
                                                            alarmList[i].Message,
                                                            alarmList[i].TroubleShooting);
                }
            }
        }

        private bool GetDataFromUI()
        {
            List<AlarmObject> alarmListTemp = new List<AlarmObject>();
            bool bFault = false;

            for (int i = 0; i < alarmListDataGridView.Rows.Count; i++)
            {
                bool bSkip = false;

                if (alarmListDataGridView.Rows[i].Cells[0].Value == null || ((string)alarmListDataGridView.Rows[i].Cells[0].Value).Length == 0)
                {
                    alarmListDataGridView.Rows[i].Cells[0].Style.BackColor = Color.Red;
                    bSkip = true;
                }
                if (alarmListDataGridView.Rows[i].Cells[1].Value == null || ((string)alarmListDataGridView.Rows[i].Cells[1].Value).Length == 0)
                {
                    alarmListDataGridView.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    bSkip = true;
                }
                if (alarmListDataGridView.Rows[i].Cells[2].Value == null || ((string)alarmListDataGridView.Rows[i].Cells[2].Value).Length == 0)
                {
                    alarmListDataGridView.Rows[i].Cells[2].Style.BackColor = Color.Red;
                    bSkip = true;
                }
                if (alarmListDataGridView.Rows[i].Cells[3].Value == null)
                    alarmListDataGridView.Rows[i].Cells[3].Value = false;
                if (alarmListDataGridView.Rows[i].Cells[4].Value == null)
                    alarmListDataGridView.Rows[i].Cells[4].Value = false;
                if (alarmListDataGridView.Rows[i].Cells[5].Value == null)
                    alarmListDataGridView.Rows[i].Cells[5].Value = false;
                if (alarmListDataGridView.Rows[i].Cells[6].Value == null)
                    alarmListDataGridView.Rows[i].Cells[6].Value = false;
                if (alarmListDataGridView.Rows[i].Cells[7].Value == null || ((string)alarmListDataGridView.Rows[i].Cells[7].Value).Length == 0)
                {
                    alarmListDataGridView.Rows[i].Cells[7].Style.BackColor = Color.Red;
                    bSkip = true;
                }
                if (alarmListDataGridView.Rows[i].Cells[8].Value == null || ((string)alarmListDataGridView.Rows[i].Cells[8].Value).Length == 0)
                {
                    alarmListDataGridView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    bSkip = true;
                }

                if (bSkip == false)
                {
                    AlarmObject alarmObj = new AlarmObject((string)alarmListDataGridView.Rows[i].Cells[0].Value);

                    alarmObj.Level = (string)alarmListDataGridView.Rows[i].Cells[1].Value;
                    alarmObj.Type = (string)alarmListDataGridView.Rows[i].Cells[2].Value;
                    alarmObj.Reset = (bool)alarmListDataGridView.Rows[i].Cells[3].Value;
                    alarmObj.Retry = (bool)alarmListDataGridView.Rows[i].Cells[4].Value;
                    alarmObj.Skip = (bool)alarmListDataGridView.Rows[i].Cells[5].Value;
                    alarmObj.Continue = (bool)alarmListDataGridView.Rows[i].Cells[6].Value;
                    alarmObj.Message = (string)alarmListDataGridView.Rows[i].Cells[7].Value;
                    alarmObj.TroubleShooting = (string)alarmListDataGridView.Rows[i].Cells[8].Value;

                    alarmListTemp.Add(alarmObj);
                }
                else
                    bFault = true;
            }
            if (bFault == false)
            {
                alarmList = alarmListTemp;
                return true;
            }
            else
                return false;
        }

        private void AlarmListPanelControl_Load(object sender, EventArgs e)
        {
            SetDataToUI();
            // 自動更新每一個Row的高度
            for (int i = 0; i < alarmListDataGridView.Rows.Count; i++)
            {
                Int32 preferredNormalContentHeight =
                    alarmListDataGridView.Rows[i].GetPreferredHeight(alarmListDataGridView.Rows[i].Index,
                    DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
                    alarmListDataGridView.Rows[i].DefaultCellStyle.Padding.Bottom;

                alarmListDataGridView.Rows[i].Height = preferredNormalContentHeight;
            }

            bInit = true;
        }

        private void alarmListDataGridView_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
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

        private void alarmListDataGridView_Sorted(object sender, EventArgs e)
        {
            // 自動更新每一個Row的高度
            for (int i = 0; i < alarmListDataGridView.Rows.Count; i++)
            {
                Int32 preferredNormalContentHeight =
                    alarmListDataGridView.Rows[i].GetPreferredHeight(alarmListDataGridView.Rows[i].Index,
                    DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
                    alarmListDataGridView.Rows[i].DefaultCellStyle.Padding.Bottom;

                alarmListDataGridView.Rows[i].Height = preferredNormalContentHeight;
            }
        }

        private void newAlarmToolStripButton_Click(object sender, EventArgs e)
        {
            alarmListDataGridView.Rows.Add(1);
            newAlarmToolStripButton.Enabled = false;
            saveToolStripButton.Enabled = true;
        }

        private void removeAlarmToolStripButton_Click(object sender, EventArgs e)
        {
            alarmListDataGridView.Rows[alarmListDataGridView.SelectedCells[0].RowIndex].Selected = true;
            if (MessageBox.Show(this, "Are you sure to delete this alarm?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string alarmCode = (string)alarmListDataGridView.Rows[alarmListDataGridView.SelectedCells[0].RowIndex].Cells[0].Value;
                alarmListDataGridView.Rows.RemoveAt(alarmListDataGridView.SelectedCells[0].RowIndex);
                for (int i = 0; i < alarmList.Count; i++)
                {
                    if (alarmList[i].AlarmCode.Equals(alarmCode) == true)
                    {
                        alarmList.RemoveAt(i);
                        SaveToIniFile(strINIPath);
                        break;
                    }
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure to save these changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Validate();
                if (GetDataFromUI() == true)
                {
                    SaveToIniFile(strINIPath);

                    for (int i = 0; i < alarmListDataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < alarmListDataGridView.Columns.Count; j++)
                        {
                            alarmListDataGridView.Rows[i].Cells[j].Style.BackColor = Color.White;
                        }
                    }
                    newAlarmToolStripButton.Enabled = true;
                    saveToolStripButton.Enabled = false;

                    alarmListDataGridView_Sorted(alarmListDataGridView, null);
                }
                else
                    MessageBox.Show(this, "Invalid Format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void alarmListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (bInit == true)
            {

                alarmListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                saveToolStripButton.Enabled = true;
            }
        }

        public bool GetAlarmInfo(ref AlarmObject alarmObject)
        {
            for (int i = 0; i < alarmList.Count; i++)
            {
                if (alarmList[i].AlarmCode.Equals(alarmObject.AlarmCode) == true)
                {
                    alarmObject.Message = alarmList[i].Message;
                    alarmObject.Level = alarmList[i].Level;
                    alarmObject.TroubleShooting = alarmList[i].TroubleShooting;
                    alarmObject.Type = alarmList[i].Type;
                    alarmObject.Reset = alarmList[i].Reset;
                    alarmObject.Retry = alarmList[i].Retry;
                    alarmObject.Skip = alarmList[i].Skip;
                    alarmObject.Continue = alarmList[i].Continue;
                    return true;
                }
            }
            return false;
        }
    }

    public class AlarmObject : Object
    {
        private long identifier;
        private string alarmCode;
        private string level;
        private string type;
        private string message;
        private string troubleShooting;
        private string reportTime;
        private string releaseTime = "";
        private string resetResult = "";

        private Boolean bReset = false;
        private Boolean bRetry = false;
        private Boolean bSkip = false;
        private Boolean bContinue = false;

        public AlarmObject(string alarmCode)
        {
            AlarmCode = alarmCode;
            Identifier = DateTime.Now.Ticks;
        }

        public long Identifier
        {
            get
            {
                return identifier;
            }
            set
            {
                identifier = value;
            }
        }
        public string AlarmCode
        {
            get
            {
                return alarmCode;
            }
            set
            {
                alarmCode = value;
            }
        }
        public string Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        public string TroubleShooting
        {
            get
            {
                return troubleShooting;
            }
            set
            {
                troubleShooting = value;
            }
        }
        public string ReportTime
        {
            get
            {
                return reportTime;
            }
            set
            {
                reportTime = value;
            }
        }
        public string ReleaseTime
        {
            get
            {
                return releaseTime;
            }
            set
            {
                releaseTime = value;
            }
        }
        public Boolean Reset
        {
            get
            {
                return bReset;
            }
            set
            {
                bReset = value;
            }
        }
        public Boolean Retry
        {
            get
            {
                return bRetry;
            }
            set
            {
                bRetry = value;
            }
        }
        public Boolean Skip
        {
            get
            {
                return bSkip;
            }
            set
            {
                bSkip = value;
            }
        }
        public Boolean Continue
        {
            get
            {
                return bContinue;
            }
            set
            {
                bContinue = value;
            }
        }
        public string ResetResult
        {
            get
            {
                return resetResult;
            }
            set
            {
                resetResult = value;
            }
        }
    }
}
