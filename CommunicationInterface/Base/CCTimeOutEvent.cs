using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CommunicationInterface
{
    public class CCTimeOutEvent
    {
        #region private fields
        private ManualResetEvent m_TimeOutEvent = null;
        private int m_iTimeOutSecs = 0;
        #endregion

        #region Property
        public int TimeOutSecs
        {
            get { return m_iTimeOutSecs; }
            set { m_iTimeOutSecs = value;}            
        }
        #endregion

        #region Ctor
        public CCTimeOutEvent(int iSecs)
        {
            m_TimeOutEvent = new ManualResetEvent(false);
            m_iTimeOutSecs = iSecs;
        }
        #endregion

        #region Public Method

       /// <summary>
        /// 開始啟動Timeout,回傳false代表Timeout發生
       /// </summary>       
        public bool StarTimeout()
        {
            m_TimeOutEvent.Reset();
            return m_TimeOutEvent.WaitOne(m_iTimeOutSecs, false);            
        }
        public void StopTimeout()               
        {
            m_TimeOutEvent.Set();
        }

        public bool IsSetTimeout()
        {
            return (m_iTimeOutSecs > 0 ) ? true : false;
        }
        #endregion
    }
}
