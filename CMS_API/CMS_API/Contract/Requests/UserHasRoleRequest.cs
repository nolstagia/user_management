using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Contract.Requests
{
    public class UserHasRoleRequest
    {
        public int idUser { get; set; }
        public List<int> idRole { get; set; }
    }
}
