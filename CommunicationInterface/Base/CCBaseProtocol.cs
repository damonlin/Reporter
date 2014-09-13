using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace CommunicationInterface
{
    public class CCBaseProtocol
    {
        #region Public  fields
        public enum PrototcolType{ NORMAL_TYPE, RS232_TYPE, TCPIP_TYPE, HSMS_TYPE };                
        #endregion

        #region Protected fields
        protected PrototcolType m_Type;
        protected SerialDataReceivedEventHandler m_DataReceiveHandler = null;
        protected EventHandler m_ConnectHandler = null;
        protected EventHandler m_DisconnectHandler = null;
        #endregion

        #region Property
        // Type
        public PrototcolType Type
        {
            get { return m_Type; }            
        }

        // Data Receive Callback
        public virtual SerialDataReceivedEventHandler DataReceiveHandler
        {
            set { m_DataReceiveHandler = value; }
        }

        // Connect Callback
        public virtual EventHandler ConnectHandler
        {
            set { m_ConnectHandler = value; }
        }

        // Disconnect Callback
        public virtual EventHandler DisconnectHandler
        {
            set { m_DisconnectHandler = value; }
        }

        #endregion

        #region Ctor

        public CCBaseProtocol()
        {
            m_Type = PrototcolType.NORMAL_TYPE;
        }

        public CCBaseProtocol( PrototcolType p_Type) 
        {
            m_Type = p_Type; 
        }
        #endregion

        #region Reimplemented Public Method
        public virtual bool Create() { return true; }
        public virtual bool Destroy() { return true; }
        public virtual void Send(string p_szMsg) { }        
        public virtual string Receive() { return null; }
        #endregion
    }   
}
