using CMS_API.Contract.Requests;
using CMS_API.Contract.Response;
using CMS_API.Models;
using CMS_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHasRoleController : ControllerBase
    {
        private readonly IUserHasRole _userHasRole;
        public UserHasRoleController(IUserHasRole userHasRole)
        {
            _userHasRole = userHasRole;
        }
        [Authorize]
        [HttpPost("SetRole")]
        public ResponseModel SetRole([FromBody] UserHasRoleRequest userHasRole)
        {
            if (ModelState.IsValid)
            {
                bool checkSet = _userHasRole.SetRole(userHasRole);
                if (checkSet)
                {
                    return new ResponseModel { Code = 0, Message = "OK" };
                }
                else
                {
                    return new ResponseModel { Code = -1, Message = "Error" };
                }

            }
            return new ResponseModel { Code = -2, Message = "Invalid" };
        }
        [Authorize]
        [HttpDelete("UnsetRole")]
        public ResponseModel UnsetRole([FromBody] List<int> ids)
        {
            bool checkDelete = _userHasRole.UnsetRole(ids);
            if (checkDelete)
            {
                return new ResponseModel { Code = 0, Message = "OK" };
            }
            else
            {
                return new ResponseModel { Code = -1, Message = "Error" };
            }
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<UserHasRole> ListRole()
        {
            return _userHasRole.GetAll();
        }
        [Authorize]
        [HttpGet("find")]
        public IEnumerable<UserHasRole> ListRole1(int idUser)
        {
            return _userHasRole.GetBy(idUser);
        }
    }
}
