
#define PLC_ON

using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;
using System.Configuration;
using IniTool;

namespace ContrelModule
{
   public class CPLCInterface
   {        
       #region Public Member
       public class PLCData
       {
           public CONTROL_CODE m_controlCode { get; set; }      // 控制代碼
           public string m_StationNum { get; set; }             // 站號
           public string m_PCNum { get; set; }                  // PC 號
           public string m_Command { get; set; }                // 指令
           public string m_WaitTime { get; set; }               // 報文等待
           public string m_RcvData { get; set; }                // Data
           public string m_CheckSum { get; set; }               // Checksum
           public DATA_TYPE m_DataType { get; set; }            // 資料類型: M or D type
       }   

       public enum DATA_TYPE
       {
           D_Type, M_Type, Unknow_Type
       };

       public enum CONTROL_CODE
       {
           STX = '\x02',
           ETX = '\x03',
           EOT = '\x04',
           ENQ = '\x05',
           ACK = '\x06',
           LF = '\x0A',
           CL = '\x0C',
           CR = '\x0D',
           NAK = '\x15'
       };       

       #endregion

       #region Private Member

       private SerialPort m_SerialPort = null;
       private ConcurrentQueue<PLCData> m_PLCRcvQueue = new ConcurrentQueue<PLCData>();
       private ConcurrentQueue<string> m_PLCSndQueue = new ConcurrentQueue<string>();

       static private CPLCInterface Singleton;

       private const string strINIPath = "INI\\RS232.INI";
       private const string STATION_NAME = "00";
       private const string PC_NUMBER = "FF";

       // For Threading
       private bool m_bReceiving = false;
       private bool m_bSending = false;
       private Thread m_plcRcvThread;
       private Thread m_plcSndThread;
       #endregion       

       #region Pulic Member
       public PLCData PLCRcvData
       {
           get
           {
               PLCData data;
               while (m_PLCRcvQueue.TryDequeue(out data))
               {
                   return data;
               }
               return null;
           }
           set
           {
               m_PLCRcvQueue.Enqueue(value);
           }
       }

       public string PLCSndData
       {
           get
           {
               string data;
               while (m_PLCSndQueue.TryDequeue(out data))
               {
                   return data;
               }
               return null;
           }
           set
           {
               m_PLCSndQueue.Enqueue(value);
           }
       }
        #endregion

        #region Ctor
        protected CPLCInterface()
        {
            m_SerialPort = new SerialPort();

            LoadIniFile();

            CreateThreads();

        }
        #endregion

        #region properties

        // COM port
        public string PortNumber
        {
            get { return m_SerialPort.PortName; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.PortName = value;
            }
        }

        // Port Boudrate
        public int PortBoudrate
        {
            get { return m_SerialPort.BaudRate; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.BaudRate = value;
            }
        }

        // Port DataBits
        public int PortDataBits
        {
            get { return m_SerialPort.DataBits; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.DataBits = value;
            }
        }

        // Port StopBits
        public StopBits PortStopBits
        {
            get { return m_SerialPort.StopBits; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.StopBits = value;
            }
        }

        // Port Parity
        public Parity PortParity
        {
            get { return m_SerialPort.Parity; }
            set
            {
                if (m_SerialPort.IsOpen == false)
                    m_SerialPort.Parity = value;
            }
        }

        // Port DataReceived     
        public SerialDataReceivedEventHandler DataReceiveHandler
        {
            set
            {
                //if (m_SerialPort.IsOpen == false)
                    m_SerialPort.DataReceived += value;
            }            
        }        
        #endregion

       #region Public Method

       public static CPLCInterface GetSingleton()
       {
           if (Singleton == null)
               Singleton = new CPLCInterface();
           return Singleton;
       }

       public void CloseAllThreads()
       {
           m_bReceiving = false;
           m_bSending = false;

           bool wait = true;
           while (wait)
           {
               wait = m_plcRcvThread.IsAlive | m_plcSndThread.IsAlive;
               Thread.Sleep(16);
           }
       }

       public void Open()
       {
#if PLC_ON
            m_SerialPort.Open();
#endif
       }

       public void Close()
       {
#if PLC_ON
            m_SerialPort.Close();
#endif
       }

       public byte[] Receive()
       {
            int nbytes = m_SerialPort.BytesToRead;
            byte[] data = new byte[nbytes];
#if PLC_ON
            m_SerialPort.Read(data, 0, data.Length);
#endif
            return data;
       }
       

       public void PLCWriteWord_D(string value)
       {
           // ENQ + 站號 + PLC型號 + BR + 延時 + 開始位址 + 長度 + checksum
           StringBuilder cmd = new StringBuilder(100);

           cmd.Append((char)CONTROL_CODE.ENQ);
           cmd.Append(STATION_NAME);
           cmd.Append(PC_NUMBER);
           cmd.Append("WW");
           cmd.Append("A");
           cmd.Append("D0200");
           cmd.Append("09");
           //cmd.Append(String.Format("{0:D4}", Convert.ToInt32(value)));
           cmd.Append("111111111111111111111111111111111111");           

           string checksum = CheckSum(cmd);
           cmd.Append(checksum);
           //m_SerialPort.Write(cmd.ToString());
           PLCSndData = cmd.ToString();
       }

       public void PLCWriteWord_D(string startAddr, int count, string value)
       {
           // ENQ + 站號 + PLC型號 + BR + 延時 + 開始位址 + 長度 + checksum
           StringBuilder cmd = new StringBuilder(100);

           cmd.Append((char)CONTROL_CODE.ENQ);
           cmd.Append(STATION_NAME);
           cmd.Append(PC_NUMBER);
           cmd.Append("WW");
           cmd.Append("A");
           cmd.Append(startAddr);
           cmd.Append(count.ToString("D2"));
           cmd.Append(value);

           string checksum = CheckSum(cmd);
           cmd.Append(checksum);
           //m_SerialPort.Write(cmd.ToString());
           PLCSndData = cmd.ToString();
       }

       public void PLCReadWord_D()
       {
           //ENQ + 站號 + PLC型號 + BR + 延時 + 開始位址 + 長度 + checksum
           StringBuilder cmd = new StringBuilder(30);

           cmd.Append((char)CONTROL_CODE.ENQ);
           cmd.Append(STATION_NAME);
           cmd.Append(PC_NUMBER);
           cmd.Append("WR");
           cmd.Append("A");
           cmd.Append("D1616"); // Read From D1616 ~ D1619
           cmd.Append("04");

           string checksum = CheckSum(cmd);
           cmd.Append(checksum);           
           PLCSndData = cmd.ToString();
       }

       public void PLCWriteBit_M(string addr, int count, bool bOn)
       {
           //ENQ + 站號 + PLC型號 + BR + 延時 + 開始位址 + 長度 + checksum
           StringBuilder cmd = new StringBuilder(30);

           cmd.Append((char)CONTROL_CODE.ENQ);
           cmd.Append(STATION_NAME);
           cmd.Append(PC_NUMBER);
           cmd.Append("BW");
           cmd.Append("A");
           cmd.Append(addr);
           cmd.Append(count.ToString("D2"));

           int value1 = (bOn) ? 1 : 0;
           cmd.Append(value1.ToString());

           if (count == 2)
           {
               int value2 = (bOn) ? 0 : 1;
               cmd.Append(value2.ToString());
           }
                    
           string checksum = CheckSum(cmd);
           cmd.Append(checksum);           
           PLCSndData = cmd.ToString();
       }

       public void PLCReadBit_M()
       {
           //ENQ + 站號 + PLC型號 + BR + 延時 + 開始位址 + 長度 + checksum
           StringBuilder cmd = new StringBuilder(30);

           cmd.Append((char)CONTROL_CODE.ENQ);
           cmd.Append(STATION_NAME);
           cmd.Append(PC_NUMBER);
           cmd.Append("BR");
           cmd.Append("A");
           cmd.Append("M2120");  // Read M from M2120 ~ M2126
           cmd.Append("07");          
         
           string checksum = CheckSum(cmd);
           cmd.Append(checksum);
           PLCSndData = cmd.ToString();
       }
         
       public PLCData DecodePLCData(byte[] rcvData)
       {
           if (rcvData[0] != (int)CONTROL_CODE.STX)
               return null;

           PLCData data = new PLCData();
           int iOffset = 0;

           // 1. 控制代碼
           data.m_controlCode = (CONTROL_CODE)Enum.Parse(typeof(CONTROL_CODE), rcvData[iOffset++].ToString());

           // 2. 站號
           byte[] stationNum = new byte[2];
           Array.Copy( rcvData, iOffset, stationNum, 0, stationNum.Length);
           iOffset += 2;
           data.m_StationNum = Encoding.Default.GetString(stationNum);

           //3. PC 號
           byte[] pcNum = new byte[2];
           Array.Copy( rcvData, iOffset, pcNum, 0, pcNum.Length);
           iOffset += 2;
           data.m_PCNum = Encoding.Default.GetString(pcNum);

           //4. Data
           byte[] tmpdata = new byte[rcvData.Length - 8];
           Array.Copy(rcvData, iOffset, tmpdata, 0, tmpdata.Length);
           data.m_RcvData = Encoding.Default.GetString(tmpdata);

           // check which type of 
           int iIdx = iOffset;
           for( ;iIdx < rcvData.Length; ++iIdx)
               if( rcvData[iIdx] == (byte)CONTROL_CODE.ETX )
                   break;

           int dataLength = iIdx - iOffset + 1;
           switch(dataLength)
           {
               case 17:     // This is Read D type from PLC : D1616 ~ D1619(一共 4*4 = 16 byte)
                   data.m_DataType = DATA_TYPE.D_Type;
                   break;

               case 8:      // This is Read M type from PLC : M2120 ~ M2128(一共 9*1 = 9 byte)
                   data.m_DataType = DATA_TYPE.M_Type;
                   break;

               default:
                   return null;  // Unknown Type                   
           }
           return data;
       }      

       public void DoReceive()
       {           
           //Byte[] buffer = new Byte[1024];
           while ( m_bReceiving )
           {
#if PLC_ON
               if (m_SerialPort.IsOpen && m_SerialPort.BytesToRead > 0)
               {                   
                   //Int32 length = m_SerialPort.Read(buffer, 0, buffer.Length);
                   //Array.Resize(ref buffer, length);
                   Byte[] buffer = Receive();

                   PLCData data = DecodePLCData(buffer);
                   if (data != null )
                       m_PLCRcvQueue.Enqueue(data);
               }
#endif
               Thread.Sleep(16);

           }
       }

       public void DoSend()
       {
           while (m_bSending)
           {
#if PLC_ON
               if (m_SerialPort.IsOpen && m_PLCSndQueue.Count > 0)
               {
                   string data = PLCSndData;

                   m_SerialPort.Write(data);
#endif
               }           
               Thread.Sleep(16);
           }
       }

       #endregion

       #region Private Method      

       private void CreateThreads()
       {
           // For Recive Thread
           m_bReceiving = true;
           m_plcRcvThread = new Thread( DoReceive );
           m_plcRcvThread.IsBackground = true;
           m_plcRcvThread.Start();

           // For Recive Thread
           m_bSending = true;
           m_plcSndThread = new Thread( DoSend);
           m_plcSndThread.IsBackground = true;
           m_plcSndThread.Start();                
       }

       private void LoadIniFile()
       {
           IniFile iniFile = new IniFile(strINIPath);

           int port = iniFile.GetInt32("RS232", "ComPort", 0);
           PortNumber = string.Format("COM{0:d}", port);

           PortBoudrate = iniFile.GetInt32("RS232", "Boudrate", 0);

           string stop = iniFile.GetString("RS232", "StopBits", "");
           PortStopBits = (StopBits)Enum.Parse(typeof(StopBits), stop);

           string parity = iniFile.GetString("RS232", "Parity", "");
           PortParity = (Parity)Enum.Parse(typeof(Parity), parity);

           PortDataBits = iniFile.GetInt32("RS232", "DataBits", 0);
       }

       private string CheckSum(StringBuilder str)
       {
            //宣告：int為整數、string為字符串
            int sum = 0;
            string checkstring = "";
            string checksum = "";
     
            //通訊格式中的英文字符必須為大寫(a~f)，故先行將text所輸入之傳送數據，經由程序自動轉換為大寫字母，然後加上結束碼etx：chr(3)，形成一字符串checkstring
            checkstring = str.ToString();
     
            // for屬於重複結構中之計數循環，指令pc在一定的次數內，重複的執行某一敘述區段，亦即取出checkstring字符串中每一個字符，並累加每一個字符的ascii碼，而得出一整數sum。
            for (int i = 1; i < checkstring.Length; i++) 
            {
                int tmp = Convert.ToInt32(checkstring[i]);
                sum += tmp;
            }
     
            //將10進制整數sum轉換為16進制，並取其右邊二位數，即為所求檢查碼。
            checksum = String.Format("{0:X}", sum);
            checksum.PadLeft(2,'0');
            checksum = checksum.Substring(checksum.Length - 2, 2);
         
            return checksum;
        } 
       #endregion      
        
    }
}
