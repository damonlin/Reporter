using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;   // Endpoint
using System.Net.Sockets;
using System.Windows.Forms;

namespace CommunicationInterface
{
    public class CCTcpClientProtocol : CCBaseProtocol
    {
        #region Private Member
        private Socket m_sock = null;
        private byte[] m_byBuff = new byte[1024];	// Recieved data buffer
        private string m_szIP = "127.0.0.1";
        private int m_iPort = 0;
        #endregion

        #region Ctor
        public CCTcpClientProtocol(string p_szIP, int p_iPort)
            : base(PrototcolType.TCPIP_TYPE)
        {
            m_szIP = p_szIP;
            m_iPort = p_iPort;
        }
        #endregion

        #region Public Method
        public override bool Create()
        {
            {
                try
                {
                    // Close the socket if it is still open
                    if (m_sock != null && m_sock.Connected)
                        return true;

                    // Create the socket object
                    m_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    // Define the Server address and port                    
                    IPEndPoint epServer = new IPEndPoint(IPAddress.Parse(m_szIP), m_iPort);

                    // Connect to the server blocking method and setup callback for recieved data
                    // m_sock.Connect( epServer );
                    // SetupRecieveCallback( m_sock );

                    // Connect to server non-Blocking method
                    m_sock.Blocking = false;
                    AsyncCallback onconnect = new AsyncCallback(OnConnect);
                    m_sock.BeginConnect(epServer, onconnect, m_sock);

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Server Connect failed!");
                    return false;
                }
            }
        }
        public override bool Destroy()
        {
            if (m_sock != null && m_sock.Connected)
            {
                m_sock.Shutdown(SocketShutdown.Both);
                AsyncCallback ondisconnect = new AsyncCallback(OnDisconnect);
                m_sock.BeginDisconnect(true, ondisconnect, m_sock);                
            }
            else
            {
                // 因為Server如果主動關閉, Client 的 m_sock 就會無效
                // 因此如果 m_sock == null, 還是需要呼叫 m_DisconnectHandler Callback,
                // 來結束 Thread.
                this.m_DisconnectHandler(this, null);       
            }
            return true;
        }
        public override void Send(string p_szMsg)
        {
            if (m_sock != null && m_sock.Connected)
            {
                // Convert to byte array and send.
                Byte[] byteDateLine = Encoding.ASCII.GetBytes(p_szMsg.ToCharArray());
                m_sock.Send(byteDateLine, byteDateLine.Length, 0);
            }
        }
        public override string Receive()
        {
			string myString = Encoding.Default.GetString(m_byBuff);
			string[] str = myString.Split('\x0');
            return str[0];            
        }

        // Callback
        public void OnConnect(IAsyncResult ar)
        {
            // Socket was the passed in object
            Socket sock = ar.AsyncState as Socket;

            // Check if we were sucessfull
            try
            {
                //sock.EndConnect( ar );
                if (sock.Connected)
                {
                    sock.EndConnect(ar);
                    SetupRecieveCallback(sock);
                    this.m_ConnectHandler(this, null);
                }
                else
                    MessageBox.Show("Unable to connect to remote machine", "Connect Failed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server: Unusual error during Connect!");
            }
        }
        public void OnDisconnect(IAsyncResult ar)
        {
            // Socket was the passed in object
            Socket sock = ar.AsyncState as Socket;

            // Check if we were sucessfull
            try
            {
                //sock.EndConnect( ar );
                if (!sock.Connected)
                {
                    sock.EndDisconnect(ar);
                    sock.Close();
                    this.m_DisconnectHandler(this, null);
                }
                else
                    MessageBox.Show("Unable to connect to remote machine", "Disconnect Failed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server: Unusual error during Disconnect!");
            }
        }        
        public void OnRecievedData(IAsyncResult ar)
        {
            // Socket was the passed in object
            Socket sock = (Socket)ar.AsyncState;

            // Check if we got any data
            try
            {
                int nBytesRec = sock.EndReceive(ar);
                if (nBytesRec > 0)
                {
                    //string sRecieved = Encoding.ASCII.GetString(m_byBuff, 0, nBytesRec);
                    m_DataReceiveHandler(this, null);

                    // If the connection is still usable restablish the callback
                    SetupRecieveCallback(sock);
                }
                /*else
                {
                    // If no data was recieved then the connection is probably dead                    
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server: Unusual error druing Recieve!");
            }
        }
        public void SetupRecieveCallback(Socket sock)
        {
            try
            {
				// Clear buffer before receiveing 
				Array.Clear(m_byBuff,0,m_byBuff.Length);
				
                AsyncCallback recieveData = new AsyncCallback(OnRecievedData);
                sock.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.None, recieveData, sock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Setup Recieve Callback failed!");
            }
        }
        #endregion

    }
}
