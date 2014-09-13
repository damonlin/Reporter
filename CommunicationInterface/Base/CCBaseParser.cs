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
        /// �мg�C�ΨӱN�����쪺��ơA�g�L�S�w����Ʈ榡�A�ӧ@�ѽX�ʧ@�C   
        /// </summary>
        /// <param name="str">���ѽX���r��</param>
        public virtual void ParserMessage(string str)
        {
            m_strCommand = str;
            m_strMessage = str;
        }

		/// <summary>
        /// �мg�C�ΨӱN��ơA�g�L�S�w����Ʈ榡�A�ӧ@�s�X�ʧ@�C
        /// </summary>
        /// <param name="szCommand">���s�X�r��</param>
        /// <returns>�s���X�᪺�r��</returns>
        public virtual string EncodeMessage(string szCommand)
        {
            return szCommand;
        }

        /// <summary>
        /// �мg�C�ۦ�w�q�n��ܪ������r��榡�C�w�]���G [Command]Data�C
        /// </summary>
        /// <returns></returns>
        public virtual string SendMessageFormat(string p_sendMsg)
        {
            return "[Send]: " + p_sendMsg;
        }
				
        /// <summary>
        /// �мg�C�ۦ�w�q�n��ܪ������r��榡�C�w�]���G [Command]Data�C
        /// </summary>
        /// <returns></returns>
        public virtual string ReceiveMessageFormat()
        {
            return "[" + m_strCommand + "]" + m_strMessage;
        }

        #endregion
    }
}
