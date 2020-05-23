using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kommunity_WebApp.Models;
using Kommunity_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kommunity_WebApp.Pages.User;
using Microsoft.AspNetCore.Http;

namespace Kommunity_WebApp.Pages.News
{
    

    public class eventsModel : PageModel
    {
        public List<Post> posts = new List<Post>();
        public List<Post> events = new List<Post>();

        public void OnGet()
        {
            var city = HttpContext.Session.GetString("city");
            posts = Service.getPosts(city);
            foreach(var item in posts)
            {
                if(item.type == "events")
                {
                    events.Add(item);
                }
            }
            
        }
    }
}