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
        /// 覆寫。填入適當的指令與相對應函式，如此 Dispatcher會根據表格來喚起適當地函式。
        /// </summary>
        protected virtual void initializeFuncDirectory()
        {
            
        }			

        /// <summary>
        /// 覆寫。當沒有相對應的函式可以被喚起，就會呼叫預設的Handler
        /// </summary>
        /// <param name="szCmd"></param>
		protected virtual void DefaultCommandHandler(string szCmd)
		{		
		}

        /// <summary>
        /// 覆寫。以用來處理 ParserMessage 所產生的錯誤，如 CRC, 資料長度。        
        /// </summary>
        /// <param name="p_Error">錯誤的Error訊息，通常以Enum字串來表示</param>
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
