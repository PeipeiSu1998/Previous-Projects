using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    interface ICommunicationController
    {
        string ReadReplyMessage();
        void SendMessage(string Message);
    }
}
