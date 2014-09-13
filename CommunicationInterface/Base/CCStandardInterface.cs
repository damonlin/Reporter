using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace CommunicationInterface
{    
    public sealed class CCStandardInterface
    {
        #region private fields
        private Queue<MSG> m_RcvQueue = new Queue<MSG>();
        private Queue<MSG> m_SndQueue = new Queue<MSG>();
        private uint m_iRetry = 3;

        // Protocol
        private CCBaseProtocol m_Protocol = null;

        // Thread
        private object m_SendLockSyncObj = new object();
        private object m_RcvLockSyncObj = new object();
        private Thread m_SendThread = null;
        private Thread m_RcvThread = null;

        // volatile 關鍵字會警示多執行緒將存取 m_bProcessingDone 資料成員的編譯器，因此對於此成員的狀態不應做出最佳化假設
        // 因為 m_bProcessingDone 用在主 Thread 和 Thread, 因此使用關鍵字 volatile
        private volatile bool m_bProcessing = false; 

        // This is a Command Parser, which can be replaced wth whatever you want to parse the string.
        // Of course, you need to subclass CCBaseParser !! 
        private CCBaseParser m_Parser = null;

        // This is Command Dispatcher. Once you've received a message and parsed it
        // we'll dispach it to associated function
        private CCBaseDispatcher m_Dispatcher = null;

        // Timeout Object
        private CCTimeOutEvent m_TimeoutEvent = new CCTimeOutEvent(3000);

        // Update UI
        public delegate void UpdateTextCallback(string text);
        private RichTextBox m_UI = null;

        // Message Type
        private enum MSGType { SEND_TYPE, REPLYE_TYPE, RECEIVE_TYPE};
        private struct MSG
        {
            public string _Message;
            public MSGType _Type;
        }
        
        #endregion

        #region properties

        // Protocol
        public CCBaseProtocol Protocol
        {
            get { return m_Protocol; }
            set 
            {
                m_Protocol = value;

                // Install Handler
                m_Protocol.DataReceiveHandler = this.DataReceived;
                m_Protocol.ConnectHandler = this.ConnectReceived;
                m_Protocol.DisconnectHandler = this.DisonnectReceived;

                /*
                 * 對於 RS232 來講，直接有PortDataReceived可以用，因此也要順便設置。
                 */
                //if( m_Protocol.Type == CCBaseProtocol.PrototcolType.RS232_TYPE )
                //    (m_Protocol as CCRS232Protocol).PortDataReceived = this.DataReceived;              
            } 
        }
         
        /// <summary>
        /// Parser
        /// </summary>
        public CCBaseParser Parser
        {
            set { m_Parser = value; }
        }
         
        /// <summary>
        /// Dispatcher 
        /// </summary>
        public CCBaseDispatcher Dispatcher
        {
            set { m_Dispatcher = value; }
            get { return m_Dispatcher; }
        }
        
        /// <summary>
        /// Retry
        /// </summary>
        public uint Retry
        {
            get { return m_iRetry; }
            set { m_iRetry = value; }            
        }
         
        /// <summary>
        /// Enable Retry
        /// </summary>
        public bool EnableRetry
        {
            get { return (m_iRetry > 0 ) ? true: false; }
            set 
            {
                if (false == value)
                    m_iRetry = 0; 
            }
        }           

        /// <summary>
        /// Rich textbox to show message
        /// </summary>
        public RichTextBox TextUI
        {
            set { m_UI = value; }
        }

        #endregion

        #region Ctor

        public CCStandardInterface()
        {            
            // Setup Default Protocol
            m_Protocol = new CCBaseProtocol();

            // Setup Default Dispatcher
            m_Dispatcher = new CCBaseDispatcher( this ) ;

            // Setup Default Parser
            m_Parser = new CCBaseParser();            
        }       
        #endregion

        #region Public Method
        // Create Method
        public bool Create()
        {
            m_Protocol.Create();
            return true;
        }

        // Destroy Method
        public void Destroy()
        {
            m_Protocol.Destroy();         
        }

        // Send Method
        public void SendMessage(string szMessage)
        {
            lock (m_SendLockSyncObj)
            {
                MSG msg = new MSG();
                msg._Message = szMessage;
                msg._Type = MSGType.SEND_TYPE;                
                m_SndQueue.Enqueue(msg);
            }
        }

        // Reply Method 
        public void ReplyMessage(string szMessage)
        {
            lock (m_SendLockSyncObj)
            {
                MSG msg = new MSG();
                msg._Message = szMessage;
                msg._Type = MSGType.REPLYE_TYPE;
                m_SndQueue.Enqueue(msg);
            }
        }

        // Receive Method
        /*public string ReceiveMessage()
        {
            //base.Receive();
            return null;
        }*/

        // Process Send Message -- Thread
        private void ProcessSendMessage()
        {
            while (m_bProcessing)
            {
                Thread.Sleep(100);

                lock (m_SendLockSyncObj)
                {
                    uint iRetryCount = 0;

                    if (m_SndQueue.Count == 0)
                        continue;

                    if (m_SndQueue.Peek()._Type != MSGType.SEND_TYPE)
                    {                        
                        m_Protocol.Send(m_Parser.EncodeMessage(m_SndQueue.Peek()._Message));
						// Update UI
					    if (m_UI != null)
						    m_UI.Invoke(new UpdateTextCallback(this.UpdateText),
                                                  m_Parser.SendMessageFormat(m_Parser.EncodeMessage(m_SndQueue.Peek()._Message)));
								
                        m_SndQueue.Dequeue(); // remove message
                    }
                    else
                    {
                        if (EnableRetry == false )
                        {                            
                            m_Protocol.Send(m_Parser.EncodeMessage(m_SndQueue.Peek()._Message));
							// Update UI
							if (m_UI != null)
                                m_UI.Invoke(new UpdateTextCallback(this.UpdateText), 
                                                      m_Parser.SendMessageFormat(m_Parser.EncodeMessage(m_SndQueue.Peek()._Message)));
								//m_UI.Invoke(new UpdateTextCallback(this.UpdateText), m_SndQueue.Peek()._Message);

								
                            m_SndQueue.Dequeue(); // remove message
                            continue;
                        }

                        while (iRetryCount <= m_iRetry)
                        {                            
                            m_Protocol.Send(m_Parser.EncodeMessage(m_SndQueue.Peek()._Message));

							// Update UI
							if (m_UI != null)
								m_UI.Invoke(new UpdateTextCallback(this.UpdateText), m_SndQueue.Peek()._Message);
							
                            if (!m_TimeoutEvent.StarTimeout())
                            {
                                iRetryCount++; // Timeout Occurred !!
                            }
                            else
                            {
                                m_SndQueue.Dequeue(); // remove message
                                break;
                            }
                        }
                        if (iRetryCount > m_iRetry) // Retry end
                        {
                            m_SndQueue.Dequeue(); // remove message
                            MessageBox.Show("Server Timeout !!");
                        }
                    }
                }
            }
        }

        // Process Receive Message -- Thread
        private void ProcessRcvMessage()
        {
            while (m_bProcessing)
            {
                Thread.Sleep(100); 

                lock (m_RcvLockSyncObj)
                {
                    if (m_RcvQueue.Count > 0)
                    {
						// Damon Add 20100614, 新增 Parser處理異常的流程
						try
						{
							// Step 1. Parse Message
							m_Parser.ParserMessage(m_RcvQueue.Dequeue()._Message);

							// Step 2. Invoke proper function
							m_Dispatcher.DispatchCommand(m_Parser.Command, m_Parser.Message);

							// Stop Timeout as soon as receiving one command
							if (EnableRetry == true )
								m_TimeoutEvent.StopTimeout();
						}
						catch(Exception ex)
						{
                            m_Dispatcher.DealWithParserError(ex.Message);
						}                        
                        finally
                        {
                            // Update UI
                            if (m_UI != null)
                                m_UI.Invoke(new UpdateTextCallback(this.UpdateText), m_Parser.ReceiveMessageFormat());
                        }
                    }
                }                
            }
        }
        #endregion

        #region Private Method
        // Event when signal is received on COM port data pins.
        private void DataReceived(object sender, EventArgs e)
        {
            lock (m_RcvLockSyncObj)
            {                
                MSG msg = new MSG();
                msg._Message = m_Protocol.Receive();
                msg._Type = MSGType.RECEIVE_TYPE;

                m_RcvQueue.Enqueue(msg);
            }
        }

        private void ConnectReceived(Object sender, EventArgs e)
        {
            // There'll be N client reqesting connect,
            // but we just need to create threads of send and receive
            if (m_bProcessing == true)
                return;

            m_bProcessing = true;

            m_SendThread = new Thread(new ThreadStart(this.ProcessSendMessage));
            if (!m_SendThread.IsAlive)
                m_SendThread.Start();

            m_RcvThread = new Thread(new ThreadStart(this.ProcessRcvMessage));
            if (!m_RcvThread.IsAlive)
                m_RcvThread.Start();            
        }

        private void DisonnectReceived(Object sender, EventArgs e)
        {            
            m_bProcessing = false;

            if (m_SendThread != null)
                m_SendThread.Abort();

            if (m_RcvThread != null)
                m_RcvThread.Abort();        
        }

        // Updates the textbox text.
        private void UpdateText(string text)
        {
            // Set the textbox text.
            m_UI.AppendText(text);
            m_UI.AppendText("\r\n");
        }
        #endregion
    }

   
}
