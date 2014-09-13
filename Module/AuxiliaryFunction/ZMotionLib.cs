using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ContrelModule
{
    public enum ZMotionErrorMessage
    {
        ZM_AFFINISH = 1,

        ZMERR_DATA = 7920,
        ZMERR_COMMAND_UDEF = 7921,
        ZMERR_INTERNAL = 7922,
        ZMERR_RECV_TIMEOVER = 7923,
        ZMERR_RECV_BUFFER_OVERFLOW = 7924,
        ZMERR_SETTING_MODE = 7925,
        ZMERR_PARAMETER = 7926,
        ZMERR_PARAM_OUTOFRANGE = 7927,
        ZMERR_CHECKSUM = 7928,

        ZMERR_LIMIT = 7929,
        ZMERR_AUTOFOCUS = 7930,
        ZMERR_TIMEOVER = 7931,
        ZMERR_AFV_END = 7932,
        ZMERR_SEARCH_LIMIT = 7933,
        ZMERR_AFPARAM_AUTOSET = 7934,
        ZMERR_EMERGENCY_STOP = 7935,
        ZMERR_BACKUP = 7936,
        ZMERR_STOP_HARD = 7937,

        ZMERR_LIMIT_RANGE = 7940

    }
    public class ZMotion
    {
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMInitPortInf@@YAXIHHPADH@Z")]
        public static extern void ZMInitPortInf(uint Port, int baud, int databits, char parity, int stopbit);

        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMInitial@@YAHH@Z")]
        public static extern int ZMInitial(bool simulate);
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMRelease@@YAXXZ")]
        public static extern void ZMRelease();

        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMShowDebugDlg@@YAXH@Z")]
        public static extern void ZMShowDebugDlg(bool show);

        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?AFOpenConnection@@YAXXZ")]
        public static extern void AFOpenConnection();
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMPowerSwitch@@YAXH@Z")]
        public static extern void ZMPowerSwitch(bool value);
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMDoorInterlock@@YAXH@Z")]
        public static extern void ZMDoorInterlock(bool value);


        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMChangeAFParam@@YAXH@Z")]
        public static extern void ZMChangeAFParam(int group);						//更改每個鏡頭的參頭
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMAutofocus@@YAXXZ")]
        public static extern void ZMAutofocus();									//AutoFocus
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMHome@@YAHH@Z")]
        public static extern int ZMHome(bool dscanup);							//歸零
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMStopHoming@@YAXXZ")]
        public static extern void ZMStopHoming();									//歸零中止
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMStop@@YAXXZ")]
        public static extern void ZMStop();										//停止
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMGetCurrentPosition@@YANXZ")]
        public static extern double ZMGetCurrentPosition();							//讀取現在位置
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSoftLimit@@YAXH@Z")]
        public static extern void ZMSoftLimit(bool dir);							//Move to soft limit
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSetSoftLimit@@YAXJJ@Z")]
        public static extern void ZMSetSoftLimit(long LimitHigh, long LimitLow);

        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMAbsMove@@YAXN@Z")]
        public static extern void ZMAbsMove(double position);						//絕對移動
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMRelMove@@YAXN@Z")]
        public static extern void ZMRelMove(double pulse);						//相對移動
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMScan@@YAXH@Z")]
        public static extern void ZMScan(bool direction);

        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMBackward@@YAXXZ")]
        public static extern void ZMBackward();
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMContinue@@YAXXZ")]
        public static extern void ZMContinue();
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSetpping@@YAXHH@Z")]
        public static extern void ZMSetpping(bool direction, int StepPulse);

        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMReady@@YAHXZ")]
        public static extern bool ZMReady();

        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSetStageSpeedPara@@YAXJJN@Z")]
        public static extern void ZMSetStageSpeedPara(long MiniSpeed, long MaxSpeed, double Acc);
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMGetStageSpeedPara@@YAXJJN@Z")]
        public static extern void ZMGetStageSpeedPara(long acc, long dec, double speed);


        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMUnRegestCallbackFunc@@YAXXZ")]
        public static extern void ZMUnRegestCallbackFunc();

        //新增部份
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSetAdvancedStageLens@@YAXH@Z")]
        public static extern void ZMSetAdvancedStageLens(int lens);				//控制每個鏡頭的高、中、低速度
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSetAdvancedStageControl@@YAXH@Z")]
        public static extern void ZMSetAdvancedStageControl(int ManuSpeed);
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSetAdvancedStageControlCmd@@YAXXZ")]
        public static extern void ZMSetAdvancedStageControlCmd();

        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSetStageSpeedParameter@@YAXH@Z")]
        public static extern void ZMSetStageSpeedParameter(int ManuSpeed);		//控制主程式中上及下按鍵的速度
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSetStageSpeedParameterCmd@@YAXXZ")]
        public static extern void ZMSetStageSpeedParameterCmd();

        //新增部份20040708
        [DllImport("ZMotion.dll", SetLastError = true, EntryPoint = "?ZMSetPGSB@@YAXNJJ@Z")]
        public static extern void ZMSetPGSB(double resol, long ulimit, long dlimit);		//設定解析度及上下極限位置
        //resolution Unit: um/pulse
    }
}
