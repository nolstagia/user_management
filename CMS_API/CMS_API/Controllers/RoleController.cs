using CMS_API.Contract.Requests;
using CMS_API.Contract.Response;
using CMS_API.Models;
using CMS_API.Repositories;
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
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        public RoleController(IRole role)
        {
            _role = role;
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<Role> ListRole()
        {
            return _role.GetAllRole();
        }

        [Authorize]
        [HttpGet("id")]
        public Role GetRoleById(int id)
        {
            return _role.GetRoleById(id);
        }

        [Authorize]
        [HttpPost("CreateRole")]
        public ResponseModel CreateRole([FromBody] RoleRequest role)
        {
            if (ModelState.IsValid)
            {
                bool checkCreate = _role.CreateRole(role);
                if (checkCreate)
                {
                    return new ResponseModel { Code = 0, Message = "OK" };
                }
                else
                {
                    return new ResponseModel { Code = -1, Message = "Error" };
                }

            }
            return new ResponseModel { Code = -2, Message = "Role invalid" };
        }
        [Authorize]
        [Route("{id:int}")]
        [HttpPut]
        public ResponseModel UpdateRole([FromRoute] int id, [FromBody] Role role)
        {
            bool checkUpdate = _role.UpdateRole(id, role);
            if (checkUpdate)
            {
                return new ResponseModel { Code = 0, Message = "OK" };
            }
            else
            {
                return new ResponseModel { Code = -1, Message = "Error" };
            }
        }

        [Authorize]
        [HttpDelete("DeleteRole")]
        public ResponseModel DeleteRole([FromBody] List<int> ids)
        {
            bool checkDelete = _role.DeleteRole(ids);
            if (checkDelete)
            {
                return new ResponseModel { Code = 0, Message = "OK" };
            }
            else
            {
                return new ResponseModel { Code = -1, Message = "Error" };
            }
        }
    }
}
