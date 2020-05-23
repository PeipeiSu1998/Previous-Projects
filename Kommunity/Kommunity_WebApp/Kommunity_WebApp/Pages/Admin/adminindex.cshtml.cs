using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kommunity_WebApp.Models;
using Kommunity_WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kommunity_WebApp.Pages.Admin
{
    public class adminindexModel : PageModel
    {
        public Models.User user = new Models.User();
        public List<Petition> petitions = new List<Petition>();


        public void OnGet()
        {

            var name = HttpContext.Session.GetString("userName");
            var city = HttpContext.Session.GetString("city");

            user.name = name;
            petitions = Service.getUnapprovedPetitions(city);

        }

        public void OnPostApprove()
        {

        }
    }
}