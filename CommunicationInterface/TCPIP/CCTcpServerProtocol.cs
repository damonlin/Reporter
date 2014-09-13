using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.Net;   // Endpoint
using System.Threading;

namespace CommunicationInterface
{    
    public class CCTcpServerProtocol : CCBaseProtocol
    {
        #region Private Member
        private int m_iListenPort = 0;
        private List<ConnectedClient> m_listClient = new List<ConnectedClient>();
        private bool m_bBroadcast = false;
        private string m_IP;
        #endregion

        #region Property
        public bool Broadcast
        {
            set { m_bBroadcast = value; }
        }

        public string IP
        {
            get { return m_IP; }
        }
        #endregion

        #region Ctor
        public CCTcpServerProtocol(int p_iListenPort)
            : base(PrototcolType.TCPIP_TYPE)
        {
            m_iListenPort = p_iListenPort;                     
        }
        #endregion        

        #region Private Method
        private void CreateServer()
        {
            IPAddress[] aryLocalAddr = null;
            String strHostName = "";

            try
            {
                // NOTE: DNS lookups are nice and all but quite time consuming.
                strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                aryLocalAddr = ipEntry.AddressList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to get local address {0} ", ex.Message);
            }

            m_IP = aryLocalAddr[0].ToString();

            // Create the listener socket in this machines IP address
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //This is very important, if we need to rebind the same socket, we have to set ReuseAddress
            listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            
            //listener.Bind(new IPEndPoint(aryLocalAddr[0], m_iListenPort));
            listener.Bind(new IPEndPoint(IPAddress.Loopback, m_iListenPort));	// For use with localhost 127.0.0.1

            listener.Listen(10); // N client

            // Setup a callback to be notified of connection requests
            listener.BeginAccept(new AsyncCallback( this.OnConnectRequest), listener);
        }
        private void AddNewConnection(Socket sockClient)
        {
            // Program blocks on Accept() until a client connects.            
            ConnectedClient client = new ConnectedClient(sockClient);
            m_listClient.Add(client);            
            
            client.SetupRecieveCallback(this);
        }
        #endregion        

        #region Public Method
		public override bool Create()
		{
			CreateServer();
			return true;
		}
		
        public override bool Destroy()
        {
            try
            {               
                for (int iIdx = m_listClient.Count-1; iIdx >= 0; --iIdx)
                {
                    ConnectedClient client = m_listClient[iIdx];

                    if (client.Sock.Connected)
                    {
                        client.Sock.Close();
                        m_listClient.Remove(client);
                    }
                }                   

                m_DisconnectHandler(this, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server: Unusual error during Disconnect!");
                return false;
            }

        }
        public override void Send(string p_szMsg)
        {                       
            foreach (ConnectedClient clientSend in m_listClient)
            {
                try
                {
                    /*
                     * 如果沒有開啟廣播的話，就要檢查是Client是否收過訊息。
                     */ 
                    if ( m_bBroadcast == false )
                        if (clientSend.ReceiveMsgFlag == false)
                            continue;

                    if (clientSend.Sock.Connected ==  false )
                        continue;

                    // Convert to byte array and send.
                    Byte[] byteDateLine = Encoding.ASCII.GetBytes(p_szMsg.ToCharArray());
                    clientSend.Sock.Send(byteDateLine);
                    clientSend.ReceiveMsgFlag = false;                        
                }
                catch
                {
                    // If the send fails the close the connection					
                    clientSend.Sock.Close();
                    m_listClient.Remove(clientSend);                       
                }
            }           
        }
        public override string Receive()
        {
            foreach (ConnectedClient client in m_listClient)
            {
                if (client.ReceiveMsgFlag == true)
                {
                    string myString = Encoding.Default.GetString(client.ReceiveData);
                    string[] str = myString.Split('\x0');
                    return str[0];
                }                
            }
            return "";
        }
       
        // Callback
        public void OnConnectRequest(IAsyncResult ar)
        {
            Socket listener = ar.AsyncState as Socket;

            AddNewConnection(listener.EndAccept(ar));

            this.m_ConnectHandler(this, null);

            listener.BeginAccept(new AsyncCallback(OnConnectRequest), listener);            
        }        
        public void OnRecievedData(IAsyncResult ar)
        {
            ConnectedClient client = ar.AsyncState as ConnectedClient;
			byte [] aryRet = client.GetRecievedData( ar );
           
            if (aryRet.Length < 1)
            {
                client.Sock.Close();
                m_listClient.Remove(client);
                return;
            }
            else
                m_DataReceiveHandler(this, null);
			
			client.SetupRecieveCallback( this );
		}        
        #endregion
    }
    
    internal class ConnectedClient
    {
        #region Private Member
        private Socket m_sock;						// Connection to the client
        private byte[] m_byBuff = new byte[1024];		// Receive data buffer        
        private bool m_bReceiveMsg = false;
        #endregion

        #region Property
        // Readonly access
        public Socket Sock
        {
            get { return m_sock; }
        }
        public byte[] ReceiveData
        {
            get { return m_byBuff; }
        }
        public bool ReceiveMsgFlag
        {
            get { return m_bReceiveMsg; }
            set { m_bReceiveMsg = value; }
        }
        #endregion

        #region Ctor
        public ConnectedClient(Socket sock)
		{
			m_sock = sock;
            //m_ID = GetID();
        }
        #endregion     

        #region Public Member
        /// <summary>
        /// Setup the callback for recieved data and loss of conneciton
        /// </summary>
        /// <param name="app"></param>
        public void SetupRecieveCallback(CCTcpServerProtocol p_Protocol)
        {
            try
            {
				// Clear buffer before receiveing
				Array.Clear(m_byBuff,0,m_byBuff.Length);
				
                AsyncCallback recieveData = new AsyncCallback(p_Protocol.OnRecievedData);
                m_sock.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.None, recieveData, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Recieve callback setup failed! {0}", ex.Message);                
            }
        }
        public byte [] GetRecievedData( IAsyncResult ar )
		{
            int nBytesRec = 0;
			try
			{
				nBytesRec = m_sock.EndReceive( ar );
                ReceiveMsgFlag = true;
			}
			catch{}

			byte [] byReturn = new byte[nBytesRec];
			Array.Copy( m_byBuff, byReturn, nBytesRec );
			
			/*
			// Check for any remaining data and display it
			// This will improve performance for large packets 
			// but adds nothing to readability and is not essential
			int nToBeRead = m_sock.Available;
			if( nToBeRead > 0 )
			{
				byte [] byData = new byte[nToBeRead];
				m_sock.Receive( byData );
				// Append byData to byReturn here
			}
			*/
			return byReturn;
		}                
        #endregion
        
    }
}
