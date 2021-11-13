using CMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_API.Data;
using CMS_API.Repositories.Interfaces;
using CMS_API.Contract.Requests;

namespace CMS_API.Repositories
{
    public class UserHasRoleRepo : IUserHasRole
    {
        private readonly PostgreSqlContext _context;
        public UserHasRoleRepo(PostgreSqlContext context)
        {
            _context = context;
        }

        public IEnumerable<UserHasRole> GetAll()
        {
            var query = _context.userHasRole.ToList();
            return query;
        }



        public IEnumerable<UserHasRole> GetBy(int idUser)
        {
            var dataRt = (from u in _context.userHasRole

                          where (u.idUser == idUser)
                          select u).ToList();
            return dataRt;
        }

        public bool SetRole(UserHasRoleRequest userHasRole)
        {
            try
            {
                foreach (int rid in userHasRole.idRole)
                {
                    UserHasRole input = new UserHasRole
                    {
                        idUser = userHasRole.idUser,
                        idRole = rid
                    };
                    _context.userHasRole.Add(input);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public bool UnsetRole(List<int> ids)
        {
            try
            {
                var IsUnset = (from u in _context.userHasRole
                             where (ids.Contains(u.id))
                             select u).ToList();
                _context.userHasRole.RemoveRange(IsUnset);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
