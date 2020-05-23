using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kommunity_WebApp.Models
{
    public class Petition
    {
        public int peid { get; set; }
        public string title { get; set; }
        public User creator { get; set; }
        public string date { get; set; }
        public string content { get; set; }
        public bool approved { get; set; }
       // public string approvedby { get; set; }
       // public int numOfVotes { get; set; }
    }
}
