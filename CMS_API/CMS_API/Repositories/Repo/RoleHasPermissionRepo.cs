using CMS_API.Contract.Requests;
using CMS_API.Data;
using CMS_API.Models;
using CMS_API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Repositories.Repo
{
    public class RoleHasPermissionRepo : IRoleHasPermission
    {
        private readonly PostgreSqlContext _context;
        public RoleHasPermissionRepo(PostgreSqlContext context)
        {
            _context = context;
        }

        public IEnumerable<RoleHasPermission> GetBy(int idRole)
        {
            var dataRt = (from r in _context.roleHasPermission

                          where (r.idRole == idRole)
                          select r).ToList();
            return dataRt;
        }

        public bool SetPermission(RoleHasPermissionRequest roleHasPermission)
        {
            try
            {

                foreach (int pid in roleHasPermission.idPermissions)

                {
                    RoleHasPermission input = new RoleHasPermission
                    {
                        idRole = roleHasPermission.idRole,
                        idPermission = pid
                    };
                    _context.roleHasPermission.Add(input);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception /*ex*/)
            {
                //throw ex;
                return false;
            }
        }

        public bool UnsetPermission(RoleHasPermissionRequest roleHasPermission)
        {
            try
            {
                var IsUnset = (from r in _context.roleHasPermission
                               where (r.idRole == roleHasPermission.idRole && roleHasPermission.idPermissions.Contains(r.idPermission))
                               select r).ToList();
                _context.roleHasPermission.RemoveRange(IsUnset);
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
