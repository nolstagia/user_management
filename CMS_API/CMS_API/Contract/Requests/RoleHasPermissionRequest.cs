using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Contract.Requests
{
    public class RoleHasPermissionRequest
    {
        public int idRole { get; set; }
        public List<int> idPermissions { get; set; }
    }
}
