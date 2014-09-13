using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
//using TKUnit;

namespace Scenario
{
	public class DealError
	{
        private static bool bEnabled = false;
		private static DealError g_singleton;
		delegate int CmdFuncPointer(string p_strCmd);
        static Hashtable CommandProcessTable = new Hashtable();
		CmdFuncPointer CmdFunc;
		object objThisLock = new object();

		//以下為模組資料處理================================================================
		private void InitCommandTable()
		{
            //A Code
            CommandProcessTable.Add("AXXX", (CmdFuncPointer)ARtn_XXX);                              //AXXX, XXX

            //R Code
            CommandProcessTable.Add("R100", (CmdFuncPointer)MacroHomeCompleteTest);                 //R100, XXX
            CommandProcessTable.Add("R101", (CmdFuncPointer)MacroHomeCompleteTest);                 //R100, XXX
            CommandProcessTable.Add("R102", (CmdFuncPointer)MacroHomeCompleteTest);                 //R100, XXX

            CommandProcessTable.Add("R201", (CmdFuncPointer)LoadRequestComplete);                 //R201, XXX
            CommandProcessTable.Add("R202", (CmdFuncPointer)UnloadRequestComplete);                 //R202, XXX
            CommandProcessTable.Add("R203", (CmdFuncPointer)TopPanelLoad);                 //R203, XXX
            CommandProcessTable.Add("R204", (CmdFuncPointer)BottonPanelUnload);                 //R204, XXX
            CommandProcessTable.Add("R205", (CmdFuncPointer)BottonPanelLoad);                 //R205, XXX
            CommandProcessTable.Add("R206", (CmdFuncPointer)LastPanelLoad);                 //R206, XXX

            CommandProcessTable.Add("R300", (CmdFuncPointer)StageInitialize);                 //R300, XXX
            CommandProcessTable.Add("R301", (CmdFuncPointer)StageLoad);                 //R301, XXX
            CommandProcessTable.Add("R302", (CmdFuncPointer)StageUnload);                 //R302, XXX
            CommandProcessTable.Add("R303", (CmdFuncPointer)StagePreClamp);                 //R303, XXX
            CommandProcessTable.Add("R304", (CmdFuncPointer)StageLaserRepair);                 //R304, XXX
            CommandProcessTable.Add("R305", (CmdFuncPointer)StageLightOn);                 //R305, XXX
		}

		public int DealErrorCommandForTKCall(string p_strCmd)
		{
            if (CommandProcessTable.Contains(p_strCmd.Substring(0, 4)))
            {
                CmdFunc = (CmdFuncPointer)(CommandProcessTable[p_strCmd.Substring(0, 4)]);

                lock (objThisLock)
                {
                    CmdFunc(p_strCmd);
                }
            }
            else
            {
                return -1;
            }

			return 0;
		}

		public int DealErrorCommandForMMICall(string p_strCmd)
		{
            if (CommandProcessTable.Contains(p_strCmd.Substring(0, 4)))
            {
                CmdFunc = (CmdFuncPointer)(CommandProcessTable[p_strCmd.Substring(0, 4)]);
                lock (objThisLock)
                {
                    CmdFunc(p_strCmd);
                }
            }
            else
            {
                return -1;
            }

			return 0;
		}

        
		//以下供外部程式呼叫使用=============================================================
		public static DealError GetSingleton()
		{
			if (g_singleton == null)
			{
				g_singleton = new DealError();
			}
			return g_singleton;
		}

		public void SendMessageToTK(string szCmd)
		{
			//TKUnit.Process.GetSingleton().ProcessCommandForMMICall(szCmd);
		}

		public DealError()
		{
            if (bEnabled)
                return;
            else
            {
                InitCommandTable();
                bEnabled = true;
            }
			// TK Process 初始化動作(例如:IO Trigger, Extend Function)
		}

		// 以下為使用者填入之程式碼(填入原本TK的Process Function)

        // =====================================================================
        //			AXXX, XXX
        // =====================================================================
        public int ARtn_XXX(string p_strCmd)		
        {
            return 0;
        }

        public int MacroHomeCompleteTest(string szCmd)
        {
            MessageBox.Show("Macro Home Complete Test OK Cmd = " + szCmd);
            return 0;
        }

        /// <summary>
        /// R201
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int LoadRequestComplete(string szCmd)
        {
            if (CIM.Scenario.ScenarioIndex == 20)
                CIM.Scenario.ScenarioIndex = 30;
            return 0;
        }

        /// <summary>
        /// R202
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int UnloadRequestComplete(string szCmd)
        {
            //MessageBox.Show("Macro Home Complete Test OK Cmd = " + szCmd);
            return 0;
        }

        /// <summary>
        /// R203
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int TopPanelLoad(string szCmd)
        {
            if (CIM.Scenario.ScenarioIndex == 70)
                CIM.Scenario.ScenarioIndex = 80;
            return 0;
        }

        /// <summary>
        /// R204
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int BottonPanelUnload(string szCmd)
        {
            if (CIM.Scenario.ScenarioIndex == 240)
                CIM.Scenario.ScenarioIndex = 250;
            return 0;
        }

        /// <summary>
        /// R205
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int BottonPanelLoad(string szCmd)
        {            
            if (CIM.Scenario.ScenarioIndex == 90)
                CIM.Scenario.ScenarioIndex = 100;
            return 0;
        }
            
        /// <summary>
        /// R206
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int LastPanelLoad(string szCmd)
        {
            if (CIM.Scenario.ScenarioIndex == 230)
                CIM.Scenario.ScenarioIndex = 250;
            return 0;
        }

        /// <summary>
        /// R300
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int StageInitialize(string szCmd)
        {
            //MessageBox.Show("Macro Home Complete Test OK Cmd = " + szCmd);
            return 0;
        }

        /// <summary>
        /// R301
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int StageLoad(string szCmd)
        {            
            if (CIM.Scenario.ScenarioIndex == 120)
                CIM.Scenario.ScenarioIndex = 130;
            return 0;
        }

        /// <summary>
        /// R302
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int StageUnload(string szCmd)
        {
            if (CIM.Scenario.ScenarioIndex == 210)
                CIM.Scenario.ScenarioIndex = 220;            
            return 0;
        }

        /// <summary>
        /// R303
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int StagePreClamp(string szCmd)
        {
            if (CIM.Scenario.ScenarioIndex == 6)
                CIM.Scenario.ScenarioIndex = 10;          
            return 0;
        }

        /// <summary>
        /// R304
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int StageLaserRepair(string szCmd)
        {
            //MessageBox.Show("Macro Home Complete Test OK Cmd = " + szCmd);
            return 0;
        }

        /// <summary>
        /// R305
        /// </summary>
        /// <param name="szCmd"></param>
        /// <returns></returns>
        public int StageLightOn(string szCmd)
        {
            //MessageBox.Show("Macro Home Complete Test OK Cmd = " + szCmd);
            return 0;
        }        
	}
	
}
