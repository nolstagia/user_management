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
    public class PermissionController : ControllerBase
    {
        private readonly IPermission _permission;
        public PermissionController(IPermission permission)
        {
            _permission = permission;
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<Permission> ListPermission()
        {
            return _permission.GetAllPermission();
        }

        [Authorize]
        [HttpGet("id")]
        public Permission GetPermissionById(int id)
        {
            return _permission.GetPermissionById(id);
        }

        [Authorize]
        [HttpPost("CreatePermission")]
        public ResponseModel CreatePermission([FromBody] PermissionRequest permission)
        {
            if (ModelState.IsValid)
            {
                bool checkCreate = _permission.CreatePermission(permission);
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
        public ResponseModel UpdatePermission([FromRoute] int id, [FromBody] Permission permission)
        {
            bool checkUpdate = _permission.UpdatePermission(id, permission);
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
        [HttpDelete("DeletePermission")]
        public ResponseModel DeletePermission([FromBody] List<int> ids)
        {
            bool checkDelete = _permission.DeletePermission(ids);
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
