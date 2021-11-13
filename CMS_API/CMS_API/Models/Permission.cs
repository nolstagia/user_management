using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Models
{
    public class Permission
    {
        public int id { set; get; }
        public string Screen { set; get; }
        public string Name { set; get; }

        public List<RoleHasPermission> roleHasPermissions { get; set; }
    }
}
