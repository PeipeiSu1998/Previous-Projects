using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kommunity_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Kommunity_WebApp.Services;

namespace Kommunity_WebApp.Pages.News
{
    public class trafficModel : PageModel
    {
        public List<Post> posts = new List<Post>();
        public List<Post> trafic = new List<Post>();

        public void OnGet()
        {
            var city = HttpContext.Session.GetString("city");
            posts = Service.getPosts(city);
            foreach (var item in posts)
            {
                if (item.type == "traffic")
                {
                    trafic.Add(item);
                }
            }

        }
    }
}