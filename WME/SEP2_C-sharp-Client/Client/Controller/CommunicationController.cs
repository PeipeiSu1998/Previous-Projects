using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    /// <summary>
    /// This is a sealed thread safe singleton class. It can not be inherited from.
    /// </summary>
    public sealed class CommunicationController : ICommunicationController
    {
        private static readonly object InstanceLock = new object();
        private static CommunicationController instance = null;
        private static int Port = 4400;
        private static IPEndPoint serverAddress;
        public Socket clientSocket { get; private set; }

        private CommunicationController()
        {

        }

        public static CommunicationController GetInstance()
        {
            if (instance == null)
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CommunicationController();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// This method is getting local addres from the client computer
        /// </summary>
        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /// <summary>
        /// This method creates socket connection on chosen port(in our case 4400)
        /// </summary>
        private void Setup()
        {
            serverAddress = new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), Port);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);
        }

        /// <summary>
        /// This method is converting ASCII bytes to string
        /// </summary>
        public string ReadReplyMessage()
        {
            byte[] rcvLenBytes = new byte[4];
            clientSocket.Receive(rcvLenBytes);
            int rcvLen = BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            clientSocket.Receive(rcvBytes);
            string rcv = Encoding.ASCII.GetString(rcvBytes);

            return rcv;
        }

        /// <summary>
        /// This method is sending ASCII bytes with the header byte giving the length of the message
        /// </summary>
        public void SendMessage(string Message)
        {
            Setup();

            int toSendLen = Encoding.ASCII.GetByteCount(Message);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(Message);
            byte[] toSendLenBytes = BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);
        }
    }
}