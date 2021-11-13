using CMS_API.Contract.Requests;
using CMS_API.Data;
using CMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Repositories
{
    public class RoleRepo : IRole
    {
        private readonly PostgreSqlContext _context;
        public RoleRepo(PostgreSqlContext context)
        {
            _context = context;
        }
        public bool CreateRole(RoleRequest role)
        {
            try
            {
                Role input = new Role
                {
                    Name = role.Name,
             
                };
                _context.role.Add(input);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Role GetRoleById(int id)
        {
            return _context.role.SingleOrDefault(x => x.id == id);
        }


        public IEnumerable<Role> GetAllRole()
        {
            var query = _context.role.ToList();
            return query;
        }


        public bool UpdateRole(int id, Role role)
        {
            try
            {
                var entity = _context.role.SingleOrDefault(x => x.id == id);


                entity.Name = role.Name;

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public bool DeleteRole(List<int> ids)
        {
            try
            {
                var DelRole = (from r in _context.role
                             where ids.Contains(r.id)
                             select r).ToList();
                _context.role.RemoveRange(DelRole);
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
