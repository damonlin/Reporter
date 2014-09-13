using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Common
{
    
    public class DearError_Def
    {
        static private ArrayList ARtnCode = new ArrayList();
        static private bool mbInit = false;
        
        public DearError_Def()
        {
            if (mbInit == false)
            {
                mbInit = true;
                InitDearErrorCode();
            }
        }
        
        //20090323 志忠~~初始化TK的回傳Code
        private void InitDearErrorCode()
        {
            // A Code
            //ARtnCode.Add("Axxx, ARtn_xxxx");                      //我是A Code範例

            // R Code
            //ARtnCode.Add("Rxxx, Rtn_xxxx");                      //我是R Code範例

            ARtnCode.Add("R100, Rtn_AllMotorHome");                 //旋轉、翻轉 初始化Home
            ARtnCode.Add("R101, Rtn_CCDAxleChangeMove");            //鏡頭切換軸移動

            ARtnCode.Add("R201, Rtn_AutoLoad");                     //自動入料
            ARtnCode.Add("R202, Rtn_AutoUnload");                   //自動出料
            ARtnCode.Add("R203, Rtn_UpperLoadProcess");             //上半部入料流程
            ARtnCode.Add("R204, Rtn_UpperUnloadProcess");           //上半部出料流程
            ARtnCode.Add("R205, Rtn_BottomLoadProcess");            //下半部入料流程
            ARtnCode.Add("R206, Rtn_LastUnloadProcess");            //最後一片出料流程

            ARtnCode.Add("R300, Rtn_StageInitProcess");             //平台出始化流程
            ARtnCode.Add("R301, Rtn_StageAutoLoadProcess");         //平台自動入料流程
            ARtnCode.Add("R302, Rtn_StageAutoUnloadProcess");       //平台自動出料流程
            ARtnCode.Add("R303, Rtn_StageBeforehandClipProcess");   //平台預夾流程
            ARtnCode.Add("R304, Rtn_LaserRepairProcess");           //雷射修補流程
            ARtnCode.Add("R305, Rtn_LampProcess");                  //點燈流程

            ARtnCode.Add("R401, Rtn_SGL_Move");                    //S&G&L 移動
            ARtnCode.Add("R402, Rtn_QS1QG1_Move");                 //QS1&QG1 移動 
            ARtnCode.Add("R403, Rtn_QS2QG2_Move");                 //QS2&QG2 移動
            ARtnCode.Add("R404, Rtn_QS3QG3_Move");                 //QS3&QG3 移動
            ARtnCode.Add("R405, Rtn_QS4QG4_Move");                 //QS4&QG4 移動
            ARtnCode.Add("R406, Rtn_QS5QG5_Move");                 //QS5&QG5 移動
            ARtnCode.Add("R407, Rtn_QS6QG6_Move");                 //QS6&QG6 移動
            ARtnCode.Add("R408, Rtn_QS7QG7_Move");                 //QS7&QG7 移動
            ARtnCode.Add("R409, Rtn_B1B2_Move");                   //B1&B2 移動
            ARtnCode.Add("R410, Rtn_C1C2_Move");                   //C1C2 移動
            ARtnCode.Add("R411, Rtn_TSTG_Move");                   //TS&TG 移動

            ARtnCode.Add("R501, Rtn_SGL_Box_Control");            //S&G&L Box Control
            ARtnCode.Add("R502, Rtn_QS1QG1_Box_Control");          //QS1&QG1 Box Control
            ARtnCode.Add("R503, Rtn_QS2QG2_Box_Control");          //QS2&QG2 Box Control
            ARtnCode.Add("R504, Rtn_QS3QG3_Box_Control");          //QS3&QG3 Box Control
            ARtnCode.Add("R505, Rtn_QS4QG4_Box_Control");          //QS4&QG4 Box Control
            ARtnCode.Add("R506, Rtn_QS5QG5_Box_Control");          //QS5&QG5 Box Control
            ARtnCode.Add("R507, Rtn_QS6QG6_Box_Control");          //QS6&QG6 Box Control
            ARtnCode.Add("R508, Rtn_QS7QG7_Box_Control");          //QS7&QG7 Box Control
            ARtnCode.Add("R509, Rtn_C1C2_Box_Control");             //C1C2 Box Control
            ARtnCode.Add("R510, Rtn_TSTG_Box_Control");            //TS&TG Box Control

            // E Code
            //ARtnCode.Add("Exxxx, ERtn_xxxx");                      //我是E Code範例

        }

        //20090323 志忠~~比較TK的回傳Code
        public void strcmpDearErrorCode(StringBuilder strReturnCode)
        {
            //20090323 志忠~~用來存放分割
            string[] szHandDearError;
            String[] szReturnDearErrorCode;
            //20090325 志忠~~比對字串是否成功
            bool bCompareSuccessful = false;
            DearError.DearErrorCode CompareSuccessful = new DearError.DearErrorCode();

            for (int i = 0; i < ARtnCode.Count; i++)
            {
                //20090323 志忠~~分割初始化TK的回傳Code
                szHandDearError = ARtnCode[i].ToString().Split(',');
                //20090324 志忠~~分割傳過來的訊息
                szReturnDearErrorCode = strReturnCode.ToString().Split(',');

                //20090323 志忠~~比對回傳的DearErrorCode
                if (String.Equals(szHandDearError[0], szReturnDearErrorCode[0]) == true)
                {
                    //20090323 志忠~~依照DearErrorCode來呼叫對應的函式
                    switch (szHandDearError[0])
                    {
                        case "R100":
                            CompareSuccessful.Rtn_AllMotorHome(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R101":
                            CompareSuccessful.Rtn_CCDAxleChangeMove(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R201":
                            CompareSuccessful.Rtn_AutoLoad(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R202":
                            CompareSuccessful.Rtn_AutoUnload(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R203":
                            CompareSuccessful.Rtn_UpperLoadProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R204":
                            CompareSuccessful.Rtn_UpperUnloadProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R205":
                            CompareSuccessful.Rtn_BottomLoadProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R206":
                            CompareSuccessful.Rtn_LastUnloadProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R300":
                            CompareSuccessful.Rtn_StageInitProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R301":
                            CompareSuccessful.Rtn_StageAutoLoadProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R302":
                            CompareSuccessful.Rtn_StageAutoUnloadProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R303":
                            CompareSuccessful.Rtn_StageBeforehandClipProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R304":
                            CompareSuccessful.Rtn_LaserRepairProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R305":
                            CompareSuccessful.Rtn_LampProcess(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R401":
                            CompareSuccessful.Rtn_SGL_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R402":
                            CompareSuccessful.Rtn_QS1QG1_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R403":
                            CompareSuccessful.Rtn_QS2QG2_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R404":
                            CompareSuccessful.Rtn_QS3QG3_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R405":
                            CompareSuccessful.Rtn_QS4QG4_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R406":
                            CompareSuccessful.Rtn_QS5QG5_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R407":
                            CompareSuccessful.Rtn_QS6QG6_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R408":
                            CompareSuccessful.Rtn_QS7QG7_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R409":
                            CompareSuccessful.Rtn_B1B2_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R410":
                            CompareSuccessful.Rtn_C1C2_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R411":
                            CompareSuccessful.Rtn_TSTG_Move(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R501":
                            CompareSuccessful.Rtn_SGL_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R502":
                            CompareSuccessful.Rtn_QS1QG1_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R503":
                            CompareSuccessful.Rtn_QS2QG2_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R504":
                            CompareSuccessful.Rtn_QS3QG3_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R505":
                            CompareSuccessful.Rtn_QS4QG4_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R506":
                            CompareSuccessful.Rtn_QS5QG5_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R507":
                            CompareSuccessful.Rtn_QS6QG6_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R508":
                            CompareSuccessful.Rtn_QS7QG7_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R509":
                            CompareSuccessful.Rtn_C1C2_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                        case "R510":
                            CompareSuccessful.Rtn_TSTG_Box_Control(strReturnCode.ToString());
                            bCompareSuccessful = true;
                            break;
                    }
                    break;
                }
            }

            if (!bCompareSuccessful)
            {
                //if (strReturnCode[0] == 'R' && strReturnCode[4] == ',' && strReturnCode[5] == '0')
                //{
                    //20090324 志忠~~這個Code什麼都不做
                //}
                if (strReturnCode[0] == 'R' || strReturnCode[0] == 'E' || strReturnCode[0] == 'A' || strReturnCode[0] == 'X')
                {
                    //20090324 志忠~~這個Code呼叫AlarmMsg
                    CompareSuccessful.Rtn_NotDefineCode(strReturnCode.ToString());
                }
            }
        }

    }
}
