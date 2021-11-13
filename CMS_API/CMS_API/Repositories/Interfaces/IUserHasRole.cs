using CMS_API.Contract.Requests;
using CMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Repositories.Interfaces
{
    public interface IUserHasRole
    {
        public bool SetRole(UserHasRoleRequest userHasRole);
        public bool UnsetRole(List<int> ids);
        public IEnumerable<UserHasRole> GetAll();
        public IEnumerable<UserHasRole> GetBy(int idUser);
    }
}
