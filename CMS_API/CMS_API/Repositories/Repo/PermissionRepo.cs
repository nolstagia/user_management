using CMS_API.Contract.Requests;
using CMS_API.Data;
using CMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Repositories
{
    public class PermissionRepo : IPermission
    {
        private readonly PostgreSqlContext _context;
        public PermissionRepo(PostgreSqlContext context)
        {
            _context = context;
        }
        public bool CreatePermission(PermissionRequest permission)
        {
            try
            {
                Permission input = new Permission
                {
                    Screen = permission.Screen,
                    Name = permission.Name,

                };
                _context.permission.Add(input);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Permission GetPermissionById(int id)
        {
            return _context.permission.SingleOrDefault(x => x.id == id);
        }


        public IEnumerable<Permission> GetAllPermission()
        {
            var query = _context.permission.ToList();
            return query;
        }


        public bool UpdatePermission(int id, Permission permission)
        {
            try
            {
                var entity = _context.permission.SingleOrDefault(x => x.id == id);

                entity.Screen = permission.Screen;
                entity.Name = permission.Name;

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public bool DeletePermission(List<int> ids)
        {
            try
            {
                var DelPer = (from u in _context.permission
                              where ids.Contains(u.id)
                               select u).ToList();
                _context.permission.RemoveRange(DelPer);
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
