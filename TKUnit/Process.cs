using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using TK;
using ModuleInterface;
using TKUnit;
using System.Threading;
using System.Windows.Forms;

namespace TKUnit
{
    public class Process
    {
        private static Process singleton;
        //delegate int CmdFuncPointer(string szCmd);
        static Hashtable CommandProcessTable = new Hashtable();
        BaseCmd.CmdFuncPointer CmdFunc;
        object ThisLock = new object();
        static MethodInfo DealError_Method;
        static object DealError_Object;
        
        private static string szTempChar;
        private static int miLoad = 0;
        private static int miUnload = 0;

        public static int iLoad = 0, iUnload = 0;

        //以下為模組資料處理================================================================
        private void InitCommandTable()
        {
            CommandProcessTable.Add("C001", (BaseCmd.CmdFuncPointer)Custom_AreYouThere);
            CommandProcessTable.Add("C012", (BaseCmd.CmdFuncPointer)Custom_ResetErrMonitor);
            CommandProcessTable.Add("C013", (BaseCmd.CmdFuncPointer)Custom_Pause);
            CommandProcessTable.Add("C014", (BaseCmd.CmdFuncPointer)Custom_Continue);
            CommandProcessTable.Add("C015", (BaseCmd.CmdFuncPointer)Custom_Reset);

            // Stage
            CommandProcessTable.Add("C020", (BaseCmd.CmdFuncPointer)Custom_StageMotorMove);
            CommandProcessTable.Add("C021", (BaseCmd.CmdFuncPointer)Custom_QS1QG1MotorMove);
            CommandProcessTable.Add("C022", (BaseCmd.CmdFuncPointer)Custom_QS2QG2MotorMove);
            CommandProcessTable.Add("C023", (BaseCmd.CmdFuncPointer)Custom_QS3QG3MotorMove);
            CommandProcessTable.Add("C024", (BaseCmd.CmdFuncPointer)Custom_QS4QG4MotorMove);
            CommandProcessTable.Add("C025", (BaseCmd.CmdFuncPointer)Custom_QS5QG5MotorMove);
            CommandProcessTable.Add("C026", (BaseCmd.CmdFuncPointer)Custom_QS6QG6MotorMove);
            CommandProcessTable.Add("C027", (BaseCmd.CmdFuncPointer)Custom_QS7QG7MotorMove);
            CommandProcessTable.Add("C030", (BaseCmd.CmdFuncPointer)Custom_SA12MotorMove);
            CommandProcessTable.Add("C031", (BaseCmd.CmdFuncPointer)Custom_C1C2MotorMove);
            CommandProcessTable.Add("C032", (BaseCmd.CmdFuncPointer)Custom_BarMotorMove);
            CommandProcessTable.Add("C033", (BaseCmd.CmdFuncPointer)Custom_BarMotorMovePosition);
            CommandProcessTable.Add("C034", (BaseCmd.CmdFuncPointer)Custom_BarMotorMoveAll);

            // Lens
            CommandProcessTable.Add("C050", (BaseCmd.CmdFuncPointer)Custom_Lens);

            // Turn Uint
            CommandProcessTable.Add("C060", (BaseCmd.CmdFuncPointer)Custom_TurnUintTSMotorMove);
            CommandProcessTable.Add("C061", (BaseCmd.CmdFuncPointer)Custom_TurnUintTGMotorMove);
            CommandProcessTable.Add("C062", (BaseCmd.CmdFuncPointer)Custom_TurnUintTZMotorMove);

            // Cancel FSP
            CommandProcessTable.Add("C070", (BaseCmd.CmdFuncPointer)Custom_CancelStageFSP);
            CommandProcessTable.Add("C071", (BaseCmd.CmdFuncPointer)Custom_CancelTurnUnitFSP);
            CommandProcessTable.Add("C072", (BaseCmd.CmdFuncPointer)Custom_CancelQuickFSP);  
            CommandProcessTable.Add("C073", (BaseCmd.CmdFuncPointer)Custom_CancelTeachBoxFSP);

            // FSP 1
            CommandProcessTable.Add("C101", (BaseCmd.CmdFuncPointer)Custom_Initialize);

            // FSP2
            CommandProcessTable.Add("C201", (BaseCmd.CmdFuncPointer)Custom_LoadRequest);           
            CommandProcessTable.Add("C202", (BaseCmd.CmdFuncPointer)Custom_UnloadRequest);      
            CommandProcessTable.Add("C203", (BaseCmd.CmdFuncPointer)Custom_TopLoad);             
            CommandProcessTable.Add("C204", (BaseCmd.CmdFuncPointer)Custom_TopUnload);            
            CommandProcessTable.Add("C205", (BaseCmd.CmdFuncPointer)Custom_BottomLoad);        
            CommandProcessTable.Add("C206", (BaseCmd.CmdFuncPointer)Custom_BottomUnload);

            // FSP3
            CommandProcessTable.Add("C301", (BaseCmd.CmdFuncPointer)Custom_StageInitialize);
            CommandProcessTable.Add("C302", (BaseCmd.CmdFuncPointer)Custom_StageLoad);
            CommandProcessTable.Add("C303", (BaseCmd.CmdFuncPointer)Custom_StageUnload);

            // FSP4
            CommandProcessTable.Add("C401", (BaseCmd.CmdFuncPointer)Custom_QuickLingtOn);
            CommandProcessTable.Add("C402", (BaseCmd.CmdFuncPointer)Custom_QuickTeaching);

            // FSP5
            CommandProcessTable.Add("C501", (BaseCmd.CmdFuncPointer)Custom_TeachBox);
        }

        public int ProcessCommandForTKCall(string szCmd)
        {
            CCTKform.GetSingleton().CmdLog(0, szCmd);

            if (szCmd.Length <= 3 )
                return _Return_MMI_Cmd_Error_(szCmd);

            if (CommandProcessTable.Contains(szCmd.Substring(0, 4)))
            {
                CmdFunc = (BaseCmd.CmdFuncPointer)(CommandProcessTable[szCmd.Substring(0, 4)]);
                lock (ThisLock)
                {
                    CmdFunc(szCmd);
                }
            }
            else
                return _Return_MMI_Cmd_Error_(szCmd);;
            return 0;
        }

        public int ProcessCommandForMMICall(string szCmd)
        {
            CCTKform.GetSingleton().CmdLog(1, szCmd);

            if (CommandProcessTable.Contains(szCmd.Substring(0, 4)))
            {
                CmdFunc = (BaseCmd.CmdFuncPointer)(CommandProcessTable[szCmd.Substring(0, 4)]);
                lock (ThisLock)
                {
                    CmdFunc(szCmd);
                }
            }
            else
                return _Return_MMI_Cmd_Error_(szCmd);
            return 0;
        }


        //以下供外部程式呼叫使用=============================================================
        public static Process GetSingleton()
        {
            if (singleton == null)
            {
                singleton = new Process();
            }
            return singleton;
        }

        public void SendMessageToMMI(string szCmd)
        {
            object[] Command = new object[1];
            Command[0] = (object)(szCmd);
            CCTKform.GetSingleton().CmdLog(0, szCmd);
            DealError_Method.Invoke(DealError_Object, Command);
        }

        public Process()
        {

        }

        private int _Return_MMI_OK_(string szCmd)
        {
            szTempChar = "R" + szCmd.Substring(1, 3) + ",0";
            Process.GetSingleton().SendMessageToMMI(szTempChar);
            return 0;
        }

        private int _Return_MMI_Error_(string szCmd, int _ErrCode_)
        {
            szTempChar = "R" + szCmd.Substring(1, 3) + ",1," + _ErrCode_;
            Process.GetSingleton().SendMessageToMMI(szTempChar);
            return -1;
        }

        private int _Return_MMI_Params_Error_(string szCmd,int _ErrCode_)
        {
            szTempChar = "Params Error," +szCmd+","+ _ErrCode_;
            Process.GetSingleton().SendMessageToMMI(szTempChar);
            return 0;
        }

        private int _Return_MMI_Cmd_Error_(string szCmd)
        {
            szTempChar = "Cmd Error," + szCmd;
            Process.GetSingleton().SendMessageToMMI(szTempChar);
            return 0;
        }

        // =====================================================================
        //                 Controller Init Function 因應機台作修改
        // =====================================================================
        // =====================================================================
        //                 Init Function
        // =====================================================================
        public int ControllerInit()
        {
            Assembly ASB;
            Type type;

            CommandProcessTable = BaseCmd.GetSingleton().BaseCmdTable;
            InitCommandTable();

            // Load MMI DealError
            ASB = Assembly.LoadFrom(Application.StartupPath + "\\Scenario.dll");
            type = ASB.GetType("Scenario.DealError");
            DealError_Method = type.GetMethod("DealErrorCommandForTKCall");
            DealError_Object = Activator.CreateInstance(type);

            // TK Process 初始化動作(例如:IO Trigger, Extend Function)
            int l_iErrCode = 0;
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_AF_AUTOFOCUS_, 0, 1, IOTable.VIO._VIO_TRIG_AF_AUTOFOCUS_, true, 150, IOTable.VIO._VIO_TRIG_AF_AUTOFOCUS_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_AF_UPWARD_, 0, 1, IOTable.VIO._VIO_TRIG_AF_UPWARD_, true, 150, IOTable.VIO._VIO_TRIG_AF_UPWARD_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_AF_DOWNWARD_, 0, 1, IOTable.VIO._VIO_TRIG_TEACHBOX_AF_DOWNWARD_, true, 150, IOTable.VIO._VIO_TRIG_TEACHBOX_AF_DOWNWARD_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_SLOW_BTN_, 0, 1, IOTable.VIO._VIO_TRIG_TEACHBOX_SLOW_BTN_, true, 150, IOTable.VIO._VIO_TRIG_TEACHBOX_SLOW_BTN_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_MIDDLE_BTN_, 0, 1, IOTable.VIO._VIO_TRIG_TEACHBOX_MIDDLE_BTN_, true, 150, IOTable.VIO._VIO_TRIG_TEACHBOX_MIDDLE_BTN_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_FAST_BTN_, 0, 1, IOTable.VIO._VIO_TRIG_TEACHBOX_FAST_BTN_, true, 150, IOTable.VIO._VIO_TRIG_TEACHBOX_FAST_BTN_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_STICK_UP_, 0, 1, IOTable.VIO._VIO_TRIG_STICK_UP_, true, 150, IOTable.VIO._VIO_TRIG_STICK_UP_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_STICK_DOWN_, 0, 1, IOTable.VIO._VIO_TRIG_STICK_DOWN_, true, 150, IOTable.VIO._VIO_TRIG_STICK_DOWN_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_STICK_LEFT_, 0, 1, IOTable.VIO._VIO_TRIG_STICK_LEFT_, true, 150, IOTable.VIO._VIO_TRIG_STICK_LEFT_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_STICK_RIGHT_, 0, 1, IOTable.VIO._VIO_TRIG_STICK_RIGHT_, true, 150, IOTable.VIO._VIO_TRIG_STICK_RIGHT_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_FROMLIGHT_LIGHTER_, 0, 1, IOTable.VIO._VIO_TRIG_FROMLIGHT_LIGHTER_, true, 150, IOTable.VIO._VIO_TRIG_FROMLIGHT_LIGHTER_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_FROMLIGHT_DARKER, 0, 1, IOTable.VIO._VIO_TRIG_FROMLIGHT_DARKER_, true, 150, IOTable.VIO._VIO_TRIG_FROMLIGHT_DARKER_ENABLE, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_BACKLIGHT_LIGHTER_, 0, 1, IOTable.VIO._VIO_TRIG_BACKLIGHT_LIGHTER_, true, 150, IOTable.VIO._VIO_TRIG_BACKLIGHT_LIGHTER_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_BACKLIGHT_DARKER, 0, 1, IOTable.VIO._VIO_TRIG_BACKLIGHT_DARKER_, true, 150, IOTable.VIO._VIO_TRIG_BACKLIGHT_DARKER_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_LASE_RFIRE_BTN_, 0, 1, IOTable.VIO._VIO_TRIG_LASE_RFIRE_BTN_, true, 150, IOTable.VIO._VIO_TRIG_LASE_RFIRE_BTN_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_LASER_STOP_BTN_, 0, 1, IOTable.VIO._VIO_TRIG_LASER_STOP_BTN_, true, 150, IOTable.VIO._VIO_TRIG_LASER_STOP_BTN_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_LENS_X2_, 0, 1, IOTable.VIO._VIO_TRIG_LENS_X2_, true, 150, IOTable.VIO._VIO_TRIG_LENS_X2_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_LENS_X5_, 0, 1, IOTable.VIO._VIO_TRIG_LENS_X5_, true, 150, IOTable.VIO._VIO_TRIG_LENS_X5_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_LENS_X20_, 0, 1, IOTable.VIO._VIO_TRIG_LENS_X20_, true, 150, IOTable.VIO._VIO_TRIG_LENS_X20_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_LENS_X50_, 0, 1, IOTable.VIO._VIO_TRIG_LENS_X50_, true, 150, IOTable.VIO._VIO_TRIG_LENS_X50_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_QUCIK_, 0, 1, IOTable.VIO._VIO_TRIG_QUCIK_, true, 150, IOTable.VIO._VIO_TRIG_QUCIK_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_BUZZER_, 0, 1, IOTable.VIO._VIO_TRIG_BUZZER_, true, 150, IOTable.VIO._VIO_TRIG_BUZZER_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_TEACH_XY_, 0, 1, IOTable.VIO._VIO_TRIG_TEACH_XY_, true, 150, IOTable.VIO._VIO_TRIG_TEACH_XY_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_TEACH_ALIGNMENT_, 0, 1, IOTable.VIO._VIO_TRIG_TEACH_ALIGNMENT_, true, 150, IOTable.VIO._VIO_TRIG_TEACH_ALIGNMENT_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_QUICK_CCD_, 0, 1, IOTable.VIO._VIO_TRIG_QUICK_CCD_, true, 150, IOTable.VIO._VIO_TRIG_QUICK_CCD_ENABLE_, true);
            if (l_iErrCode >= 0)
                l_iErrCode = TK.CCTKform.TK_DIO_SF.CCDioSFModule_SetTriggerSF(IOTable.DI._DI_TEACHBOX_SAFETYDOOR_BYPASS_, 0, 1, IOTable.VIO._VIO_TRIG_SAFETYDOOR_BYPASS_, true, 150, IOTable.VIO._VIO_TRIG_SAFETYDOOR_BYPASS_ENABLE_, true);

            return 0;
        }

        #region C Code
        /// <summary>
        /// C001: 測試連線
        /// </summary>
        /// <param name="p_strCmd"></param>
        /// <returns>R001,0,0</returns>
        private int Custom_AreYouThere(string p_strCmd)
        {
            _Return_MMI_OK_(p_strCmd);
            return 0;
        }

        /// <summary>
        /// C012: Reset Alarm Event
        /// </summary>
        /// <param name="p_strCmd"></param>
        /// <returns>R012,1/0,Error Code</returns>
        private int Custom_ResetErrMonitor(string p_strCmd)
        {                        
            bool bOn = true;
            for (int iIdx = IOTable.DI._DI_MOTOR_S_ALARM_; iIdx <= IOTable.DI._DI_MOTOR_RZ_ALARM_; ++iIdx)
            {
                CCTKform.TK_DIO.CCDioModule_GetDI(iIdx, ref bOn);
                if (!bOn)
                {
                    // Report Alarm to MMI
                    //SendMessageToMMI
                    return -1;                        
                }
            }

            TK.ErrorMonitor.ErrorMonitor.GetSingleton().Reset();
            _Return_MMI_OK_(p_strCmd);
            return 0;
        }

        /// <summary>
        /// C013: Pause
        /// </summary>
        /// <param name="p_strCmd"></param>
        /// <returns>R013,1/0,Error Code</returns>
        private int Custom_Pause(string p_strCmd)
        {                       
            _Return_MMI_OK_(p_strCmd);
            return 0;
        }

        /// <summary>
        /// C014: Continue
        /// </summary>
        /// <param name="p_strCmd"></param>
        /// <returns>R014,1/0,Error Code</returns>
        private int Custom_Continue(string p_strCmd)
        {
            _Return_MMI_OK_(p_strCmd);            
            return 0;
        }
        
        /// <summary>
        /// C015: Reset
        /// </summary>
        /// <param name="p_strCmd"></param>
        /// <returns>R015,1/0,Error Code</returns>
        private int Custom_Reset(string p_strCmd)
        {
            _Return_MMI_OK_(p_strCmd);            
            return 0;
        }
       
        /// <summary>
        /// C020,G,S,Y,Speed,ACC,DEC,1/0: 移動Stage的馬達位置 
        /// </summary>
        /// <param name="G">G位置(單位:0.1um)</param>
        /// <param name="S">S位置(單位:0.1um)</param>
        /// <param name="Y">Y位置(單位:0.1um)</param>
        /// <param name="Speed">速度(um)</param>
        /// <param name="ACC">加速度(ms) (0~3000)</param>
        /// <param name="DEC">減速度(ms)(0~3000)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R020,0/1,0/Error code</returns>
        private int Custom_StageMotorMove(string p_strCmd)
        {
            object iS_Pos = new int(), iG_Pos = new int(), iL_Pos = new int(), iSpeed = new int(), iAcc = new int(), iDec = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iG_Pos, ref iS_Pos, ref iL_Pos, ref iSpeed, ref iAcc, ref iDec, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查是否initialize
            bool bOn = false;
            int iStatus = TK.CCTKform.TK_VIO.CCVioModule_GetVIO(IOTable.VIO._VIO_INITIALIAL_FINISH_, ref bOn);
            if (iStatus != 0 || bOn == false)
                _Return_MMI_Error_(p_strCmd,1501);

            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 檢查參數是否正確
            if ((int)iSpeed < 1 || (int)iSpeed > 600000 || (int)iAcc < (int)iSpeed / 2000 || (int)iAcc > 3000 || (int)iDec < (int)iSpeed / 2000 || (int)iDec > 3000)
                _Return_MMI_Error_(p_strCmd, 1501);


            // 計算馬達位置            
            int iSPitch = 0, iGPitch = 0,iLPitch = 0, iTemp = 0;
            int iSPulse = 0, iGPulse = 0,iLPulse = 0;

            iStatus = TK.CCTKform.TK_Motion.CCMotionModule_GetPitch(0,ref iSPitch, ref iGPitch, ref iLPitch, ref iTemp);
            if( iStatus < 0 )
                _Return_MMI_Error_(p_strCmd, 1501);

            iStatus = TK.CCTKform.TK_Motion.CCMotionModule_GetMotorPulse(0,ref iSPulse, ref iGPulse, ref iLPulse, ref iTemp);
            if( iStatus < 0 )
                _Return_MMI_Error_(p_strCmd, 1501);

            if ((int)iType == 1) // 絕對移動
            {
                int iPulse = (int)(((double)iSPulse * (int)iS_Pos) / (iSPitch * 10));
                TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_Target_S_, iPulse);

                iPulse = (int)(((double)iGPulse * (int)iG_Pos) / (iGPitch * 10));
                TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_Target_G_, iPulse);

                iPulse = (int)(((double)iLPulse * (int)iL_Pos) / (iLPitch * 10));
                TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_Target_L_, iPulse);
            }
            else // 相對移動
            {
                int iS_Counter = 0, iG_Counter = 0, iL_Counter = 0;
                iStatus = TK.CCTKform.TK_Motion.CCMotionModule_GetCounter(0, ref iS_Counter, ref iG_Counter, ref iL_Counter, ref iTemp); // 取得馬達目前位置

                int iPulse = (int)(((double)iSPulse * (int)iS_Pos) / (iSPitch * 10));
                TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_Target_S_, iPulse + iS_Counter);

                iPulse = (int)(((double)iGPulse * (int)iG_Pos) / (iGPitch * 10));
                TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_Target_G_, iPulse + iG_Counter);

                iPulse = (int)(((double)iLPulse * (int)iL_Pos) / (iLPitch * 10));
                TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_Target_L_, iPulse + iL_Counter);
            }

            // 設定速度，加速以及減速
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_MoveSpeed_, (int)iSpeed);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_MoveACC_, (int)iAcc);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_MoveDEC_, (int)iDec);

            // Run FSP
            /*CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_ALLHOME_,
                                                                                       IOTable._FSP_HOME_,
                                                                                       (int)iNum);*/

            return 0;
        }

        private bool CheckStageFSPStatus()
        {
            // 檢查是否initialize
            bool bOn = false;
            int iStatus = TK.CCTKform.TK_VIO.CCVioModule_GetVIO(IOTable.VIO._VIO_INITIALIAL_FINISH_, ref bOn);
            if (iStatus != 0 || bOn == false)
                return false;

            // 檢查 FSP 是否 IDLE
            int iErrCode = TK.CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_STAGE_);
            if (iErrCode != 1)
                return false;

            return true;
        }

        private int GetAxisPosition(int p_iAxis, int p_iPos, int p_iType)
        {
            // 計算馬達位置           
            int iPitch = 0, iTemp = 0, iPulse = 0;

            int iStatus = TK.CCTKform.TK_Motion.CCMotionModule_GetPitch(p_iAxis, ref iPitch, ref iTemp, ref iTemp, ref iTemp);
            if (iStatus < 0 || iPitch == 0) // prevent from divide by zero
                return -1;

            iStatus = TK.CCTKform.TK_Motion.CCMotionModule_GetMotorPulse(p_iAxis, ref iPulse, ref iTemp, ref iTemp, ref iTemp);
            if (iStatus < 0)
                return -1;

            if (p_iType == 1) //絕對移動
            {
                return (int)(((double)iPulse * (int)p_iPos) / (iPitch * 10));
            }
            else // 相對移動
            {
                int iCounter = 0;
                iStatus = TK.CCTKform.TK_Motion.CCMotionModule_GetCounter(0, ref iCounter, ref iTemp, ref iTemp, ref iTemp); // 取得馬達目前位置
                if (iStatus < 0)
                    return -1;

                return ((int)(((double)iPulse * (int)p_iPos) / (iPitch * 10)) + iCounter);
            }
        }
        
        /// <summary>
        /// C021,QG1 position,QS1 position,1/0: QG1,QS1馬達移動
        /// </summary>
        /// <param name="QS1 position">QS1位置(單位:0.1um)</param>
        /// <param name="QG1 position">QG1位置(單位:0.1um)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R021,1/0,Error Code</returns>
        private int Custom_QS1QG1MotorMove(string p_strCmd)
        {
            object  iQS1_Pos = new int(), iQG1_Pos = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iQS1_Pos, ref iQG1_Pos, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查機台是否初始化 && FSP是否IDLE
            if( !CheckStageFSPStatus() )
               return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算QS1位置
           int iResultPosition = GetAxisPosition(7, (int)iQS1_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQS1_, iResultPosition);

            // 根據移動模式計算QG1位置
            iResultPosition = GetAxisPosition(8, (int)iQG1_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQG1_, iResultPosition);

            // Call FSP

            return 0;
        }

        /// <summary>
        /// C022,QG2 position,QS2 position,1/0: QG2,QS2馬達移動
        /// </summary>
        /// <param name="QS2 position">QS2位置(單位:0.1um)</param>
        /// <param name="QG2 position">QG2位置(單位:0.1um)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R022,1/0,Error Code</returns>
        private int Custom_QS2QG2MotorMove(string p_strCmd)
        {
            object iQS2_Pos = new int(), iQG2_Pos = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iQS2_Pos, ref iQG2_Pos, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算QS2位置
            int iResultPosition = GetAxisPosition(9, (int)iQS2_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQS2_, iResultPosition);

            // 根據移動模式計算QG2位置
            iResultPosition = GetAxisPosition(10, (int)iQG2_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQG2_, iResultPosition);

            // Call FSP

            return 0;
        }

        /// <summary>
        /// C023,QG3 position,QS3 position,1/0: QG3,QS3馬達移動
        /// </summary>
        /// <param name="QS3 position">QS3位置(單位:0.1um)</param>
        /// <param name="QG3 position">QG3位置(單位:0.1um)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R023,1/0,Error Code</returns>
        private int Custom_QS3QG3MotorMove(string p_strCmd)
        {
            object iQS3_Pos = new int(), iQG3_Pos = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iQS3_Pos, ref iQG3_Pos, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算QS3位置
            int iResultPosition = GetAxisPosition(11, (int)iQS3_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQS3_, iResultPosition);

            // 根據移動模式計算QG3位置
            iResultPosition = GetAxisPosition(12, (int)iQG3_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQG3_, iResultPosition);

            // Call FSP

            return 0;
        }

        /// <summary>
        /// C024,QG4 position,QS4 position,1/0: QG4,QS4馬達移動
        /// </summary>
        /// <param name="QS4 position">QS4位置(單位:0.1um)</param>
        /// <param name="QG4 position">QG4位置(單位:0.1um)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R024,1/0,Error Code</returns>
        private int Custom_QS4QG4MotorMove(string p_strCmd)
        {
            object iQS4_Pos = new int(), iQG4_Pos = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iQS4_Pos, ref iQG4_Pos, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算QS3位置
            int iResultPosition = GetAxisPosition(13, (int)iQS4_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQS4_, iResultPosition);

            // 根據移動模式計算QG3位置
            iResultPosition = GetAxisPosition(14, (int)iQG4_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQG4_, iResultPosition);

            // Call FSP

            return 0;
        }

        /// <summary>
        /// C025,QG4 position,QS5 position,1/0: QG5,QS5馬達移動
        /// </summary>
        /// <param name="QS4 position">QS5位置(單位:0.1um)</param>
        /// <param name="QG4 position">QG5位置(單位:0.1um)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R024,1/0,Error Code</returns>
        private int Custom_QS5QG5MotorMove(string p_strCmd)
        {
            object iQS5_Pos = new int(), iQG5_Pos = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iQS5_Pos, ref iQG5_Pos, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算QS5位置
            int iResultPosition = GetAxisPosition(13, (int)iQS5_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQS5_, iResultPosition);

            // 根據移動模式計算QG5位置
            iResultPosition = GetAxisPosition(14, (int)iQG5_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQG5_, iResultPosition);

            // Call FSP

            return 0;
        }

        /// <summary>
        /// C026,QG6 position,QS6 position,1/0: QG6,QS6馬達移動
        /// </summary>
        /// <param name="QS6 position">QS6位置(單位:0.1um)</param>
        /// <param name="QG6 position">QG6位置(單位:0.1um)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R026,1/0,Error Code</returns>
        private int Custom_QS6QG6MotorMove(string p_strCmd)
        {
            object iQS6_Pos = new int(), iQG6_Pos = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iQS6_Pos, ref iQG6_Pos, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算QS6位置
            int iResultPosition = GetAxisPosition(13, (int)iQS6_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQS6_, iResultPosition);

            // 根據移動模式計算QG6位置
            iResultPosition = GetAxisPosition(14, (int)iQG6_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQG6_, iResultPosition);

            // Call FSP

            return 0;
        }

        /// <summary>
        /// C027,QG7 position,QS7 position,1/0: QG7,QS7馬達移動
        /// </summary>
        /// <param name="QS7 position">QS7位置(單位:0.1um)</param>
        /// <param name="QG7 position">QG7位置(單位:0.1um)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R027,1/0,Error Code</returns>
        private int Custom_QS7QG7MotorMove(string p_strCmd)
        {
            object iQS7_Pos = new int(), iQG7_Pos = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iQS7_Pos, ref iQG7_Pos, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算QS7位置
            int iResultPosition = GetAxisPosition(13, (int)iQS7_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQS7_, iResultPosition);

            // 根據移動模式計算QG7位置
            iResultPosition = GetAxisPosition(14, (int)iQG7_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetQG7_, iResultPosition);

            // Call FSP

            return 0;
        }

        /// <summary>
        /// C030,SA1& SA2 position ,Speed,Acc,Dec,1/0: SA1,SA2 馬達移動(推片)
        /// </summary>
        /// <param name="SA1 & sa2 position">SA1 & SA2位置(單位:0.1um)</param>
        /// <param name="Speed">速度 (um)</param>
        /// <param name="Acc">加速度(ms)</param>
        /// <param name="Dec">減速度(ms)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R030,1/0,Error Code</returns>
        private int Custom_SA12MotorMove(string p_strCmd)
        {
            object iSA12_Pos = new int(), iSpeed = new int(), iAcc = new int(), iDec = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iSA12_Pos, ref iSpeed, ref iAcc, ref iDec, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查參數
            if ((int)iSpeed < 1 || (int)iSpeed > 400000 || (int)iAcc < 0 || (int)iAcc > 3000 || (int)iDec < 0 || (int)iDec > 3000)
                return _Return_MMI_Error_(p_strCmd,1503);

            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算SA1SA2位置
            int iResultPosition = GetAxisPosition(22, (int)iSA12_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetSA1SA2_, iResultPosition);

            // 設定速度，加速以及減速
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_SA1MoveSpeed_, (int)iSpeed);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_SA1MoveACC_, (int)iAcc);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_SA1MoveDEC_, (int)iDec);

            // Call FSP

            return 0;
        }

        /// <summary>
        /// C031,C1C2 position,Speed,Acc,Dec,1/0: C1C2 馬達移動(夾片)
        /// </summary>
        /// <param name="C1C2 position">C1C2位置(單位:0.1um)</param>
        /// <param name="Speed">速度 (um)</param>
        /// <param name="Acc">加速度(ms)</param>
        /// <param name="Dec">減速度(ms)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R031,1/0,Error Code</returns>
        private int Custom_C1C2MotorMove(string p_strCmd)
        {
            object iC1C2_Pos = new int(), iSpeed = new int(), iAcc = new int(), iDec = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iC1C2_Pos, ref iSpeed, ref iAcc, ref iDec, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            // 檢查參數
            if ((int)iSpeed < 1 || (int)iSpeed > 400000 || (int)iAcc < 0 || (int)iAcc > 3000 || (int)iDec < 0 || (int)iDec > 3000)
                return _Return_MMI_Error_(p_strCmd, 1503);

            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算SA1SA2位置
            int iResultPosition = GetAxisPosition(21, (int)iC1C2_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetC1C2_, iResultPosition);

            // 設定速度，加速以及減速
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_C1C2MoveSpeed_, (int)iSpeed);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_C1C2MoveACC_, (int)iAcc);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_C1C2MoveDEC_, (int)iDec);

            // Call FSP

            return 0;
        }

        /// <summary>
        /// C032,B1-B2,1/0： 移動Bar位置
        /// </summary>
        /// <param name="B1-B3">指定Bar的編號</param>
        /// <param name="1/0">往左或往右移</param>
        /// <returns></returns>
        private int Custom_BarMotorMove(string p_strCmd)
        {
            /*object iNum = new int(), iBarNum = new int(), iLeft = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iNum, ref iBarNum, ref iLeft);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);

            if ((int)iBarNum <= 0 || (int)iBarNum > 3 || (int)iBarNum == 2) // Bar 2 無法移動
                _Return_MMI_Cmd_Error_(p_strCmd);

            int iStatus = 0, iOp1 = 0, iOp2 = 0, iOp3 = 0, iIndex = 0, iDebugStatus = 0, iJobID = 0;
            long iRunningTime = 0;
            iErrCode = CCTKform.TK_Func1.CCFunc1Module_ReadStatus(IOTable._FSP_QUICK_,
                                                                                                                              ref iStatus,
                                                                                                                              ref iOp1,
                                                                                                                              ref iOp2,
                                                                                                                              ref iOp3,
                                                                                                                              ref iIndex,
                                                                                                                              ref iDebugStatus,
                                                                                                                              ref iJobID,
                                                                                                                              ref iRunningTime);
            if (iErrCode != 0)
                return _Return_MMI_Error_(p_strCmd, iErrCode);

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_QUICK_TEACHING_,
                                                                                       IOTable._FSP_QUICK_,
                                                                                       (int)iNum);

            _Return_MMI_OK_(p_strCmd);*/

            return 0;
        } // TODO

        /// <summary>
        /// C033,B1-B2,Position,1/0： 移動Bar位置
        /// </summary>
        /// <param name="B1-B2">指定Bar的編號</param>
        /// <param name="Position">指定移動位置</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns></returns>
        private int Custom_BarMotorMovePosition(string p_strCmd)
        {
            object iBarNum = 0,iBar_Pos = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iBarNum, ref iBar_Pos, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);
          
            // 檢查機台是否初始化 && FSP是否IDLE
            if (!CheckStageFSPStatus())
                return _Return_MMI_Error_(p_strCmd, 1501);

            // 根據移動模式計算Bar位置
            int iBarAxis = 0;
            if ( (int)iBarNum == 1)
                iBarAxis = 24;
            else if ((int)iBarNum == 2)
                iBarAxis = 25;
            else
                iBarAxis = 26;                            

            int iResultPosition = GetAxisPosition(iBarAxis, (int)iBar_Pos, (int)iType);
            if (iResultPosition < 0)
                return _Return_MMI_Error_(p_strCmd, 1501);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TargetBAR_, iResultPosition);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_BarNumber_, (int)iBarNum);
                        
            // Call FSP

            return 0;
        }

        /// <summary>
        /// C034,B1-B2,Position,1/0： 移動所有Bar位置 : 應該用不到
        /// </summary>        
        /// <param name="Position">指定移動位置</param>
        /// <param name="1/0">往左或往右移</param>
        /// <returns></returns>
        private int Custom_BarMotorMoveAll(string p_strCmd)
        {
            /*object iNum = new int(), iBarNum = new int(), iPos = new int(), iLeft = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iNum);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);            

            int iStatus = 0, iOp1 = 0, iOp2 = 0, iOp3 = 0, iIndex = 0, iDebugStatus = 0, iJobID = 0;
            long iRunningTime = 0;
            iErrCode = CCTKform.TK_Func1.CCFunc1Module_ReadStatus(IOTable._FSP_QUICK_,
                                                                                                                              ref iStatus,
                                                                                                                              ref iOp1,
                                                                                                                              ref iOp2,
                                                                                                                              ref iOp3,
                                                                                                                              ref iIndex,
                                                                                                                              ref iDebugStatus,
                                                                                                                              ref iJobID,
                                                                                                                              ref iRunningTime);
            if (iErrCode != 0)
                return _Return_MMI_Error_(p_strCmd, iErrCode);

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_QUICK_TEACHING_,
                                                                                       IOTable._FSP_QUICK_,
                                                                                       (int)iNum);

            _Return_MMI_OK_(p_strCmd);*/

            return 0;
        }
             

        /// <summary>
        /// C050,Len Type,High Speed,High Acc,High Dec, Middle Speed,Middle Acc,Middle Dec,Low Speed,Low Acc,Low Dec: 通知操作盒目前所選鏡頭並設定其速度及加,減速度
        /// </summary>
        /// <param name="Len Type">1代表2X, 2代表5X, 3代表20X,4代表50X</param>
        /// <param name="High Speed">高速的速度值</param>
        /// <param name="High Acc">高速的加速度值</param>
        /// <param name="High Dec">高速的減速度值</param>
        /// <param name="Middle Speed">中速的速度值</param>
        /// <param name="Middle Acc">中速的加速度值</param>
        /// <param name="Middle Dec">中速的減速度值</param>
        /// <param name="Low Speed">低速的速度值</param>
        /// <param name="Low Acc">低速的加速度值</param>
        /// <param name="Low Dec">低速的減速度值</param>
        /// <returns>R050,1/0,Error Code</returns>
        private int Custom_Lens(string p_strCmd)
        {
            object iNum = new int();
            object iLenTye = new int(), iHighSpeed = new int(), iHighAcc = new int(), iHighDec = new int();
            object iMiddleSpeed = new int(), iMiddleAcc = new int(), iMiddleDec = new int();
            object iLowSpeed = new int(), iLowAcc = new int(), iLowDec = new int();

            int iIdx = 1;
            string[] tmp= p_strCmd.Split(',');
            iNum = int.Parse( tmp[iIdx++]);
            iLenTye = int.Parse(tmp[iIdx++]);
            iHighSpeed = int.Parse(tmp[iIdx++]);
            iHighAcc = int.Parse(tmp[iIdx++]);
            iHighDec = int.Parse(tmp[iIdx++]);
            iMiddleSpeed = int.Parse(tmp[iIdx++]);
            iMiddleAcc = int.Parse(tmp[iIdx++]);
            iMiddleDec = int.Parse(tmp[iIdx++]);
            iLowSpeed = int.Parse(tmp[iIdx++]);
            iLowAcc = int.Parse(tmp[iIdx++]);
            iLowDec = int.Parse(tmp[iIdx++]);
            
            // Check Parameter
            if (((int)iHighSpeed <= 0 || (int)iHighSpeed > 400000 || (int)iHighAcc < 0 || (int)iHighDec < 0) ||
                ((int)iMiddleSpeed <= 0 || (int)iMiddleSpeed > 400000 || (int)iMiddleAcc < 0 || (int)iMiddleDec < 0) ||
                ((int)iLowSpeed <= 0 || (int)iLowSpeed > 400000 || (int)iLowAcc < 0 || (int)iLowDec < 0))
            {
                _Return_MMI_Error_(p_strCmd, 1513);
            }

            //Reset TeachBox
            TK.CCTKform.TK_DIO.CCDioModule_SetDO(IOTable.DO._DO_TEACHBOX_LENS_X2_, false);
            TK.CCTKform.TK_DIO.CCDioModule_SetDO(IOTable.DO._DO_TEACHBOX_LENS_X5_, false);
            TK.CCTKform.TK_DIO.CCDioModule_SetDO(IOTable.DO._DO_TEACHBOX_LENS_X20_, false);
            TK.CCTKform.TK_DIO.CCDioModule_SetDO(IOTable.DO._DO_TEACHBOX_LENS_X50_, false);

            switch ((int)iLenTye)
            {
                case 1:
                    TK.CCTKform.TK_DIO.CCDioModule_SetDO(IOTable.DO._DO_TEACHBOX_LENS_X2_, true);
                    TK.CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_2XLenUseFlag_, true);
                    break;

                case 2:
                    TK.CCTKform.TK_DIO.CCDioModule_SetDO(IOTable.DO._DO_TEACHBOX_LENS_X5_, true);
                    TK.CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_5XLenUseFlag_, true);
                    break;

                case 3:
                    TK.CCTKform.TK_DIO.CCDioModule_SetDO(IOTable.DO._DO_TEACHBOX_LENS_X20_, true);
                    TK.CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_20XLenUseFlag_, true);
                    break;

                case 4: TK.CCTKform.TK_DIO.CCDioModule_SetDO(IOTable.DO._DO_TEACHBOX_LENS_X50_, true);
                    TK.CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_50XLenUseFlag_, true);
                    break;

                default:
                    return _Return_MMI_Error_(p_strCmd, 1513);
            }

            // 操作盒速度設定
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TeachBoxHighSpeed_, (int)iHighSpeed);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TeachBoxHighAcc_, (int)iHighAcc);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TeachBoxHighDec_, (int)iHighDec);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TeachBoxMiddleSpeed_, (int)iMiddleSpeed);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TeachBoxMiddleAcc_, (int)iMiddleAcc);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TeachBoxMiddleDec_, (int)iMiddleDec);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TeachBoxSlowSpeed_, (int)iLowSpeed);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TeachBoxSlowAcc_, (int)iLowAcc);
            TK.CCTKform.TK_VIO.CCVioModule_SetGlobal(IOTable.Global._G_TeachBoxSlowDec_, (int)iLowDec);

            _Return_MMI_OK_(p_strCmd);
            return 0;
        }
        
        /// <summary>
        /// C060,TS,Speed,ACC,DEC,1/0: 移動 Turn Uint 的馬達位置 : 應該用不到
        /// </summary>
        /// <param name="TS">TS位置(單位:0.1um)</param>        
        /// <param name="Speed">速度(um)</param>
        /// <param name="ACC">加速度(ms) (0~3000)</param>
        /// <param name="DEC">減速度(ms)(0~3000)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R060,0/1,0/Error code</returns>
        private int Custom_TurnUintTSMotorMove(string p_strCmd)
        {
           /*object iTS_Pos = new int(), iSpeed = new int(), iAcc = new int(), iDec = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iTS_Pos, ref iSpeed, ref iAcc, ref iDec, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);*/



            return 0;
        }

        /// <summary>
        /// C061,TG,Speed,ACC,DEC,1/0: 移動 Turn Uint 的馬達位置 : 應該用不到
        /// </summary>
        /// <param name="TS">TG位置(單位:0.1um)</param>        
        /// <param name="Speed">速度(um)</param>
        /// <param name="ACC">加速度(ms) (0~3000)</param>
        /// <param name="DEC">減速度(ms)(0~3000)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R061,0/1,0/Error code</returns>
        private int Custom_TurnUintTGMotorMove(string p_strCmd)
        {
            /*object iTG_Pos = new int(), iSpeed = new int(), iAcc = new int(), iDec = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iTG_Pos, ref iSpeed, ref iAcc, ref iDec, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);*/



            return 0;
        }

        /// <summary>
        /// C062,TZ,Speed,ACC,DEC,1/0: 移動 Turn Uint 的馬達位置 : 應該用不到
        /// </summary>
        /// <param name="TZ">TZ位置(單位:0.1um)</param>        
        /// <param name="Speed">速度(um)</param>
        /// <param name="ACC">加速度(ms) (0~3000)</param>
        /// <param name="DEC">減速度(ms)(0~3000)</param>
        /// <param name="1/0">移動模式(1->絕對移動,0->相對移動)</param>
        /// <returns>R062,0/1,0/Error code</returns>
        private int Custom_TurnUintTZMotorMove(string p_strCmd)
        {
            /*object iTZ_Pos = new int(), iSpeed = new int(), iAcc = new int(), iDec = new int(), iType = new int();

            int iErrCode = TK.BaseCmd.BaseCmd_StringSpilt(p_strCmd, ref iTZ_Pos, ref iSpeed, ref iAcc, ref iDec, ref iType);
            if (iErrCode != 0)
                return _Return_MMI_Params_Error_(p_strCmd, iErrCode);*/



            return 0;
        }

        /// <summary>
        /// C070： 取消 Stage FSP
        /// </summary>
        /// <param name="p_strCmd"></param>
        /// <returns>R070,0/1,0/Error code</returns>
        private int Custom_CancelStageFSP(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_STAGE_) == 1)
            {
                _Return_MMI_OK_(p_strCmd);
                return 0;
            }
            else
            {
                TK.CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_CANCEL_FSP_STAGE_, true);
                _Return_MMI_OK_(p_strCmd);
                return 1;
            }
        }

        /// <summary>
        /// C071: 取消 Turn Uint FSP
        /// </summary>        
        /// <returns>R071,0/1,0/Error code</returns>
        private int Custom_CancelTurnUnitFSP(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_TurnUint_) == 1)
            {
                _Return_MMI_OK_(p_strCmd);
                return 0;
            }
            else
            {
                TK.CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_CANCEL_FSP_TURNUNIT_, true);
                _Return_MMI_OK_(p_strCmd);
                return 1;
            }
        }

        /// <summary>
        /// C072: 取消 Quick FSP
        /// </summary>        
        /// <returns>R071,0/1,0/Error code</returns>
        private int Custom_CancelQuickFSP(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_QUICK_) == 1)
            {
                _Return_MMI_OK_(p_strCmd);
                return 0;
            }
            else
            {
                TK.CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_CANCEL_FSP_QUICK_, true);
                _Return_MMI_OK_(p_strCmd);
                return 1;
            }
        }

        /// <summary>
        /// C073: 取消 TeachBox FSP
        /// </summary>        
        /// <returns>R073,0/1,0/Error code</returns>
        private int Custom_CancelTeachBoxFSP(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_TEACHBOX_) == 1)
            {
                _Return_MMI_OK_(p_strCmd);
                return 0;
            }
            else
            {
                TK.CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_CANCEL_FSP_TEACHBOX_, true);
                _Return_MMI_OK_(p_strCmd);
                return 1;
            }
        }
        


        #endregion

        #region FSP1
        // C101
        private int Custom_Initialize(string p_strCmd)
        {                       
            /*if (Custom_ResetErrMonitor("C012") != 0)
                _Return_MMI_Error_(p_strCmd,8720);*/
         
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_HOME_) != 1)
                return _Return_MMI_Error_(p_strCmd,8721);
            /*
            // 檢查是否有ROBOT在EQ
            bool bON = false;
            CCTKform.TK_DIO.CCDioModule_GetDI(IOTable.DI._DI_ROBOT_INTERLOCK_SENSOR_,ref bON);
            if (bON)
            {
                // TODO: Send Error Message
                //sprintf(szTempChar,"A022,18");
                //SendMessageToMMI(szTempChar);
                _Return_MMI_Error_(p_strCmd,8722);
            }

            // 取消每一個FSP
            CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_CANCEL_FSP_QUICK_, true);
            CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_CANCEL_FSP_STAGE_, true);
            CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_CANCEL_FSP_TEACHBOX_, true);
            CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_CANCEL_FSP_TURNUNIT_, true);*/
            
            // 開始RUN FSP
            CCTKform.TK_VIO.CCVioModule_SetVIO(IOTable.VIO._VIO_CANCEL_FSP_HOME_, false);            
            CCTKform.TK_Func1.CCFunc1Module_Run(  IOTable._JOB_ALLHOME_,
                                                                                       IOTable._FSP_HOME_, 
                                                                                       101);


            return 0;
        }
        #endregion

        #region FSP2

        // C201
        private int Custom_LoadRequest(string p_strCmd)
        {                                    
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_TurnUint_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721);            

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_TU_LDRQ_,
                                                                                       IOTable._FSP_TurnUint_,
                                                                                       201);

            _Return_MMI_OK_(p_strCmd);

            return 0;
        }

        // C202
        private int Custom_UnloadRequest(string p_strCmd)
        {                       
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_TurnUint_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_TU_UDRQ_,
                                                                                       IOTable._FSP_TurnUint_,
                                                                                       202);

            _Return_MMI_OK_(p_strCmd);

            return 0;
        }

        // C203
        private int Custom_TopLoad(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_TurnUint_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_TU_TOP_LOAD_,
                                                                                       IOTable._FSP_TurnUint_,
                                                                                       203);

            _Return_MMI_OK_(p_strCmd);

            return 0;
        }

        // C204
        private int Custom_TopUnload(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_TurnUint_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_TU_TOP_UNLOAD_,
                                                                                       IOTable._FSP_TurnUint_,
                                                                                       204);

            _Return_MMI_OK_(p_strCmd);

            return 0;
        }

        // C205
        private int Custom_BottomLoad(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_TurnUint_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_TU_BOTTOM_LOAD_,
                                                                                       IOTable._FSP_TurnUint_,
                                                                                       205);

            _Return_MMI_OK_(p_strCmd);

            return 0;
        }

        // C206
        private int Custom_BottomUnload(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_TurnUint_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 
            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_TU_BOTTOM_UNLOAD_,
                                                                                       IOTable._FSP_TurnUint_,
                                                                                       206);

            _Return_MMI_OK_(p_strCmd);

            return 0;
        }
        #endregion

        #region FSP3

        // C301: Stage 初始化，包含C1C2、SA1,SA2、S、G、Quick、B1B2歸零
        private int Custom_StageInitialize(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_STAGE_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_STAGE_INITIALIZE_,
                                                                                       IOTable._FSP_STAGE_,
                                                                                       301);
           
            return 0;
        }

        // C302: Stage 移動到自動入料位置
        private int Custom_StageLoad(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_STAGE_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_STAGE_LOAD_,
                                                                                       IOTable._FSP_STAGE_,
                                                                                       302);
           
            return 0;
        }

        // C303: Stage 移動到自動退料位置
        private int Custom_StageUnload(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_STAGE_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_STAGE_UNLOAD_,
                                                                                       IOTable._FSP_STAGE_,
                                                                                       303);            

            return 0;
        }
        #endregion

        #region FSP4

        // C401: Quick 點燈
        private int Custom_QuickLingtOn(string p_strCmd)
        {                      
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_QUICK_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_QUICK_LIGHTON_,
                                                                                       IOTable._FSP_QUICK_,
                                                                                       401);
           
            return 0;
        }

        // C402: Quick Teaching
        private int Custom_QuickTeaching(string p_strCmd)
        {
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_QUICK_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_QUICK_TEACHING_,
                                                                                       IOTable._FSP_QUICK_,
                                                                                       402);
            
            return 0;
        }
        #endregion

        #region FSP5

        // C501: 操作盒動作
        private int Custom_TeachBox(string p_strCmd)
        {            
            if (CCTKform.TK_Func1.CCFunc1Module_IsIdle(IOTable._FSP_TEACHBOX_) != 1)
                return _Return_MMI_Error_(p_strCmd, 8721); 

            CCTKform.TK_Func1.CCFunc1Module_Run(IOTable._JOB_TEACHBOX_MODE_,
                                                                                       IOTable._FSP_TEACHBOX_,
                                                                                       501);            
            return 0;
        }
        #endregion
    }
}

