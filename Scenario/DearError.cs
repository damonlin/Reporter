using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SDDEMsg;

namespace Scenario
{
    public class DearErrorCode 
    {
        //20090318 志忠~~宣告一個Timer
        private System.Windows.Forms.Timer TKMSGTIMER;
        //20090323 志忠~~new出DearError_Def物件
        DearError_Def InitDearErrorCode = new DearError_Def();

        public DearErrorCode()
        {
           
        }

        //20090323 志忠~~啟動Timer的建構子
        public DearErrorCode(bool StartTimer)
        {
            //20090318 志忠~~new出Timer
            this.TKMSGTIMER = new Timer();
            this.TKMSGTIMER.Enabled = true;
            this.TKMSGTIMER.Interval = 500;
            this.TKMSGTIMER.Tick += new System.EventHandler(this.TKMSGTIMER_Tick);
        }

        //20090318 志忠~~觸發Timer
        private void TKMSGTIMER_Tick(object sender, EventArgs e)
        {
            int iSDDEStatus = 0;

            //20090318 志忠~~取得MMI和TK的連線狀態
            iSDDEStatus = SDDE.GetSingleton().GetSDDEStatus();

            if (iSDDEStatus != 1)
            {
                //20090318 志忠~~MMI和TK連線
                SDDE.GetSingleton().Connect();
            }

            //20090318 志忠~~用來接收TK傳過來的Message
            StringBuilder szReturnChar = new StringBuilder();

            while (SDDE.GetSingleton().GetMessageFromTK(szReturnChar) == 0)
            {

                if (szReturnChar[0] == 'A' && szReturnChar[1] == '0' && szReturnChar[2] == '2' && szReturnChar[3] == '3')
                {
                    //發Alarm Message
                    Common.GlobalValue.AlarmQueue.Enqueue(szReturnChar.ToString());
                }
                else if (szReturnChar[0] == 'R' || szReturnChar[0] == 'E' || szReturnChar[0] == 'A' || szReturnChar[0] == 'X')
                {
                    //20090323 志忠~~呼叫比對DearErrorCode的函式
                    InitDearErrorCode.strcmpDearErrorCode(szReturnChar);
                }
                else
                {
                    //發Alarm Message
                    Common.GlobalValue.AlarmQueue.Enqueue(szReturnChar.ToString());
                }
            }

        }

        // =====================================================================
        //      R100    旋轉、翻轉 初始化Home
        // =====================================================================
        public int Rtn_AllMotorHome(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }
            
            return 0;
        }

        // =====================================================================
        //      R101    鏡頭切換軸移動
        // =====================================================================
        public int Rtn_CCDAxleChangeMove(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.PatternFind.PatternFindIdx == 25)
                        {
                            CIM.PatternFind.PatternFindIdx = 30;
                        }
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R201    自動入料
        // =====================================================================
        public int Rtn_AutoLoad(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        if (CIM.Scenario.LULIndex == 500)
                            CIM.Scenario.LULIndex = 600;

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R202    自動出料
        // =====================================================================
        public int Rtn_AutoUnload(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.Scenario.LULIndex == 2400)
                            CIM.Scenario.LULIndex = 2500;
                        else if (CIM.Scenario.LULIndex == 3200)
                            CIM.Scenario.LULIndex = 3300;
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R203    上半部入料流程
        // =====================================================================
        public int Rtn_UpperLoadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.Scenario.LULIndex == 700)
                            CIM.Scenario.LULIndex = 800;          
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R204    上半部出料流程
        // =====================================================================
        public int Rtn_UpperUnloadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.Scenario.LULIndex == 2110)
                            CIM.Scenario.LULIndex = 2120;
                        else if (CIM.Scenario.LULIndex == 2930)
                            CIM.Scenario.LULIndex = 2940;
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R205    下半部入料流程
        // =====================================================================
        public int Rtn_BottomLoadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.Scenario.LULIndex == 900)
                            CIM.Scenario.LULIndex = 1000;
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R206    最後一片出料流程
        // =====================================================================
        public int Rtn_LastUnloadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.Scenario.LULIndex == 2910)
                            CIM.Scenario.LULIndex = 2920;
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R300    平台出始化流程
        // =====================================================================
        public int Rtn_StageInitProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R301    平台自動入料流程
        // =====================================================================
        public int Rtn_StageAutoLoadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.Scenario.StageIndex == 200)
                            CIM.Scenario.StageIndex = 300;

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R302    平台自動出料流程
        // =====================================================================
        public int Rtn_StageAutoUnloadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.Scenario.StageIndex == 1400)
                            CIM.Scenario.StageIndex = 1500;
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R303    平台預夾流程
        // =====================================================================
        public int Rtn_StageBeforehandClipProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.Scenario.ScenarioIndex == 6)
                            CIM.Scenario.ScenarioIndex = 10; 
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R304    雷射修補流程
        // =====================================================================
        public int Rtn_LaserRepairProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R305    點燈流程
        // =====================================================================
        public int Rtn_LampProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.Scenario.StageIndex == 1100)
                            CIM.Scenario.StageIndex = 1200;
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R401    S&G&L 移動
        // =====================================================================
        public int Rtn_SGL_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:
                        if (CIM.PatternFind.PatternFindIdx == 45)
                        {
                            CIM.PatternFind.PatternFindIdx = 50;
                        }

                        //if (CIM.Scenario.ScenarioIndex == 131)
                        //    CIM.Scenario.ScenarioIndex = 132;

                        if (CIM.Scenario.StageIndex == 600)
                            CIM.Scenario.StageIndex = 700;
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R402    QS1&QG1 移動
        // =====================================================================
        public int Rtn_QS1QG1_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R403    QS2&QG2 移動
        // =====================================================================
        public int Rtn_QS2QG2_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R404    QS3&QG3 移動
        // =====================================================================
        public int Rtn_QS3QG3_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }


        // =====================================================================
        //      R405    QS4&QG4 移動
        // =====================================================================
        public int Rtn_QS4QG4_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R406    QS5&QG5 移動
        // =====================================================================
        public int Rtn_QS5QG5_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R407    QS6&QG6 移動
        // =====================================================================
        public int Rtn_QS6QG6_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R408    QS7&QG7 移動
        // =====================================================================
        public int Rtn_QS7QG7_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R409    B1&B2 移動
        // =====================================================================
        public int Rtn_B1B2_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R410    C1C2 移動
        // =====================================================================
        public int Rtn_C1C2_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R411    TS&TG 移動
        // =====================================================================
        public int Rtn_TSTG_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R501    S&G&L Box Control
        // =====================================================================
        public int Rtn_SGL_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R502    QS1&QG1 Box Control
        // =====================================================================
        public int Rtn_QS1QG1_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R503    QS2&QG2 Box Control
        // =====================================================================
        public int Rtn_QS2QG2_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R504    QS3&QG3 Box Control
        // =====================================================================
        public int Rtn_QS3QG3_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R505    QS4&QG4 Box Control
        // =====================================================================
        public int Rtn_QS4QG4_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R506    QS5&QG5 Box Control
        // =====================================================================
        public int Rtn_QS5QG5_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R507    QS6&QG6 Box Control
        // =====================================================================
        public int Rtn_QS6QG6_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R508    QS7&QG7 Box Control
        // =====================================================================
        public int Rtn_QS7QG7_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R509    C1C2 Box Control
        // =====================================================================
        public int Rtn_C1C2_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      R510    TS&TG Box Control
        // =====================================================================
        public int Rtn_TSTG_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 志忠~~參數為字串,使用時須轉型
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("溢位");
            }

            return 0;
        }

        // =====================================================================
        //      Not Define Code
        // =====================================================================
        public int Rtn_NotDefineCode(string l_szTempChar)
        {

            Common.GlobalValue.AlarmQueue.Enqueue(l_szTempChar);

            return 0;
        }
    }
}