using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SDDEMsg;

namespace DearError
{
    public class DearErrorCode 
    {
        //20090318 �ө�~~�ŧi�@��Timer
        private System.Windows.Forms.Timer TKMSGTIMER;
        //20090323 �ө�~~new�XDearError_Def����
        Common.DearError_Def InitDearErrorCode = new Common.DearError_Def();

        public DearErrorCode()
        {
           
        }

        //20090323 �ө�~~�Ұ�Timer���غc�l
        public DearErrorCode(bool StartTimer)
        {
            //20090318 �ө�~~new�XTimer
            this.TKMSGTIMER = new Timer();
            this.TKMSGTIMER.Enabled = true;
            this.TKMSGTIMER.Interval = 500;
            this.TKMSGTIMER.Tick += new System.EventHandler(this.TKMSGTIMER_Tick);
        }

        //20090318 �ө�~~Ĳ�oTimer
        private void TKMSGTIMER_Tick(object sender, EventArgs e)
        {
            int iSDDEStatus = 0;

            //20090318 �ө�~~���oMMI�MTK���s�u���A
            iSDDEStatus = SDDE.GetSingleton().GetSDDEStatus();

            if (iSDDEStatus != 1)
            {
                //20090318 �ө�~~MMI�MTK�s�u
                SDDE.GetSingleton().Connect();
            }

            //20090318 �ө�~~�Ψӱ���TK�ǹL�Ӫ�Message
            StringBuilder szReturnChar = new StringBuilder();

            while (SDDE.GetSingleton().GetMessageFromTK(szReturnChar) == 0)
            {

                if (szReturnChar[0] == 'A' && szReturnChar[1] == '0' && szReturnChar[2] == '2' && szReturnChar[3] == '3')
                {
                    //�oAlarm Message
                    Common.GlobalValue.AlarmQueue.Enqueue(szReturnChar.ToString());
                }
                else if (szReturnChar[0] == 'R' || szReturnChar[0] == 'E' || szReturnChar[0] == 'A' || szReturnChar[0] == 'X')
                {
                    //20090323 �ө�~~�I�s���DearErrorCode���禡
                    InitDearErrorCode.strcmpDearErrorCode(szReturnChar);
                }
                else
                {
                    //�oAlarm Message
                    Common.GlobalValue.AlarmQueue.Enqueue(szReturnChar.ToString());
                }
            }

        }

        // =====================================================================
        //      R100    ����B½�� ��l��Home
        // =====================================================================
        public int Rtn_AllMotorHome(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }
            
            return 0;
        }

        // =====================================================================
        //      R101    ���Y�����b����
        // =====================================================================
        public int Rtn_CCDAxleChangeMove(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R201    �۰ʤJ��
        // =====================================================================
        public int Rtn_AutoLoad(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R202    �۰ʥX��
        // =====================================================================
        public int Rtn_AutoUnload(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R203    �W�b���J�Ƭy�{
        // =====================================================================
        public int Rtn_UpperLoadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R204    �W�b���X�Ƭy�{
        // =====================================================================
        public int Rtn_UpperUnloadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R205    �U�b���J�Ƭy�{
        // =====================================================================
        public int Rtn_BottomLoadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R206    �̫�@���X�Ƭy�{
        // =====================================================================
        public int Rtn_LastUnloadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R300    ���x�X�l�Ƭy�{
        // =====================================================================
        public int Rtn_StageInitProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R301    ���x�۰ʤJ�Ƭy�{
        // =====================================================================
        public int Rtn_StageAutoLoadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R302    ���x�۰ʥX�Ƭy�{
        // =====================================================================
        public int Rtn_StageAutoUnloadProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R303    ���x�w���y�{
        // =====================================================================
        public int Rtn_StageBeforehandClipProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R304    �p�g�׸ɬy�{
        // =====================================================================
        public int Rtn_LaserRepairProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R305    �I�O�y�{
        // =====================================================================
        public int Rtn_LampProcess(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R401    S&G&L ����
        // =====================================================================
        public int Rtn_SGL_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R402    QS1&QG1 ����
        // =====================================================================
        public int Rtn_QS1QG1_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R403    QS2&QG2 ����
        // =====================================================================
        public int Rtn_QS2QG2_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R404    QS3&QG3 ����
        // =====================================================================
        public int Rtn_QS3QG3_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }


        // =====================================================================
        //      R405    QS4&QG4 ����
        // =====================================================================
        public int Rtn_QS4QG4_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R406    QS5&QG5 ����
        // =====================================================================
        public int Rtn_QS5QG5_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R407    QS6&QG6 ����
        // =====================================================================
        public int Rtn_QS6QG6_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R408    QS7&QG7 ����
        // =====================================================================
        public int Rtn_QS7QG7_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R409    B1&B2 ����
        // =====================================================================
        public int Rtn_B1B2_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R410    C1C2 ����
        // =====================================================================
        public int Rtn_C1C2_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R411    TS&TG ����
        // =====================================================================
        public int Rtn_TSTG_Move(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R501    S&G&L Box Control
        // =====================================================================
        public int Rtn_SGL_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R502    QS1&QG1 Box Control
        // =====================================================================
        public int Rtn_QS1QG1_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R503    QS2&QG2 Box Control
        // =====================================================================
        public int Rtn_QS2QG2_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R504    QS3&QG3 Box Control
        // =====================================================================
        public int Rtn_QS3QG3_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R505    QS4&QG4 Box Control
        // =====================================================================
        public int Rtn_QS4QG4_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R506    QS5&QG5 Box Control
        // =====================================================================
        public int Rtn_QS5QG5_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R507    QS6&QG6 Box Control
        // =====================================================================
        public int Rtn_QS6QG6_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R508    QS7&QG7 Box Control
        // =====================================================================
        public int Rtn_QS7QG7_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R509    C1C2 Box Control
        // =====================================================================
        public int Rtn_C1C2_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      R510    TS&TG Box Control
        // =====================================================================
        public int Rtn_TSTG_Box_Control(string l_szTempChar)
        {
            string[] iKey;
            iKey = l_szTempChar.Split(',');

            try
            {
                //20090325 �ө�~~�ѼƬ��r��,�ϥήɶ��૬
                switch (int.Parse(iKey[1]))
                {
                    case 0:

                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("����");
            }

            return 0;
        }

        // =====================================================================
        //      Not Define Code
        // =====================================================================
        public int Rtn_NotDefineCode(string l_szTempChar)
        {

            Common.GlobalValue.AlarmQueue.Enqueue(l_szTempChar);

            return 0;
        }
    }
}