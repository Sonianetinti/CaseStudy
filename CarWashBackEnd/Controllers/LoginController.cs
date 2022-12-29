﻿using CarWashBackEnd.Models;
using CarWashBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarWashBackEnd.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        AccountRepository _accountrepository;
        public LoginController()
        {
            this._accountrepository = new AccountRepository(new CarWashDbEntities());
        }

        [HttpPost]

        public IHttpActionResult VerifyLogin(UserTable objlogin)
        {
            UserTable user = null;
            try
            {
                user = _accountrepository.VerifyLogin(objlogin.Email, objlogin.Password);

                if (user != null)
                {
                    //return NotFound();
                    return Ok(user);

                }

            }
            catch (Exception)
            {

            }
            return NotFound();

        }

    }
}
