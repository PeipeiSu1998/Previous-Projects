using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kommunity_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kommunity_WebApp.Services;
using Microsoft.AspNetCore.Http;

namespace Kommunity_WebApp.Pages.User
{
    public class voteModel : PageModel
    {
    //    [BindProperty]
    //    public VoteData voteData { get; set; }

        public List<Petition> petitions = new List<Petition>();

        public void OnGet()
        {
            var city = HttpContext.Session.GetString("city");
            petitions = Service.getApprovedPetitions(city);
        }


        public void OnPostVote(Petition p)
        {
            Petition petition = new Petition();
            var city = HttpContext.Session.GetString("city");
            var cpr = HttpContext.Session.GetString("cpr");
            Models.User user = new Models.User();
            user.cpr = cpr;
            user.city = city;
            petition.creator = user;
            Service.vote(user, petition);
        }

    /*    public class VoteData
        {
            Post post;
            bool vote;
        }  */
    }
}