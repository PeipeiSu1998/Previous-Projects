using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kommunity_WebApp.Models
{
    public class Post
    {
        public int pid { get; set; }
        public string title { get; set; }
        public User creator { get; set; }
        public string content { get; set; }
        public string type { get; set; }
        public string date { get; set; }
        public string city { get; set; }
    }
}
