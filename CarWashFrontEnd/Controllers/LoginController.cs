using CarWashFrontEnd.Models;
using CarWashFrontEnd.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarWashFrontEnd.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult LoginUser()
        {
            return View();
        }
        public ActionResult AdminPage()
        {
            return View();
        }


        #region login
        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginViewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoginViewModel newUser = new LoginViewModel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<LoginViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }

                }
                return RedirectToAction("AdminPage");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);   
            
            }

            return View(login);
         
        }
        





        #endregion


        //Action method to create user
        #region Register
        public async Task<ActionResult> Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("Users", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }



                return RedirectToAction("Index", "User");
            }
            return View(user);
        }
        #endregion
    }
}
