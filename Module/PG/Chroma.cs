using System;
using System.Collections.Generic;
using System.Text;
using CommunicationInterface;
using System.Drawing;
using System.Windows.Forms;

namespace ContrelModule
{
    public class CChromaParser : CCBaseParser
    {
        #region Private Member
        private const int HEADER_LENGTH = 1;
        private const int RESPONSE_LENGTH = 1;
        private const int CHECKSUM_LENGTH = 2;
        private const int ENDER_LENGTH = 1;
        private const int SEPERATOR_LENGTH = 1;

        private enum ERROR_TYPE
        {
            No_error = '\x20',
            Unknown_error = '\x3F',
            Data_error = '\x3E',
            Checksum_error = '\x3D',
            Command_error = '\x3C',
            Other_error = '\x3B',
            Separator_error = '\x3A'

        };
        #endregion

        #region Ctor
        public CChromaParser()
            : base()
        {
        }
        #endregion

        #region Public Method
        private bool INeedComma(byte p_Byte)
        {
            if (p_Byte == (byte)':')
                return true;
            else
                return false;
        }

        public override void ParserMessage(string str)
        {
            byte[] byteString = Convert.FromBase64String(str);
            int iOffset = 0;

            // 1. Header
            iOffset += HEADER_LENGTH;

            // 2. Ression Code
            iOffset += 1;

            // 2. Command
            int iIdx = Array.FindIndex(byteString, INeedComma);
            if (iIdx > 1)
            {
                byte[] byteCommand = new byte[iIdx - 1];
                Array.Copy(byteString, iOffset, byteCommand, 0, byteCommand.Length);
                m_strCommand = System.Text.Encoding.ASCII.GetString(byteCommand);
                iOffset += byteCommand.Length;

                // 3. Separator
                iOffset += SEPERATOR_LENGTH;

                // 4. Data
                byte[] byteData = new byte[byteString.Length - iIdx - iOffset - CHECKSUM_LENGTH - ENDER_LENGTH];
                Array.Copy(byteString, iOffset, byteData, 0, byteData.Length);
                m_strMessage = System.Text.Encoding.ASCII.GetString(byteData);
            }
            else
            {
                byte[] byteCommand = new byte[byteString.Length - iOffset - CHECKSUM_LENGTH - ENDER_LENGTH];
                Array.Copy(byteString, iOffset, byteCommand, 0, byteCommand.Length);
                m_strCommand = System.Text.Encoding.ASCII.GetString(byteCommand);
                iOffset += byteCommand.Length;
            }
            

        }

        public override string EncodeMessage(string szCommand)
        {
            int iTotalLength = HEADER_LENGTH + szCommand.Length + CHECKSUM_LENGTH + ENDER_LENGTH;
            byte[] szSendString = new byte[iTotalLength];
            int iOffset = 0;

            // 1. Header
            szSendString[iOffset] = 0x02;
            iOffset += HEADER_LENGTH;

            // 2. Command + Separator + Data           
            byte[] byteCommand = System.Text.Encoding.Default.GetBytes(szCommand);  // 轉換 string 為 byte[]
            Array.Copy(byteCommand, 0, szSendString, iOffset, byteCommand.Length);
            iOffset += byteCommand.Length;

            // 3. Checksum
            string szChecksum = CaculateChecksum(szSendString);
            byte[] byteChecksum = System.Text.Encoding.Default.GetBytes(szChecksum); // 轉換 string 為 byte[]            
            Array.Copy(byteChecksum, 0, szSendString, iOffset, CHECKSUM_LENGTH);
            iOffset += CHECKSUM_LENGTH;

            // 6. Ender
            szSendString[iOffset] = 0x03;
            iOffset += ENDER_LENGTH;

            return Convert.ToBase64String(szSendString);

            /*string[] szSplitCommand = szCommand.Split(':');

            int iTotalLength = HEADER_LENGTH + szSplitCommand[0].Length + SEPERATOR_LENGTH + szSplitCommand[1].Length + CHECKSUM_LENGTH + ENDER_LENGTH;
            char[] szSendString = new char[iTotalLength];
            int iOffset = 0;

            // 1. Header
            szSendString[iOffset] = '\x02';
            iOffset += HEADER_LENGTH;

            // 2. Command
            szSplitCommand[0].CopyTo(0, szSendString, iOffset, szSplitCommand[0].Length);
            iOffset += szSplitCommand[0].Length;

            // 3. Separator
            szSendString[iOffset] = ':';
            iOffset += SEPERATOR_LENGTH;

            // 4. Data
            szSplitCommand[1].CopyTo(0, szSendString, iOffset, szSplitCommand[1].Length);
            iOffset += szSplitCommand[1].Length;

            //5. Checksum
            string szChecksum = CaculateChecksum(szSendString);
            szChecksum.ToUpper().CopyTo(0, szSendString, iOffset, CHECKSUM_LENGTH);
            iOffset += CHECKSUM_LENGTH;

            //6. Ender
            szSendString[iOffset] = '\x03';
            iOffset += ENDER_LENGTH;

            return new string(szSendString);*/
        }

        public override string SendMessageFormat(string p_sendMsg)
        {
            byte[] MsgByte = Convert.FromBase64String(p_sendMsg);

            string returnMsg = "";

            for (int i = 0; i < MsgByte.Length; i++)
            {
                returnMsg += ((char)MsgByte[i]).ToString();
            }

            return "[Send]:" + returnMsg;
        }

        public override string ReceiveMessageFormat()
        {
            /*byte[] MsgByte = Convert.FromBase64String(m_strCommand);
            string returnMsg = "";

            for (int i = 0; i < MsgByte.Length; i++)
            {
                returnMsg += ((char)MsgByte[i]).ToString();
            }*/

            return "[Receive]:" + m_strCommand + " " + m_strMessage;
        }

        #endregion

        #region Private Method
        private string CaculateChecksum(byte[] str)
        {
            uint iChecksum = 0;

            for (int iIdx = HEADER_LENGTH; iIdx < str.Length; ++iIdx)
            {
                iChecksum += str[iIdx];
            }

            string tmp = Convert.ToString(iChecksum, 16);
            string tmp1 = tmp.Substring(tmp.Length - 2, 2);
            int ch = 256 - Convert.ToUInt16(tmp1, 16);

            return Convert.ToString(ch, 16);
        }
        private bool CompareChecksum(string checksum1, string checksum2)
        {
            return (checksum1.CompareTo(checksum2) == 0) ? true : false;
        }

        #endregion


    }
    public class CChromaDispatcher : CCBaseDispatcher
    {
        private string m_szPrevColor = "";
        private string m_szNowColor = "";
        private PatternGenerator m_UI = null;

        #region Ctor
        public CChromaDispatcher(CCStandardInterface p_Interface)
            : base(p_Interface)
        {
        }
        #endregion

        #region Protected Method
        protected override void initializeFuncDirectory()
        {
            m_FunctionDir.Add("StartTestingLROK", new CmdFuncDelegate(this.StartTestingLR));
            m_FunctionDir.Add("DefectDataLR", new CmdFuncDelegate(this.DefectDataLR));
            m_FunctionDir.Add("OnContactOK", new CmdFuncDelegate(this.OnContact));
            m_FunctionDir.Add("PanelUnloadOK", new CmdFuncDelegate(this.PanelUnload));
            m_FunctionDir.Add("Array_CF_Data", new CmdFuncDelegate(this.Array_CF_Data));
            m_FunctionDir.Add("OnLineOK", new CmdFuncDelegate(this.OnLineOK));
            m_FunctionDir.Add("Signal Is On", new CmdFuncDelegate(this.SignalIsOn));
        }

        protected override void DefaultCommandHandler(string p_strCommand)
        {
            if (Enum.IsDefined(typeof(KnownColor), p_strCommand))
            {
                if (m_UI != null)
                {
                    m_UI.PreviousColorTextBox.Invoke(new TextDelegate(textDelegate), m_UI.PreviousColorTextBox, m_UI.NowColorTextBox.Text);
                    m_UI.NowColorTextBox.Invoke(new TextDelegate(textDelegate), m_UI.NowColorTextBox, p_strCommand);
                }
            }
        }
        #endregion

        #region Private Method
        private int OnLineOK(string szCmd)
        {
            return 0;
        }

        private int SignalIsOn(string szCmd)
        {
            m_UI.LightOnRadioButton.Invoke(new BoolDelegate(boolDelegate), m_UI.LightOnRadioButton, true);
            m_UI.LightOffRadioButton.Invoke(new BoolDelegate(boolDelegate), m_UI.LightOffRadioButton, false);
            return 0;
        }

        private int DefectDataLR(string szCmd)
        {
            //string[] aszDe
            m_Interface.ReplyMessage("DefectDataLROK:OK");
            return 0;
        }
        
        private int OnContact(string szCmd)
        {
            m_UI.LightOnRadioButton.Invoke(new BoolDelegate(boolDelegate), m_UI.LightOnRadioButton, true);
            m_UI.LightOffRadioButton.Invoke(new BoolDelegate(boolDelegate), m_UI.LightOffRadioButton, false);
            return 0;
        }
        
        private int StartTestingLR(string szCmd)
        {
            m_UI.TestCheckBox.Invoke(new BoolDelegate(boolDelegate), m_UI.TestCheckBox, true);
            return 0;
        }

        private int PanelUnload(string szCmd)
        {
            m_UI.LightOnRadioButton.Invoke(new BoolDelegate(boolDelegate), m_UI.LightOnRadioButton, false);
            m_UI.LightOffRadioButton.Invoke(new BoolDelegate(boolDelegate), m_UI.LightOffRadioButton, true);
            return 0;
        }

        private int Array_CF_Data(string szCmd)
        {

            return 0;
        }

        private delegate void BoolDelegate(Control p_objBoolControl, bool p_bValue);
        private delegate void TextDelegate(TextBox p_objTextbox, string p_strCommand);
        private void textDelegate(TextBox p_objTextbox, string p_strCommand)
        {
            p_objTextbox.Text = p_strCommand;
        }
        private void boolDelegate(Control p_objBoolControl, bool p_bValue)
        {
            if (p_objBoolControl is RadioButton)
            {
                ((RadioButton)p_objBoolControl).Checked = p_bValue;
            }
            else if (p_objBoolControl is CheckBox)
            {
                ((CheckBox)p_objBoolControl).Checked = p_bValue;
            }
        }
        #endregion

        public PatternGenerator UI
        {
            set { m_UI = value; }
        }
    }



    public class ChromaStartTestingData
    {
        public const string szTitle = "L";

        public string szGlassID = "";
        public string szPPID = "";
        public string szPortNo = "";
        public string szCSTID = "";
        public string szRecipeID = "";
        public string szBatchID = "";
        public string szBatchType = "";
        public string szSlotNo = "";
        public string szLotID = "";
        public string szLotType = "";
        public string szProdID = "";
        public string szPlanID = "";
        public string szStepID = "";
        public string szStepNo = "";
        public string szModelName = "";
        public string szVCRFlag = "";
        public string szARYGlassID = "";
        public string szCFGlassID = "";
        public string szAbnormalFlag = "";
        public string szFinalJudge = "";
        public string szGrade = "";
        public string szGradeCode = "";
        public string szCellRepCount = "";
        public string szCelTrimCount = "";
        public string szParCount = "";
        public string szESDValue = "";
        public string szLonizerStatus = "";
        public string szMainEQID = "";
        public string szEQID = "";
        public string szEQRecipeNo = "";
        public string szEQRecipe = "";

        public string GetFullString()
        {
            return szTitle + "," +
                    szGlassID + "," +
                    szPPID + "," +
                    szPortNo + "," +
                    szCSTID + "," +
                    szRecipeID + "," +
                    szBatchID + "," +
                    szBatchType + "," +
                    szSlotNo + "," +
                    szLotID + "," +
                    szLotType + "," +
                    szProdID + "," +
                    szPlanID + "," +
                    szStepID + "," +
                    szStepNo + "," +
                    szModelName + "," +
                    szVCRFlag + "," +
                    szARYGlassID + "," +
                    szCFGlassID + "," +
                    szAbnormalFlag + "," +
                    szFinalJudge + "," +
                    szGrade + "," +
                    szGradeCode + "," +
                    szCellRepCount + "," +
                    szCelTrimCount + "," +
                    szParCount + "," +
                    szESDValue + "," +
                    szLonizerStatus + "," +
                    szMainEQID + "," +
                    szEQID + "," +
                    szEQRecipeNo + "," +
                    szEQRecipe;
        }
    }

    public class ChromaEndTestingData
    {
        public string szTAID = "";
        public string szTAShift = "";
        public string szStartTime = "";
        public string szPreEndTime = "";
        public string szEndTime = "";
        public string szLRFlag = "";
        public string szCollectFlag = "";
        public string szLRShootCount = "";
        public string szMaxPower = "";
        public string szMinPower = "";
        public string szAvfPower = "";
        public string szStdPower = "";
        public string szLRWorkCount = "";

    }

    public class ArrayCFData
    {
        public string szPanelID = "";
        public string szData = "";
        public string szGate = "";
        public string szDEFCode = "";
        public string szReason = "";
        public string szCellFlag = "";
        public string szDEFJudge = "";
        public string szResult = "";
    }

    public class ChromaSubDefectData
    {
        public int iSourceNo = 0;
        public int iGateNo = 0;

        public string szCTDFCode = "";
        public string szCTDFGrade = "";
        public string szCTDFType = "";

        public string szColor = "";

        public string szLRMethod = "";
        public string szLRDFCode = "";
        public string szLRDFName = "";
        public string szLRJudgeCode = "";

        public string szRepairSuccess = "";
        public string szImageFileName = "";
        public string szImageCount = "";
    }

    public class ChromaDefectDataInfo
    {
        public int iDefectCount = 0;
        public string szStep = "";
        public string szADD_DEL = "";

        public Dictionary<int, ChromaSubDefectData> objDefectDataInfo = new Dictionary<int, ChromaSubDefectData>();
    }
}
