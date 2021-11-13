using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Models
{
    public class UserHasRole
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public User user { get; set; }

        public int idRole { get; set;  }
        public Role role { get; set; }
    }
}
