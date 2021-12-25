using CollageWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollageWebApplication.Controllers.API
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(UserModel.usersList);
            }
            catch
            {
                return Ok(new { Massage = "No users been found" });
            }
        }

        // GET: api/Users/5
        public IHttpActionResult GetById(int id)
        {
            try
            {
                UserModel expectedUser = UserModel.usersList.Find(user => user.id == id);
                return Ok(expectedUser);
            }
            catch
            {
                return Ok(new { Massage = "No user been found" });
            }
        }

        // POST: api/Users
        public IHttpActionResult CreateNewUser([FromBody]UserModel user)
        {
            try
            {
                UserModel newUser = user;
                UserModel.usersList.Add(newUser);
                return Ok(new { Massage = "User Been Added", UserModel.usersList });
            }
            catch
            {
                return Ok(new { Massage = "Error adding new user." });
            }
        }

        // PUT: api/Users/5
        [HttpPut]
        public IHttpActionResult EditUser(int id, [FromBody] UserModel user)
        {
                for(int i = 0; i < UserModel.usersList.Count; i++)
                {
                    if(UserModel.usersList[i].id == id)
                    {
                        UserModel.usersList[i].FirstName = user.FirstName;
                        UserModel.usersList[i].LastName = user.LastName;
                        UserModel.usersList[i].BirthYear = user.BirthYear;
                        UserModel.usersList[i].IsActive = user.IsActive;
                        return Ok(new { Massage = "User Been Edited", UserModel.usersList });
                    }
                }
            return Ok(new { Massage = "No user been found" });
        }

        // DELETE: api/Users/5
        public IHttpActionResult DeleteUser(int id)
        {
            for (int i = 0; i < UserModel.usersList.Count; i++)
            {
                if (UserModel.usersList[i].id == id) UserModel.usersList.RemoveAt(i);
                return Ok(new { Massage = "User been deleted", UserModel.usersList });
            }
            return Ok(new { Massage = "No user been found" });
        }
    }
}
