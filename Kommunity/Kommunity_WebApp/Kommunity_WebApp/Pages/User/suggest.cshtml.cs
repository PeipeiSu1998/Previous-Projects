using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kommunity_WebApp.Models;
using Kommunity_WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kommunity_WebApp.Pages.User
{
    public class suggestModel : PageModel
    {
        [BindProperty]
        public PostData postData { get; set; }
        
        
        public void OnPostMakePetition()
        {
            Petition petition = new Petition();
            var v = HttpContext.Session.GetString("cpr");
            Models.User creator = new Models.User();
            creator.cpr = v;
            petition.creator = creator;
            petition.approved = false;
            petition.date = DateTime.Now.ToString();
            petition.content = postData.Content;
            Service.MakePetition(petition);

        }

        public class PostData
        {

            //   [DataType(DataType.Password)]    //Make this required (Todo)
            public string Content { get; set; }

        }
    }
}