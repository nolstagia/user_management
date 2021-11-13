using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_API.Models;
using CMS_API.Repositories;
using CMS_API.Contract.Requests;
using CMS_API.Contract.Response;

using System.Text;
using CMS_API.Data;
using CMS_API.Repositories.Repo;
using Microsoft.AspNetCore.Authorization;

namespace CMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }

        //[Authorize]
        [HttpGet]
        public IEnumerable<User> ListUsers(string FullName, string Email)
        {
            return _user.GetAllUser( FullName, Email);
        }
        //[Authorize]
        [HttpGet("Id")]
        public User GetUserById(int Id)
        {
            return _user.GetUserById(Id);
        }

        //[Authorize]
        [HttpPost("CreateUser")]
        public ResponseModel CreateUser([FromBody] UserRequest user)
        {
            if (ModelState.IsValid)
            {
                bool checkCreate = _user.CreateUser(user);
                if (checkCreate)
                {
                    return new ResponseModel { Code = 0, Message = "OK" };
                }
                else
                {
                    return new ResponseModel { Code = -1, Message = "Error" };
                }
               
            }
            return new ResponseModel { Code = -2, Message = "User invalid" };
        }
        //[Authorize]
        [Route("{id:int}")]
        [HttpPut]
        public ResponseModel UpdateUser([FromRoute] int id, [FromBody] User users)
        {
            bool checkUpdate = _user.UpdateUser(id, users);
            if (checkUpdate)
            {
                return new ResponseModel { Code = 0, Message = "OK" };
            }
            else
            {
                return new ResponseModel { Code = -1, Message = "Error" };
            }
        }

        //[Authorize]
        [HttpDelete("DeleteUser")]
        public ResponseModel DeleteUser([FromBody]List<int> ids)
        {
            bool checkDelete = _user.DeleteUser(ids);
            if (checkDelete)
            {
                return new ResponseModel { Code = 0, Message = "OK" };
            }
            else
            {
                return new ResponseModel { Code = -1, Message = "Error" };
            }
        }
        //[AllowAnonymous]
        /*[HttpPost("login")]
        public string Login(string userName, string password)   
        {
            bool checkLogin = _user.Login(userName, password);
            if (checkLogin)
            {
                return LoginRepo.GenerateToken(userName);
            }
            else
            {
                return "";
            }
        }*/


    }
}
