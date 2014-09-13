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
        //�e�T���m���x
        public int SendCmdToModule(string szCmd)
        {
            string szSendTemp;
            int iSum = 0;
            /*
            //Queue Process =>�����B�z�̷s��
            if (pArrayListQueue.Count > 0)
            {
                ProcessComData((string)pArrayListQueue[pArrayListQueue.Count - 1]);
                pArrayListQueue.Clear();
            }
            */
            //��´�o�e�R�O Send Cmd To Module
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
        //�����T��
        public void RS232Comm_OnComm()
        {
            //�ˬd�w�İ��جO�_����ơA�Y����ƱN��ƶǵ�ProcessComData�B�z�A��M�z�]�i�H�����b
            //�o�Ө禡���B�z�A�b���ڭ̱N�����r�ꪺ�覡�B�z(string)�A�Y�O��L����ơA�h�ରbyte�x�}(byte [])�C                      
           //while (1)
           {
                if (this.RS232Comm.BytesToRead > 0)
                {
                    string data = RS232Comm.ReadExisting();

                    //��k1.�]���|�X�{���������D��JQueue
                    //pArrayListQueue.Add(data);

                    //��k2.�]���|�X�{���������D�ҥH�[�J����
                    //ProcessComData(data); 

                    //��k3.�������B�z���,�~�i�H�����T��
                    int iDisVal = System.Int32.Parse(data.Substring(27, 8),
                                  System.Globalization.NumberStyles.AllowHexSpecifier);

                    this.bProcessMsgFlag = 0;
                }
           }
        }

        #region �Ȯɤ���
        /*
        private void ProcessComData(string input)
        {
            int iDisVal = System.Int32.Parse(input.Substring(27, 8),
                          System.Globalization.NumberStyles.AllowHexSpecifier);

            //��k1.�]���|�X�{���������D��JQueue
            //this.richTxtRcv.AppendText(input + "\n");
            //this.txtDist.Text = Convert.ToString((float)iDisVal / 1000000);        
           
            //��k2.�]���|�X�{���������D�ҥH�[�J����            
            //UpdateUI(input, this.richTxtRcv);
            //UpdateUI(Convert.ToString((float)iDisVal / 1000000), this.txtDist);                      
        }  
               
        private void btnSend_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }

        
        //�H�קK���������D=> ���`Run ������\��
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