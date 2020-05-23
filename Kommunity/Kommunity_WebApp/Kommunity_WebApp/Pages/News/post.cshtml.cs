using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kommunity_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kommunity_WebApp.Services;
using Microsoft.AspNetCore.Http;

namespace Kommunity_WebApp.Pages.News
{
    public class postModel : PageModel
    {
        [BindProperty]
       public PostData postData { get; set; }


        public void OnPostPublish()
        {
            Post postToPublish = new Post();

        var city = HttpContext.Session.GetString("city");
          //  var name = HttpContext.Session.GetString("userName");
            var cpr = HttpContext.Session.GetString("cpr");
            postToPublish.city = city;
            Models.User creator = new Models.User();
            creator.cpr = cpr;
            creator.city = city;
            //  creator.name = name;
            postToPublish.creator = creator;
            //  DateTime time = DateTime.Now;
            //  DateTime time1 = time.Date;
            //  string format = "yyyy-MM-dd";
            //  time.ToString(format);
            postToPublish.title = postData.title;
            postToPublish.content = postData.Content;
            Service.Post(postToPublish);

        }

        public class PostData
        {
            public string title { get; set; }  //Make this required (Todo)

            //   [DataType(DataType.Password)]    //Make this required (Todo)
            public string Content { get; set; }

        }


    }
}