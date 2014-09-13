using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CommunicationInterface
{   
    /// <summary>
    /// This is Base Command Paser Class. Provide simple Parser function.
    /// </summary>
    public class CCBaseParser
    {
        #region private fields
        protected string m_strCommand;
        protected string m_strMessage;
        #endregion

        #region properties

        // Command
        public string Command
        {
            get { return m_strCommand; }
        }
        // Message
        public string Message
        {
            get { return m_strMessage; }
        }
        #endregion 

        #region Reimplemented Public Method
		
		/// <summary>
        /// 覆寫。用來將接收到的資料，經過特定的資料格式，來作解碼動作。   
        /// </summary>
        /// <param name="str">欲解碼的字串</param>
        public virtual void ParserMessage(string str)
        {
            m_strCommand = str;
            m_strMessage = str;
        }

		/// <summary>
        /// 覆寫。用來將資料，經過特定的資料格式，來作編碼動作。
        /// </summary>
        /// <param name="szCommand">未編碼字串</param>
        /// <returns>編完碼後的字串</returns>
        public virtual string EncodeMessage(string szCommand)
        {
            return szCommand;
        }

        /// <summary>
        /// 覆寫。自行定義要顯示的接收字串格式。預設為： [Command]Data。
        /// </summary>
        /// <returns></returns>
        public virtual string SendMessageFormat(string p_sendMsg)
        {
            return "[Send]: " + p_sendMsg;
        }
				
        /// <summary>
        /// 覆寫。自行定義要顯示的接收字串格式。預設為： [Command]Data。
        /// </summary>
        /// <returns></returns>
        public virtual string ReceiveMessageFormat()
        {
            return "[" + m_strCommand + "]" + m_strMessage;
        }

        #endregion
    }
}
