using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kommunity_WebApp.Services;
using Kommunity_WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace Kommunity_WebApp.Pages
{
    public class IndexModel : PageModel
    {


        // Properties to get the data from the user
        [BindProperty]
        public LoginData loginData { get; set; }
        [BindProperty]
        public SignupData signupData { get; set; }


        // Login logic
        public async Task<IActionResult> OnPostLoginAsync()
        {

            // When cpr and password are provided
            if (ModelState.IsValid)
            {
                // Create user object out of the input
                Models.User user = new Models.User();
                user.cpr = loginData.cpr;
                user.password = loginData.Password;

                // send the user to the database server
                var result = Service.findUser(user);

                // if user doesn't exist
                if (result == null)
                {
                    ModelState.AddModelError("", "Cpr or password is invalid");
                    return Page();
                }
                var isValid = (loginData.cpr.Equals(result.cpr)  && loginData.Password.Equals(result.password));
                if (!isValid)
                {
                    ModelState.AddModelError("", "Cpr or password is invalid");
                    return Page();
                }
        
                //Create Identity from user info
          //      var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
          //      identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginData.cpr));
          //      identity.AddClaim(new Claim(ClaimTypes.Name, loginData.cpr));
          //      //Authenticate using the identity
          //      var principal = new ClaimsPrincipal(identity);
          //      await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = loginData.RememberMe });

                //Set the session information

               // HttpContext.Session.SetString("userName", result.name);
                HttpContext.Session.SetString("city", result.city);
                HttpContext.Session.SetString("cpr", result.cpr);

                if (result.role == "Admin")
                {

                    return RedirectToPage("admin/adminindex");

                }

                else
                {

                    return RedirectToPage("user/userindex/");
                }
                

            }

            // No cpr or password provided
            else{
                ModelState.AddModelError("", "Cpr or password is blank");
                return Page();
            }


        }

           // Signup logic
        public async Task<IActionResult> OnPostSignupAsync()
        {
            if (ModelState.IsValid)
            {

                // Check password matching
                if (signupData.Password != signupData.RepetePassword)
                {
                    ModelState.AddModelError("", "Make sure to enter matching passwords");
                    return Page();
                }
                
                // Create a user object out of signup data
                Models.User user = new Models.User();
                user.cpr = signupData.cpr;
                user.password = signupData.Password;
                user.city = signupData.City;

                // Send the object to the database server
                var result = Service.signup(user);
               
                // if the user is not created
                if (result == null)
                {
                    ModelState.AddModelError("", "Something went wrong!");
                    return Page();
                }

                // double check if the created and returned user is matching with signup data
                var isValid = (signupData.cpr.Equals(result.cpr) && signupData.Password.Equals(result.password));
                if (!isValid)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return Page();
                }
                // HttpContext.Session.SetString("userName", result.name);
                HttpContext.Session.SetString("city", result.city);
                HttpContext.Session.SetString("cpr", result.cpr);
                return RedirectToPage("user/userindex/");
            }


            // When not filling required fields
            else
            {
                ModelState.AddModelError("", "CPR, Password, and Repete password are required to signup!");
                return Page();
            }
        }
        

        // get the login data from user input
        public class LoginData
        {
         //   [Required]
            public string cpr { get; set; }

         //   [Required, DataType(DataType.Password)]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }  

        // get the signup data from user input
        public class SignupData
        {
            public string cpr { get; set; }  //Make this required (Todo)

         //   [DataType(DataType.Password)]    //Make this required (Todo)
            public string Password { get; set; }

          //  [DataType(DataType.Password)]    //Make this required (Todo)
            public string RepetePassword { get; set; }

            public string City { get; set; }
        }
    }
}
