using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kommunity_WebApp.Models;
using Kommunity_WebApp.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Kommunity_WebApp.Pages.User
{
    public class userindexModel : PageModel
    {
        public Models.User user = new Models.User();
        public List<Post> posts = new List<Post>();


        public void OnGet()
        {

            var cpr = HttpContext.Session.GetString("cpr");
            var city = HttpContext.Session.GetString("city");

            user.cpr = cpr;
            posts = Service.getPosts(city);

            if(posts == null)
            {
                List<Post> posts1 = new List<Post>();
                Post p = new Post();
                p.content = "No posts from your city!";
                p.creator = new Models.User();
                posts1.Add(p);
                posts = posts1;

             }

        }
    }
}

