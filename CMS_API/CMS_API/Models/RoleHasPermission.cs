using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Models
{
    public class RoleHasPermission
    {
        public int id { get; set; }
        public int idRole { get; set;  }
        public Role role { get; set; }
        public int idPermission { get; set;  }
        public Permission permission { get; set; }
    }
}
