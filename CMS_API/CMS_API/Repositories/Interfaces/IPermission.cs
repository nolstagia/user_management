using CMS_API.Contract.Requests;
using CMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Repositories
{
    public interface IPermission
    {
        public IEnumerable<Permission> GetAllPermission();
        public Permission GetPermissionById(int id);
        public bool CreatePermission(PermissionRequest permission);
        public bool UpdatePermission(int id, Permission permission);
        public bool DeletePermission(List<int> ids);
    }
}
