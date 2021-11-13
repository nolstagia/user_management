using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Models
{
    public class User
    {
        public int id { set; get; }
        public string FullName { set; get; }
        public DateTime BirthDay { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }

        public List<UserHasRole> userHasRoles { get; set; }
    }
}
