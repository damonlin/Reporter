using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.IO.Ports;

namespace RS232Communication
{
    class RS232
    {
        const int _DEFAULT_INPUT_QUEUE_SIZE_ = 1024;
        
        private static RS232 Signleton;
        public static RS232 GetSignleton()
        {
            if (Signleton == null)
                Signleton = new RS232();
            return Signleton;
        }

        //��l��
        public int CreateRS232Interface(ref SerialPort RS232Comm)
        {
            //timer1 = new Timer();
           
            // �ˬd�@�UCom1�O�_�Q�ϥΤF�A�Y�Q�ϥΤF�A��Com1�����í��].
            if (RS232Comm.IsOpen == true)
                RS232Comm.Close();

            try
            {
                RS232Comm.Open();
                //this.timer1.Enabled = true;
            }
            catch (Exception ex1)
            {
                return -1;
                //txtSend.Text = "Open Faile!";
            }

            return 0;
        }

        public int DestroyRS232Interface(ref SerialPort RS232Comm)
        {
            RS232Comm.Close();
            return 0;
        }
    }

}
