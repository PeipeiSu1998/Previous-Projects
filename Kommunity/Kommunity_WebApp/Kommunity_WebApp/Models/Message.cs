using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kommunity_WebApp.Models
{
    public class Message
    {
        public int id { get; set; }
        public long senderId { get; set; }
        public string date { get; set; }
        public string text { get; set; }

    }
}
