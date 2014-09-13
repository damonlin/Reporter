//#define Debug
#define _Robot_Type_

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TK;
using TKUnit;
using ModuleInterface;
using System.Collections;

namespace TKUnit
{
    public class Schedule : MarshalByRefObject
    {
        private static Schedule singleton;
        private static bool ThreadLife = true;
        
        
        public static Schedule GetSingleton()
        {
            if (singleton == null)
            {
                singleton = new Schedule();
            }
            return singleton;
        }

        protected Schedule()
        {
            Thread funcQueueThread = new Thread(AutorunSchedule);
            funcQueueThread.Priority = ThreadPriority.Highest;
            //funcQueueThread.Start();

            // TK Schedule 初始化動作

           
            
        }

        public void Destroy()
        {
            ThreadLife = false;
        }

        private void AutorunSchedule()
        {
            while (ThreadLife == true)
            {
                Check_FSP_Status();
                ProcessFuncQueue();
                ScheduleCommand();

                Thread.Sleep(10);
            }
        }

        // ===================================================================== 
        //      Check FSP Status Start ( FSP Status = Normal or Error )
        // Return : [0,Normal],[-1,Error]
        // ===================================================================== 
        private int Check_FSP_Status()
        {
            //int l_iFunc1OP1 = 0, l_iFunc1OP2 = 0, l_iFunc1OP3 = 0, l_iFunc1Index = 0, l_iFunc1DebugFlag = 0, l_iFunc1JobID = 0;
            //long l_iFunc1RunningTime = 0;

            /*
            // FSP01
            if (CCTKform.TK_Func1.CCFunc1Module_ReadStatus(IOTable._MACRO_HOME_, ref CCAutorunStatus.fMacroHome_Task, ref l_iFunc1OP1, ref l_iFunc1OP2, ref l_iFunc1OP3, ref l_iFunc1Index, ref l_iFunc1DebugFlag, ref l_iFunc1JobID, ref l_iFunc1RunningTime) != 0)
            {
                //fTKMode = _MANUAL_MODE_;
                //_DISABLE_AUTORUN_TIMER_
                //_Auto_RunTime_Error_(_GET_FSP0_STATUS_ERROR_ + 1)
                //_Exit_Autorun_Mode_
                return -1;
            }
            */
            return 0;
        }


        //================================================================
        //Function Name: ProcessFuncQueue
        //Parameter:None
        //Return Value: 0:Success
        //Remark:用來檢查FSP結束後該執行那些事
        //================================================================
        private void ProcessFuncQueue()
        {
            int hFunctionHandle = 0;
            int iData1 = 0, iData2 = 0, iData3 = 0;

            while (CCTKform.TK_FuncQueue.CCFuncQueue_IsEmpty() == 0)
            {
                CCTKform.TK_FuncQueue.CCFuncQueue_Get(ref hFunctionHandle, ref iData1, ref iData2, ref iData3);

                // ===================================================================== 
                //          Process FSP Return Status Start (OK or Error)
                // 主要設定各個 Job 完成後的各項旗標
                // continue 指令主要回到 while(FuncQueue_IsEmpty() == 0)之外, 並略過
                // Other Return Code 的 Check (A001, A0999, and Other Normal return)
                // ===================================================================== 
                
                if (IOTable._FSP_HOME_ == hFunctionHandle)
                {
                    switch (iData1)
                    {
                        case 100:
                            A100_Initialize(iData1, iData2, iData3);
                            break;
                    }
                }
                else if (IOTable._FSP_STAGE_ == hFunctionHandle)
                {
                    switch (iData1)
                    {
                        case 201:
                            break;
                        case 202:
                            break;
                        case 203:
                            break;
                        case 204:
                            break;
                        case 205:
                            break;
                        case 206:
                            break;
                        default:
                            continue;
                    }
                }
                else if (IOTable._FSP_TurnUint_ == hFunctionHandle)
                {
                    switch (iData1)
                    {
                        case 301:
                            break;
                        case 302:
                            break;
                        case 303:
                            break;
                        default:
                            continue;
                    }
                }
                else if (IOTable._FSP_QUICK_ == hFunctionHandle)
                {
                    switch (iData1)
                    {
                        case 401:
                            break;
                        case 402:
                            break;
                        default:
                            continue;
                    }
                }
                else if (IOTable._FSP_TEACHBOX_ == hFunctionHandle)
                {
                    switch (iData1)
                    {
                        case 501:
                            break;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        //================================================================
        // Function Name: ScheduleCommand
        // Parameter:None
        // Return Value: 0:Success
        // Remark:用來檢查一些可能在ProcessFuncQueue中檢查某FSP的Job結束後
        //        並設定一些flag後，判斷後續要執行那些動作或Job
        //================================================================
        private void ScheduleCommand()
        {
            // We detect whether the buttons of TeachBox Control are pressed !!
            CheckTeachBoxLensButton();
            CheckTeachBoxSpeedButton();
            CheckTeachBoxLaserButton();
        }

        #region Process FSP Return Data
        private void do_check(int[] iVIO, int[] iDO)
        {
            for (int iIdx = 0; iIdx < iVIO.Length; ++iIdx)
            {
                bool bCheckVIO = false;
                TK.CCTKform.TK_VIO.CCVioModule_GetVIO(iVIO[iIdx], ref bCheckVIO);
                if (bCheckVIO)
                {
                    TK.CCTKform.TK_VIO.CCVioModule_SetVIO(iVIO[iIdx], false);

                    bool bCheckVO = false;
                    TK.CCTKform.TK_VIO.CCVioModule_GetVIO(iDO[iIdx], ref bCheckVO);
                    TK.CCTKform.TK_VIO.CCVioModule_SetVIO(iDO[iIdx], !bCheckVO);

                    for (int iJdx = 0; iJdx < iDO.Length; ++iJdx)
                    {
                        if (iJdx == iIdx)
                            continue;
                        TK.CCTKform.TK_VIO.CCVioModule_SetVIO(iDO[iJdx], false);
                    }
                }
            }
        }

        private void CheckTeachBoxLensButton()
        {
            int[] iVIO = {IOTable.VIO._VIO_TRIG_LENS_X2_, IOTable.VIO._VIO_TRIG_LENS_X5_,
                                 IOTable.VIO._VIO_TRIG_LENS_X20_, IOTable.VIO._VIO_TRIG_LENS_X50_};

            int[] iDO = {IOTable.DO._DO_TEACHBOX_LENS_X2_, IOTable.DO._DO_TEACHBOX_LENS_X5_,
                                 IOTable.DO._DO_TEACHBOX_LENS_X20_, IOTable.DO._DO_TEACHBOX_LENS_X50_};

            do_check(iVIO, iDO);
        }

        private void CheckTeachBoxSpeedButton()
        {
            int[] iVIO = {IOTable.VIO._VIO_TRIG_TEACHBOX_FAST_BTN_, IOTable.VIO._VIO_TRIG_TEACHBOX_MIDDLE_BTN_,
                                 IOTable.VIO._VIO_TRIG_TEACHBOX_SLOW_BTN_};

            int[] iDO = {IOTable.DO._DO_TEACHBOX_FAST_BTN_, IOTable.DO._DO_TEACHBOX_MIDDLE_BTN_,
                                 IOTable.DO._DO_TEACHBOX_SLOW_BTN_};

            do_check(iVIO, iDO);
        }

        private void CheckTeachBoxLaserButton()
        {
            int[] iVIO = {IOTable.VIO._VIO_TRIG_LASE_RFIRE_BTN_, IOTable.VIO._VIO_TRIG_LASER_STOP_BTN_};                                 

            int[] iDO = { IOTable.DO._DO_TEACHBOX_LASER_FIRE_, IOTable.DO._DO_TEACHBOX_LASER_STOP_ };

            do_check(iVIO, iDO);
        }
        

        private void A100_Initialize(int p_iData1, int p_iData2,int p_iData3)
        {
            Process.GetSingleton().SendMessageToMMI("A100,0");
        }
        #endregion
    }
}