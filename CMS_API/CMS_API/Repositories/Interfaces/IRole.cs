using CMS_API.Contract.Requests;
using CMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Repositories
{
    public interface IRole
    {
        public IEnumerable<Role> GetAllRole();
        public Role GetRoleById(int id);
        public bool CreateRole(RoleRequest role);
        public bool UpdateRole(int id, Role role);
        public bool DeleteRole(List<int> ids);
    }
}
