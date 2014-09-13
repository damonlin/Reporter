using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using RS232Communication;
using System.Threading;

namespace ZSModule
{

    public class ZSMeasure
    {
        protected enum OMRONChar : byte
        {
            _RS232_STX_ = 0x02,
            _RS232_ETX_ = 0x03
        }

        private SerialPort RS232Comm;
        

        public void ZSModule_InitialComm()
        {                        
            RS232Comm = new SerialPort();

            Thread RcvMsgThread = new Thread(new ThreadStart(this.RS232Comm_OnComm));

            RS232Comm.PortName = "COM10";
            RS232Comm.BaudRate = 115200;
            RS232Comm.DataBits = 8;
            //RS232Comm.StopBits = 0;

            if (RS232.GetSignleton().CreateRS232Interface(ref RS232Comm) != 0)                            
                return ;

            RcvMsgThread.Start();

        }

        public void ZSModule_CloselComm()
        {
            RS232.GetSignleton().DestroyRS232Interface(ref RS232Comm);
        }

        private int bProcessMsgFlag = 0;
        //送訊息置機台
        public int SendCmdToModule(string szCmd)
        {
            string szSendTemp;
            int iSum = 0;
            /*
            //Queue Process =>直接處理最新的
            if (pArrayListQueue.Count > 0)
            {
                ProcessComData((string)pArrayListQueue[pArrayListQueue.Count - 1]);
                pArrayListQueue.Clear();
            }
            */
            //組織發送命令 Send Cmd To Module
            if (bProcessMsgFlag == 0)
            {
                szSendTemp = Convert.ToChar(OMRONChar._RS232_STX_) + "000000201C02030008001"
                   + Convert.ToChar(OMRONChar._RS232_ETX_);

                for (int i = 1; i < szSendTemp.Length; i++)
                    iSum ^= szSendTemp[i];
                iSum = iSum & 0xff;

                RS232Comm.Write(szSendTemp + Convert.ToChar(iSum));

                bProcessMsgFlag = 1;
            }
            return 0;
        }
        //接收訊息
        public void RS232Comm_OnComm()
        {
            //檢查緩衝區裏是否有資料，若有資料將資料傳給ProcessComData處理，當然您也可以直接在
            //這個函式中處理，在此我們將資料轉字串的方式處理(string)，若是其他的資料，則轉為byte矩陣(byte [])。                      
           //while (1)
           {
                if (this.RS232Comm.BytesToRead > 0)
                {
                    string data = RS232Comm.ReadExisting();

                    //方法1.因為會出現跨執行續問題丟入Queue
                    //pArrayListQueue.Add(data);

                    //方法2.因為會出現跨執行續問題所以加入此行
                    //ProcessComData(data); 

                    //方法3.先直接處理資料,才可以接收訊息
                    int iDisVal = System.Int32.Parse(data.Substring(27, 8),
                                  System.Globalization.NumberStyles.AllowHexSpecifier);

                    this.bProcessMsgFlag = 0;
                }
           }
        }

        #region 暫時不用
        /*
        private void ProcessComData(string input)
        {
            int iDisVal = System.Int32.Parse(input.Substring(27, 8),
                          System.Globalization.NumberStyles.AllowHexSpecifier);

            //方法1.因為會出現跨執行續問題丟入Queue
            //this.richTxtRcv.AppendText(input + "\n");
            //this.txtDist.Text = Convert.ToString((float)iDisVal / 1000000);        
           
            //方法2.因為會出現跨執行續問題所以加入此行            
            //UpdateUI(input, this.richTxtRcv);
            //UpdateUI(Convert.ToString((float)iDisVal / 1000000), this.txtDist);                      
        }  
               
        private void btnSend_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }

        
        //以避免跨執行緒問題=> 正常Run 執行緒功能
        private delegate void UpdateUICallBack(string value, Control ctrl);

        private void UpdateUI(string value, Control ctrl)
        {
            if (this.InvokeRequired)
            {
                UpdateUICallBack UICal = new UpdateUICallBack(UpdateUI);
                this.Invoke(UICal, value, ctrl);
            }
            else
            {
                if(ctrl == this.richTxtRcv)
                    this.richTxtRcv.AppendText(value + "\n");                        
                else
                    ctrl.Text = value;
            }        
        }
        */
        #endregion

        
    }
}