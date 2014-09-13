using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationInterface
{
    public class CCBaseDispatcher
    {
        #region private fields
        protected delegate int CmdFuncDelegate(string szCmd);
        protected Dictionary<string, CmdFuncDelegate> m_FunctionDir = new Dictionary<string, CmdFuncDelegate>();
        protected CCStandardInterface m_Interface = null;
        #endregion

        #region Ctor
        public CCBaseDispatcher(CCStandardInterface p_Interface) 
        {
            m_Interface = p_Interface;
            initializeFuncDirectory();
        }
        #endregion

        #region Reimplemented Public Method

        /// <summary>
        /// �мg�C��J�A�����O�P�۹����禡�A�p�� Dispatcher�|�ھڪ��ӳ�_�A��a�禡�C
        /// </summary>
        protected virtual void initializeFuncDirectory()
        {
            
        }			

        /// <summary>
        /// �мg�C��S���۹������禡�i�H�Q��_�A�N�|�I�s�w�]��Handler
        /// </summary>
        /// <param name="szCmd"></param>
		protected virtual void DefaultCommandHandler(string szCmd)
		{		
		}

        /// <summary>
        /// �мg�C�H�ΨӳB�z ParserMessage �Ҳ��ͪ����~�A�p CRC, ��ƪ��סC        
        /// </summary>
        /// <param name="p_Error">���~��Error�T���A�q�`�HEnum�r��Ӫ��</param>
        public virtual void DealWithParserError(string p_Error)
        {

        }
                
        #endregion

        #region Public Method
        public void DispatchCommand(string szCommand, string szMessage)
        {
            if (m_FunctionDir.ContainsKey(szCommand))
            {
                CmdFuncDelegate func;
                m_FunctionDir.TryGetValue(szCommand, out func);
                func(szMessage);
            }
			else
			{
				DefaultCommandHandler(szCommand+szMessage);
			}
        }
        #endregion             
    }    
}
