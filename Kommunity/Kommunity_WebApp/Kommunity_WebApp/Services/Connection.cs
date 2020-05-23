using System.IO;
using System.Net.Sockets;
using Newtonsoft.Json;
using Kommunity_WebApp.Models;

namespace Kommunity_WebApp.Services
{
    public class Connection
    {
        public const string IP = "localhost";
        public const int PORT = 8888;

        // Defining a client socket and input/output streams
        public TcpClient client;
        public StreamReader sr;
        public StreamWriter sw;


        public Connection()
        {
            try
            {
                // Initializing the socket and input/output streams
                client = new TcpClient(IP, PORT);
                sr = new StreamReader(client.GetStream());
                sw = new StreamWriter(client.GetStream());
            }
            catch
            {

            }

        }



    }
}