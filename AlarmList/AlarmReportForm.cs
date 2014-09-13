using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using IniTool;
using Microsoft.VisualBasic.FileIO;
using Datalog;
using Common;

namespace AlarmList
{
    public enum AlarmLogType
    {
        Occur = 0,
        Release = 1
    }

    public partial class AlarmReportForm : Form
    {
        private static AlarmReportForm singleton;
        private List<AlarmObject> reportAlarmList = new List<AlarmObject>();
        public DatalogUnitControl AlarmLog = new DatalogUnitControl("Alarm Log");

        private const string strINIPath = "INI\\DataLog.ini";
        private string strLogName = "Alarm Log";
        private bool bInit = false;

        protected AlarmReportForm()
        {
            InitializeComponent();

            LoadFromIniFile(strINIPath);
            UpdateUIFromINI();

            // 建立資料庫連線 
            //dbConn = new MySQLConnection(new MySQLConnectionString("localhost", "mysql", "root", "administrator", 3306).AsString);
            //dbConn.Open();

            bInit = true;
        }

        ~AlarmReportForm()
        {
            // 關閉資料庫連線  
            //dbConn.Close();  
        }

        public static AlarmReportForm getSingleton()
        {
            if (singleton == null)
                singleton = new AlarmReportForm();
            return singleton;
        }

        private void LoadFromIniFile(string iniFilePath)
        {
            IniFile iniFile = new IniFile(iniFilePath);

            autoDeleteLogCheckBox.Checked = iniFile.GetInt16(strLogName, "EnableAutoDeleteLog", 1) >= 1 ? true : false;
            autoDeleteDaysNumeric.Value = iniFile.GetInt16(strLogName, "AutoDeleteLogDays", 90);
        }

        private void SaveToIniFile(string iniFilePath)
        {
            IniFile iniFile = new IniFile(iniFilePath);

            iniFile.WriteValue(strLogName, "EnableAutoDeleteLog", autoDeleteLogCheckBox.Checked == true ? 1 : 0);
            iniFile.WriteValue(strLogName, "AutoDeleteLogDays", (int)autoDeleteDaysNumeric.Value);
        }

        private void UpdateUIFromINI()
        {
            autoDeleteDaysNumeric.Enabled = autoDeleteLogCheckBox.Checked;
        }

        public void Log(AlarmObject alarmObj, AlarmLogType logType)
        {
            switch (logType)
            {
                case AlarmLogType.Occur:
                    AlarmLog.Log(alarmObj.Identifier + " " + alarmObj.AlarmCode + " Occurred ");
                    break;

                case AlarmLogType.Release:
                    AlarmLog.Log(alarmObj.Identifier + " " + alarmObj.AlarmCode + " Released by " + alarmObj.ResetResult);
                    break;
            }
        }

        private void InsertAlarmToAlarmReportTable(AlarmObject alarmObject)
        {
            alarmReportDataGridView.Rows.Add(1);

            int iRowIdx = alarmReportDataGridView.Rows.Count - 1;
            alarmReportDataGridView.Rows[iRowIdx].SetValues(iRowIdx + 1,
                                          alarmObject.AlarmCode,
                                          alarmObject.Level,
                                          alarmObject.Type,
                                          alarmObject.Message,
                                          DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"));
            // 更新Row的高度
            Int32 preferredNormalContentHeight =
                   alarmReportDataGridView.Rows[iRowIdx].GetPreferredHeight(alarmReportDataGridView.Rows[iRowIdx].Index,
                   DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
                   alarmReportDataGridView.Rows[iRowIdx].DefaultCellStyle.Padding.Bottom;

            alarmReportDataGridView.Rows[iRowIdx].Height = preferredNormalContentHeight;
        }

        private void InsertAlarmToLogListTable(List<AlarmObject> AlarmLogList)
        {
            alarmLogDataGridView.Rows.Clear();

            foreach (AlarmObject nowAlarmObj in AlarmLogList)
            {
                alarmLogDataGridView.Rows.Add(1);

                int iRowIdx = alarmLogDataGridView.Rows.Count - 1;
                alarmLogDataGridView.Rows[iRowIdx].SetValues(iRowIdx + 1,
                                              nowAlarmObj.AlarmCode,
                                              nowAlarmObj.Level,
                                              nowAlarmObj.Type,
                                              nowAlarmObj.Message,
                                              nowAlarmObj.ReportTime,
                                              nowAlarmObj.ReleaseTime,
                                              nowAlarmObj.ResetResult);

                // 更新Row的高度
                Int32 preferredNormalContentHeight =
                       alarmLogDataGridView.Rows[iRowIdx].GetPreferredHeight(alarmLogDataGridView.Rows[iRowIdx].Index,
                       DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
                       alarmLogDataGridView.Rows[iRowIdx].DefaultCellStyle.Padding.Bottom;

                alarmLogDataGridView.Rows[iRowIdx].Height = preferredNormalContentHeight;
            }
        }

        private void UpdateAlarmLogTable()
        {
            if (alarmTabControlEX.SelectedIndex == 1)
            {
                searchLogButton_CheckedChanged(null, null);
                for (int iRowIdx = 0; iRowIdx < alarmLogDataGridView.RowCount; iRowIdx++)
                {
                    alarmLogDataGridView.Rows[iRowIdx].Cells[0].Value = string.Format("{0}", iRowIdx + 1);
                }
            }
            // 更新每一個Row的高度
            alarmLogDataGridView_Sorted(null, null);
        }

        public int ReportAlarm(string alarmCode)
        {
            AlarmObject alarmObject = new AlarmObject(alarmCode);

            if (AlarmListPanelControl.getSingleton().GetAlarmInfo(ref alarmObject) == true)
            {

            }
            else
            {
                alarmObject.Message = "This alarm is not being defined!";
                alarmObject.Reset = true;
            }

            reportAlarmList.Add(alarmObject);

            Log(alarmObject, AlarmLogType.Occur);

            if (alarmReportDataGridView.Rows.Count > 0)
                alarmReportDataGridView.Rows[0].Selected = true;

            InsertAlarmToAlarmReportTable(alarmObject);

            alarmTabControlEX.SelectedTab = currentAlarmTabPageEX;            

            return 0;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void alarmTabControlEX_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    resetPanel.Visible = true;
                    break;
                case 1:
                    resetPanel.Visible = false;

                    searchLogButton_CheckedChanged(null, null);
                    break;
            }
        }

        private void AlarmForm_Load(object sender, EventArgs e)
        {

        }

        private void buzzerStopButton_Click(object sender, EventArgs e)
        {

            ReportAlarm("00230001");
            ReportAlarm("00230111");
            ReportAlarm("00230022");
            ReportAlarm("00230010");
            ReportAlarm("00230055");
            ReportAlarm("00230033");
        }

        private void alarmLogDataGridView_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
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

        private void alarmLogDataGridView_Sorted(object sender, EventArgs e)
        {
            // 更新每一個Row的高度
            for (int i = 0; i < alarmLogDataGridView.Rows.Count; i++)
            {
                Int32 preferredNormalContentHeight =
                    alarmLogDataGridView.Rows[i].GetPreferredHeight(alarmLogDataGridView.Rows[i].Index,
                    DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
                    alarmLogDataGridView.Rows[i].DefaultCellStyle.Padding.Bottom;

                alarmLogDataGridView.Rows[i].Height = preferredNormalContentHeight;
            }
        }

        private void alarmReportDataGridView_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            alarmLogDataGridView_RowHeightChanged(sender, e);
        }

        private void alarmReportDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // 滑鼠點選Table時, 顯示對應的Reset Button
            if (alarmReportDataGridView.SelectedRows.Count > 0)
            {
                troubleShootingTextBox.Text = reportAlarmList[alarmReportDataGridView.SelectedRows[0].Index].TroubleShooting;

                // Reset
                alarmResetButton.Visible = false;
                alarmRetryButton.Visible = false;
                alarmSkipButton.Visible = false;
                alarmContinueButton.Visible = false;
                // Update
                int ResetButtonCounter = 0;
                if (reportAlarmList[alarmReportDataGridView.SelectedRows[0].Index].Reset == true)
                {
                    alarmResetButton.Visible = true;
                    ResetButtonCounter++;
                }
                if (reportAlarmList[alarmReportDataGridView.SelectedRows[0].Index].Retry == true)
                {
                    alarmRetryButton.Location = new Point(3 + 96 * ResetButtonCounter, 1);

                    alarmRetryButton.Visible = true;
                    ResetButtonCounter++;
                }
                if (reportAlarmList[alarmReportDataGridView.SelectedRows[0].Index].Skip == true)
                {
                    alarmSkipButton.Location = new Point(3 + 96 * ResetButtonCounter, 1);

                    alarmSkipButton.Visible = true;
                    ResetButtonCounter++;
                }
                if (reportAlarmList[alarmReportDataGridView.SelectedRows[0].Index].Continue == true)
                {
                    alarmContinueButton.Location = new Point(3 + 96 * ResetButtonCounter, 1);

                    alarmContinueButton.Visible = true;
                    ResetButtonCounter++;
                }
            }
        }

        private void alarmReportDataGridView_Sorted(object sender, EventArgs e)
        {
            // 更新每一個Row的高度
            for (int i = 0; i < alarmReportDataGridView.Rows.Count; i++)
            {
                Int32 preferredNormalContentHeight =
                    alarmReportDataGridView.Rows[i].GetPreferredHeight(alarmReportDataGridView.Rows[i].Index,
                    DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
                    alarmReportDataGridView.Rows[i].DefaultCellStyle.Padding.Bottom;

                alarmReportDataGridView.Rows[i].Height = preferredNormalContentHeight;
            }
        }

        private void alarmResetButton_Click(object sender, EventArgs e)
        {
            if (alarmReportDataGridView.SelectedRows.Count > 0)
            {
                AlarmObject alarmObject = (AlarmObject)reportAlarmList[alarmReportDataGridView.SelectedRows[0].Index];

                if (sender.Equals(alarmResetButton) == true)
                {
                    alarmObject.ResetResult = "Reset";
                }
                else if (sender.Equals(alarmRetryButton) == true)
                {
                    alarmObject.ResetResult = "Retry";
                }
                else if (sender.Equals(alarmSkipButton) == true)
                {
                    alarmObject.ResetResult = "Skip";
                }
                else if (sender.Equals(alarmContinueButton) == true)
                {
                    alarmObject.ResetResult = "Cont.";
                }

                // 紀錄Release時間
                //alarmObject.ReleaseTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff");
                // 更新至Alarm Log
                Log(alarmObject, AlarmLogType.Release);
                // 從AlarmList移除
                reportAlarmList.RemoveAt(alarmReportDataGridView.SelectedRows[0].Index);
                // 更新Alarm List Table
                alarmReportDataGridView.Rows.RemoveAt(alarmReportDataGridView.SelectedRows[0].Index);
                for (int iRowIdx = 0; iRowIdx < reportAlarmList.Count; iRowIdx++)
                    alarmReportDataGridView.Rows[iRowIdx].Cells[0].Value = string.Format("{0}", iRowIdx + 1);

                // 更新每一個Row的高度
                alarmReportDataGridView_Sorted(null, null);

                if (alarmReportDataGridView.Rows.Count > 0)
                    alarmReportDataGridView.Rows[0].Selected = true;
                else
                {
                    // Reset
                    troubleShootingTextBox.Text = "";

                    alarmResetButton.Visible = false;
                    alarmRetryButton.Visible = false;
                    alarmSkipButton.Visible = false;
                    alarmContinueButton.Visible = false;
                }
                
            }
        }
        private void searchLogButton_CheckedChanged(object sender, EventArgs e)
        {
            ArrayList strLogFilePathArray = new ArrayList();
            List<AlarmObject> AlarmLogList = new List<AlarmObject>();
            string szSearchCode = "";
            DateTime startTime = new DateTime(1l);
            DateTime endTime = new DateTime(1l);


            alarmLogDataGridView.Visible = false;

            if (showAllDaysLogButton.Checked == true)
            {
                // 取出資料夾內各個檔案檔名
                DirectoryInfo di = new DirectoryInfo(AlarmLog.LogFloder);
                // Create an array representing the files in the current directory.
                FileInfo[] fi = di.GetFiles();
                // Print out the names of the files in the current directory.
                foreach (FileInfo fiTemp in fi)
                {
                    if (fiTemp.Name.Contains(".Log") == true || fiTemp.Name.Contains(".log") == true)
                    {
                        strLogFilePathArray.Add(string.Format("{0}\\{1}", AlarmLog.LogFloder, fiTemp.Name));
                    }
                }
            }
            else if (showTodayLogButton.Checked == true)
            {
                string strFilaPath;
                strFilaPath = string.Format("{0}\\{1}-{2}.Log", AlarmLog.LogFloder, DateTime.Now.ToString("yyyy-MM-dd"), strLogName);
                if (File.Exists(strFilaPath) == true)
                    strLogFilePathArray.Add(strFilaPath);
            }
            else if (showYesterdayLogButton.Checked == true)
            {
                string strFilaPath;
                strFilaPath = string.Format("{0}\\{1}-{2}.Log", AlarmLog.LogFloder, DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), strLogName);
                if (File.Exists(strFilaPath) == true)
                    strLogFilePathArray.Add(strFilaPath);
            }
            else if (showLastWeekLogButton.Checked == true)
            {
                string strFilaPath;
                for (int i = -6; i <= 0; i++)
                {
                    strFilaPath = string.Format("{0}\\{1}-{2}.Log", AlarmLog.LogFloder, DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"), strLogName);
                    if (File.Exists(strFilaPath) == true)
                        strLogFilePathArray.Add(strFilaPath);
                }
            }
            else if (showLastMonthLogButton.Checked == true)
            {
                string strFilaPath;
                for (int i = -29; i <= 0; i++)
                {
                    strFilaPath = string.Format("{0}\\{1}-{2}.Log", AlarmLog.LogFloder, DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"), strLogName);
                    if (File.Exists(strFilaPath) == true)
                        strLogFilePathArray.Add(strFilaPath);
                }
            }
            else if (showSearchLogButton.Checked == true)
            {
                if (searchByTimeCheckBox.CheckState == CheckState.Checked)
                {
                    startTime = DateTime.Parse(searchStartDatePicker.Value.ToString("yyyy/MM/dd") + " " + searchStartTimePicker.Value.ToString("HH:mm:ss"));
                    endTime = DateTime.Parse(searchEndDatePicker.Value.ToString("yyyy/MM/dd") + " " + searchEndTimePicker.Value.ToString("HH:mm:ss"));

                    if (endTime.Subtract(startTime).Ticks < 0)
                    {
                        MessageBox.Show(this, "Invalid Format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        int iDaysNum = endTime.Subtract(startTime).Days;

                        string strFilaPath;
                        for (int iDay = 0; iDay < iDaysNum; iDay++)
                        {
                            strFilaPath = string.Format("{0}\\{1}-{2}.Log", AlarmLog.LogFloder, startTime.AddDays(iDay).ToString("yyyy-MM-dd"), strLogName);
                            if (File.Exists(strFilaPath) == true)
                                strLogFilePathArray.Add(strFilaPath);
                        }
                    }
                }
                else
                {
                    strLogFilePathArray.AddRange(Directory.GetFiles(AlarmLog.LogFloder));
                }

                if (searchByCodeCheckBox.CheckState == CheckState.Checked)
                {
                    szSearchCode = searchCodeTextBox.Text;
                }
            }

            for (int i = 0; i < strLogFilePathArray.Count; i++)
            {
                string[] FileAllLines = File.ReadAllLines((string)strLogFilePathArray[i], Encoding.Default);
                for (int j = 0; j < FileAllLines.Length; j++)
                {
                    AlarmLogSpilt(ref AlarmLogList, FileAllLines[j], startTime, endTime, szSearchCode);
                }
            }
            InsertAlarmToLogListTable(AlarmLogList);

            // 更新每一個Row的高度
            alarmLogDataGridView_Sorted(null, null);

            alarmLogDataGridView.Visible = true;
        }

        private void searchByCodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            searchByCodePanel.Enabled = (searchByCodeCheckBox.CheckState == CheckState.Checked) ? true : false;
        }

        private void searchByTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            searchByTimePanel.Enabled = (searchByTimeCheckBox.CheckState == CheckState.Checked) ? true : false;
        }

        private void alarmLogDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == alarmLogDataGridView.Columns[0].Index)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void deleteAllLogsButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure to want delete all logs?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
        }

        private void autoDeleteLogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            autoDeleteDaysNumeric.Enabled = autoDeleteLogCheckBox.Checked;
            if (bInit == true)
                SaveToIniFile(strINIPath);
        }

        private void AlarmLogSpilt(ref List<AlarmObject> AlarmLogList, string szInfo, DateTime startTime, DateTime endTime, string szCode)
        {
            string[] szAllInfo = szInfo.Split(' ');
            bool bCreatNewAlarmObject = true;

            if (startTime.Ticks > 1 && endTime.Ticks > 1)
            {
                DateTime logTime = DateTime.Parse(szAllInfo[0] + " " + szAllInfo[1]);

                if (logTime.Ticks < startTime.Ticks || logTime.Ticks > endTime.Ticks)
                {
                    return;
                }
            }

            if (szCode != "" && szAllInfo[3] != szCode)
            {
                return;
            }

            foreach (AlarmObject tmpAlarm in AlarmLogList)
            {
                if (tmpAlarm.Identifier == long.Parse(szAllInfo[2]) && tmpAlarm.AlarmCode == szAllInfo[3])
                {
                    if (szAllInfo[4] == "Released")
                    {
                        tmpAlarm.ReleaseTime = szAllInfo[0] + " " + szAllInfo[1];
                        tmpAlarm.ResetResult = szAllInfo[6];
                        bCreatNewAlarmObject = false;
                        return;
                    }
                }
            }

            if (bCreatNewAlarmObject)
            {
                AlarmObject tmpAlarm = new AlarmObject(szAllInfo[3]);

                if (AlarmListPanelControl.getSingleton().GetAlarmInfo(ref tmpAlarm) == true)
                {

                }
                else
                {
                    tmpAlarm.Message = "This alarm is not being defined!";
                    tmpAlarm.Reset = true;
                }

                tmpAlarm.Identifier = long.Parse(szAllInfo[2]);
                tmpAlarm.ReportTime = szAllInfo[0] + " " + szAllInfo[1];
                tmpAlarm.ReleaseTime = "";
                AlarmLogList.Add(tmpAlarm);
            }
        }
    }
}