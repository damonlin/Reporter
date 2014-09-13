using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationInterface
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
        public override void ParserMessage(string str)
        {
            char[] szCommand = new char[str.Length];
            int iOffset = 0;
            string[] szSplitCommand = str.Split(':');

            // 1. Header
            szCommand[iOffset] = '\x02';
            iOffset += HEADER_LENGTH;

            // 2. Command
            m_strCommand = szSplitCommand[0].Substring(HEADER_LENGTH);
            m_strCommand.CopyTo(0, szCommand, iOffset, m_strCommand.Length);
            iOffset += m_strCommand.Length;

            // 3. Separator
            szCommand[iOffset] = ':';
            iOffset += SEPERATOR_LENGTH;

            // 4. Data
            int strlen = szSplitCommand[1].Length;
            m_strMessage = szSplitCommand[1].Substring(0, strlen - CHECKSUM_LENGTH - ENDER_LENGTH);
            m_strMessage.CopyTo(0, szCommand, iOffset, m_strMessage.Length);

            //5. Checksum
            string szChecksum = szSplitCommand[1].Substring(m_strMessage.Length, CHECKSUM_LENGTH);

			// 如果比對CheckSum失敗，就丟出Exception            
			if( !CompareChecksum(szChecksum, CaculateChecksum(szCommand)))
			{
				throw new Exception(ERROR_TYPE.Checksum_error.ToString());
			}
        }

        public override string EncodeMessage(string szCommand)
        {
            string[] szSplitCommand = szCommand.Split(':');

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

            return new string(szSendString);
        }
		
		public override void DealWithParserError(string p_Error)
        {
			ERROR_TYPE parserError = (ERROR_TYPE)Enum.Parse(typeof(ERROR_TYPE), p_Error);

            switch (parserError)
            {
                case ERROR_TYPE.Checksum_error:
                    break;
			}
        }
		
        #endregion

        #region Private Method
        private string CaculateChecksum(char[] str)
        {
            uint iChecksum = 0;

            for (int iIdx = HEADER_LENGTH; iIdx < str.Length; ++iIdx)
            {
                iChecksum += str[iIdx];
            }

            string tmp = Convert.ToString(iChecksum, 16);
            string tmp1 = tmp.Substring(tmp.Length - 2);
            int ch = 256 - Convert.ToUInt16(tmp1, 16);

            return Convert.ToString(ch, 16);
        }
        private bool CompareChecksum(string checksum1, string checksum2)
        {
            return ( checksum1.CompareTo(checksum2) == 0 ) ? true : false;
        }

        #endregion


    }
    public class CChromaDispatcher : CCBaseDispatcher
    {
        #region Ctor
        public CChromaDispatcher(CCStandardInterface p_Interface)
            : base(p_Interface)
        {
        }
        #endregion

        #region Protected Method
        protected override void initializeFuncDirectory()
        {
            m_FunctionDir.Add("DefectDataLR", new CmdFuncDelegate(this.DefectDataLR));
        }
		
		// 如果沒有相對應的指令，在這裡處理
		protected override void DefaultCommandHandler(string szCmd)
		{
			// DO Default things here !!
		}
        #endregion

        #region Private Method        
        private int DefectDataLR(string szCmd)
        {
            m_Interface.ReplyMessage("DefectDataLROK:OK");
            return 0;
        }
        #endregion
    }
}
