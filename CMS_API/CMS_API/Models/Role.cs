using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Models
{
    public class Role
    {
        public int id { set; get; }
        public string Name { set; get; }

        public List<UserHasRole> userHasRoles { get; set; }
        public List<RoleHasPermission> roleHasPermissions { get; set; }
    }
}
