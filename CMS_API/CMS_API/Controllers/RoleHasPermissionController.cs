using CMS_API.Contract.Requests;
using CMS_API.Contract.Response;
using CMS_API.Models;
using CMS_API.Repositories;
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
    public class RoleHasPermissionController : ControllerBase
    {
        private readonly IRoleHasPermission _roleHasPermission;
        public RoleHasPermissionController(IRoleHasPermission roleHasPermission)
        {
            _roleHasPermission = roleHasPermission;
        }
        [Authorize]
        [HttpPost("SetPermission")]
        public ResponseModel SetPermission([FromBody] RoleHasPermissionRequest roleHasPermission)
        {
            if (ModelState.IsValid)
            {
                bool checkSet = _roleHasPermission.SetPermission(roleHasPermission);
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
        [HttpDelete("UnsetPermission")]
        public ResponseModel UnsetPermission([FromBody] RoleHasPermissionRequest roleHasPermission)
        {
            bool checkDelete = _roleHasPermission.UnsetPermission(roleHasPermission);
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
        [HttpGet("find")]
        public IEnumerable<RoleHasPermission> ListRole1(int idRole)
        {
            return _roleHasPermission.GetBy(idRole);
        }


    }
}
