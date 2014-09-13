using System;
using System.Collections.Generic;
using System.Text;
using SDDEMsg;

namespace Scenario
{
    class TowerSet
    {
        static private TowerSet g_singleton;

        internal const int _LED_TOTAL_ = 7;

        internal const int _STATUS_TOTAL_ = 10;

        internal const int _TOWER_STATUS_DEFAULT_ = 0;
        internal const int _TOWER_STATUS_RUNNING_ = 1;
        internal const int _TOWER_STATUS_IDLE_ = 2;
        internal const int _TOWER_STATUS_ALARM_ = 3;
        internal const int _TOWER_STATUS_MANUAL_ = 4;
        internal const int _TOWER_STATUS_HOST_OFF_ = 5;
        internal const int _TOWER_STATUS_LOCAL_IN_ = 6;
        internal const int _TOWER_STATUS_DOWN_ = 7;
        internal const int _TOWER_STATUS_MAINTENANCE_ = 8;
        internal const int _TOWER_STATUS_PREPARATION_ = 9;

        internal const int _TOWER_STATUS_PREVIOUS_ = 100;

        internal const int _TOWER_OBJ_BUZZER1_ = 0;
        internal const int _TOWER_OBJ_BUZZER2_ = 1;

        internal const int _TOWER_OBJ_RED_ = 2;
        internal const int _TOWER_OBJ_YELLOW_ = 3;
        internal const int _TOWER_OBJ_GREEN_ = 4;
        internal const int _TOWER_OBJ_BLUE_ = 5;
        internal const int _TOWER_OBJ_OP1_ = 6;
        internal const int _TOWER_OBJ_OP2_ = 7;

        private static string g_strOldCmd = null;

        private int m_iTowerStatus = _TOWER_STATUS_DEFAULT_;
        private CCTower[] g_objSignalMode = new CCTower[TowerSet._STATUS_TOTAL_];
        private CCSignalTable g_objCurrentSignalTable = new CCSignalTable();

        public TowerSet()
        {
            g_singleton = this;
            for (int iIndex = 0; iIndex < g_objSignalMode.Length; iIndex++)
            {
               g_objSignalMode[iIndex] = new CCTower();
            }
        }

        public static TowerSet GetSingleton()
        {
            if (g_singleton == null)
            {
                g_singleton = new TowerSet();
            }
            return g_singleton;
        }

        // 設定目前警示狀態, Running, Alarm, Error......
        public int TowerSet_ChangeSignal(int p_iStatus)
        {
            int iOldStatus = -1;
            int iNewStatus = -1;

            string strNewCmd;
	
	        m_iTowerStatus = p_iStatus;

            switch (m_iTowerStatus)
            {
                case _TOWER_STATUS_DEFAULT_:
                case _TOWER_STATUS_RUNNING_:
                    g_objCurrentSignalTable = g_objSignalMode[p_iStatus].objSignalTable;
                    if (iNewStatus != p_iStatus)
                    {
                        iOldStatus = iNewStatus;
                        iNewStatus = p_iStatus;
                    }
                    break;

                case _TOWER_STATUS_ALARM_:
                case _TOWER_STATUS_DOWN_:
                case _TOWER_STATUS_MAINTENANCE_:
                case _TOWER_STATUS_IDLE_:
                case _TOWER_STATUS_MANUAL_:
                case _TOWER_STATUS_HOST_OFF_:
                case _TOWER_STATUS_LOCAL_IN_:
                case _TOWER_STATUS_PREPARATION_:
                    g_objCurrentSignalTable = g_objSignalMode[p_iStatus].objSignalTable;
                    break;

                case _TOWER_STATUS_PREVIOUS_:
                    g_objCurrentSignalTable = g_objSignalMode[iNewStatus].objSignalTable;
                    break;

                default:
                    g_objCurrentSignalTable = g_objSignalMode[_TOWER_STATUS_DOWN_].objSignalTable;
                    break;
            }

            strNewCmd = "C998," + g_objCurrentSignalTable.aiType[_TOWER_OBJ_BUZZER1_] + ","
                                + g_objCurrentSignalTable.aiType[_TOWER_OBJ_BUZZER2_] + ","
                                + g_objCurrentSignalTable.aiType[_TOWER_OBJ_RED_] + ","
                                + g_objCurrentSignalTable.aiType[_TOWER_OBJ_YELLOW_] + ","
                                + g_objCurrentSignalTable.aiType[_TOWER_OBJ_GREEN_] + ","
                                + g_objCurrentSignalTable.aiType[_TOWER_OBJ_BLUE_] + ","
                                + g_objCurrentSignalTable.aiType[_TOWER_OBJ_OP1_];

            // 避免重複送出相同訊息，雖然it is OK.
            if (g_strOldCmd==null || g_strOldCmd.CompareTo(strNewCmd) != 0)
            {
                SDDE.GetSingleton().SendMessageToTK(strNewCmd);
                g_strOldCmd = strNewCmd;
            }

            return 0;
        }
    }

    class CCSignalTable
    {
        public CCSignalTable()
        {
        }

        internal int[] aiType = new int[TowerSet._LED_TOTAL_];
    }

    class CCTower
    {
        public CCTower()
        {
        }

        internal CCSignalTable objSignalTable = new CCSignalTable();
    }
}
