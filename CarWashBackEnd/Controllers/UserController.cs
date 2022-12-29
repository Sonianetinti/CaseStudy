using CarWashBackEnd.Models;
using CarWashBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarWashBackEnd.Controllers
{
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        IUser<UserTable> _user;
        public UserController()
        {
            this._user = new UserRepository(new CarWashDbEntities());
        }

        //ActionMethod to Create user
        #region
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateUser(UserTable user)
        {
            UserTable userObj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                _user.Add(user);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Saved Successfully");


        }
        #endregion
        //ActionMethod To Get all users
        #region

        [HttpGet]
        [Route("")]
        public IEnumerable<UserTable> Get()
        {
            var users = _user.Get();
            return users;
        }
        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            _user.Delete(Id);
            if (Id <= 0)
                return BadRequest("Not a valid id");

            return Ok("Deleted successfully");


        }
        #endregion
        //ActionMethod to Update User
        #region
        [HttpPut]
        public IHttpActionResult Update(int Id, UserTable user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");
                _user.Update(Id,user);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Updated Successfully");




        }
        #endregion
        //ActionMethod to get User by Id
        #region
        [HttpGet]
        public UserTable GetById(int Id)
        {
            var user = _user.GetById(Id);
            return user;
        }
        #endregion
    }
}
