using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SDDEMsg
{
    public class SDDE
    {
        IntPtr[] mahTCPIP;
        public int rtnQueueMaxCharNum;

        static private SDDE Singleton;

        public static SDDE GetSingleton()
        {           
            if(Singleton == null)
                Singleton = new SDDE();
            return Singleton;
        }
        
        // Constructor
        public SDDE()
        {
            this.mahTCPIP = new IntPtr[1];
            this.rtnQueueMaxCharNum = 200;
            //createObject();
        }

        public int createObject()
        {
            // Log saving
            TCPIP_Tag TCPIPTagInfo = new TCPIP_Tag();

            this.mahTCPIP[0] = TCPIP2.CreateObject( TCPIPTagInfo.tkTCPAddress, 
                                                    TCPIPTagInfo.tkTCPPort,
                                                    (int)TCPIP_Tag.Mode.Client,
                                                    TCPIPTagInfo.cmdQueueMaxCharNum,
                                                    TCPIPTagInfo.logSavePath, 
                                                    TCPIPTagInfo.logName);

            TCPIP2.SetValByVoid(this.mahTCPIP[0], (int) TCPIP_Tag.ValType.getClntName, (IntPtr) 0);

            return 0;
        }

        public int DeleteObject()
        {
	         return TCPIP2.DeleteObject(this.mahTCPIP[0]);  
        }

        public int Connect()
        {
            return TCPIP2.Connect(this.mahTCPIP[0]); 
        }

        public int SendMessageToTK(string Msg)
        {
	        return TCPIP2.SendMessage(this.mahTCPIP[0], Msg);  
        }

        public int GetMessageFromTK(StringBuilder Msg)
        {
            Msg.Capacity = 200;
            return TCPIP2.GetMessage(this.mahTCPIP[0], Msg, rtnQueueMaxCharNum);            
        }

        public int GetSDDEStatus()
        { 
            return TCPIP2.GetTCPIPStatus(this.mahTCPIP[0]);  
        }

        public int SetSDDESimulateON()
        {
	         return TCPIP2.SetSimulate(this.mahTCPIP[0], 1);
        }

        public int SetSDDESimulateOFF()
        {
	         return TCPIP2.SetSimulate(this.mahTCPIP[0], 0);  
        }

        public int SDDE_Display()
        {
	         return TCPIP2.ShowTool(this.mahTCPIP[0], 1);
        }

        public int SDDE_Hide()
        {
	         return TCPIP2.ShowTool(this.mahTCPIP[0], 0);    
        }

        public int SDDE_CheckCmdSendComplete()
        {
	        int fSendStatus = 0;
        	
            if (RtnQueue_IsEmpty() == 1 && fSendStatus == 0)  //command queue is empty and return title is return to MMI
		        return 0;
	        else
		        return -1;
        }

        public int TK_Save_DDE_Func() 
        {
	         TCPIP2.SaveLog(this.mahTCPIP[0]);
	         return 0;
        }

        public int CmdQueue_Clear()
        {
	         return TCPIP2.QueueClear(this.mahTCPIP[0], (int) TCPIP_Tag.QueueType.Send);
        }

        public int CmdQueue_IsEmpty()
        {
	         return TCPIP2.IsQueueEmpty(this.mahTCPIP[0], (int) TCPIP_Tag.QueueType.Send);
        }

        public int CmdQueue_IsFull()
        {
	         return TCPIP2.IsQueueFull(this.mahTCPIP[0], (int) TCPIP_Tag.QueueType.Send);  
        }

        public int CmdQueue_SetQueue(string Msg)
        {
	         return TCPIP2.SendMsgToSelf(this.mahTCPIP[0], Msg);
        }

        public int RtnQueue_IsEmpty()
        {
	         return TCPIP2.IsQueueEmpty(this.mahTCPIP[0], (int) TCPIP_Tag.QueueType.Receive);  
        }

        public int RtnQueue_IsFull()
        {
            return TCPIP2.IsQueueFull(this.mahTCPIP[0], (int)TCPIP_Tag.QueueType.Receive);
        }

    }


    //  TCPIP Info Pre-define..
    public class TCPIP_Tag
    {
        public string tkTCPAddress = "127.0.0.1";
        public string logSavePath = "D:\\TCP";
        public string logName = "SDDE-";
        public int tkTCPPort = 1234;
        public int TCPIPMode = (int)TCPIP_Tag.Mode.Client;
        public int cmdQueueMaxCharNum = 200;


        // Enumeration declare 
        public enum Mode
        {
            Client = 0,
            Sever
        }

        public enum ValType
        {
            Timeout = 1,
            reSendTimes,
            logEnable,
            logSaveMode,
            connectPassedTime,
            getClntIP,
            getClntName,
            sendStatus
        }

        public enum Status
        {
            Disconnect = 0,
            Connect = 1,
            Connecting = 3,
            Disconnecting = 4,
            Preconnecting = 5,
            Error = -1,
            Simulate = -99
        }

        public enum QueueType
        {
            Send = 0,
            Receive
        }

        public enum LGMD
        {
            Buffer = 0,
            Direct
        }

        public enum ToolMode
        {
            Hide = 0,
            Normal,
            Advance,
            Normalpop,
            Advnacepop
        }
    }


    // Dll Import decleare 轉置
    public class TCPIP2
    {
        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_CreateObject")]
        public static extern IntPtr CreateObject(string IP, int port, int clientOrServer, int maxCharNum, string logPath, string logName);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_DeleteObject")]
        public static extern int DeleteObject(IntPtr pthis);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_Connect")]
        public static extern int Connect(IntPtr pthis);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_Disconnect")]
        public static extern int Disconnect(IntPtr pthis);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_GetTCPIPStatus")]
        public static extern int GetTCPIPStatus(IntPtr pthis);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_GetMessage")]
        public static extern int GetMessage(IntPtr pthis, StringBuilder buffer, int bufSize);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_SendMessage")]
        public static extern int SendMessage(IntPtr pthis, string buffer);


        // 虛擬收到 Msg, 將 Msg 丟到 RecQueue
        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_SendMsgToSelf")]
        public static extern int SendMsgToSelf(IntPtr pthis, string buffer);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_SaveLog")]
        public static extern int SaveLog(IntPtr pthis);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_SetSimulate")]
        public static extern int SetSimulate(IntPtr pthis, int bSimulate);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_SetValue")]
        public static extern int SetValue(IntPtr pthis, int iType);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_GetValByVoid")]
        public static extern int GetValByVoid(IntPtr pthis, int iType, IntPtr pVal);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_SetValByVoid")]
        public static extern int SetValByVoid(IntPtr pthis, int iType, IntPtr pVal);


        // Show Tool panel
        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_ShowTool")]
        public static extern int ShowTool(IntPtr pthis, int iShow);

        // about Send & Receive Queue
        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_QueueClear")]
        public static extern int QueueClear(IntPtr pthis, int iQueueType);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_IsQueueEmpty")]
        public static extern int IsQueueEmpty(IntPtr pthis, int iQueueType);

        [DllImport("TCPIP.dll", EntryPoint = "TCPIP2_IsQueueFull")]
        public static extern int IsQueueFull(IntPtr pthis, int iQueueType);
    }
}