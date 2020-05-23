using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kommunity_WebApp.Models;
using Kommunity_WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kommunity_WebApp.Pages.News
{
    public class infraModel : PageModel
    {
        public List<Post> posts = new List<Post>();
        public List<Post> Infrastructure = new List<Post>();

        public void OnGet()
        {
            var city = HttpContext.Session.GetString("city");
            posts = Service.getPosts(city);
            foreach (var item in posts)
            {
                if (item.type == "infrastructure")
                {
                    Infrastructure.Add(item);
                }
            }

        }
    }
}