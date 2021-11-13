using CMS_API.Contract.Requests;
using CMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Repositories.Interfaces
{
     public interface IRoleHasPermission
    {
        public bool SetPermission(RoleHasPermissionRequest roleHasPermission);
        public bool UnsetPermission(RoleHasPermissionRequest roleHasPermission);

        public IEnumerable<RoleHasPermission> GetBy(int idRole);
    }
}
