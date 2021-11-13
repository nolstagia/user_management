using CMS_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_API.Models;
using CMS_API.Contract.Requests;


namespace CMS_API.Repositories
{
    public class UserRepo : IUser
    {
        private readonly PostgreSqlContext _context;

        public UserRepo(PostgreSqlContext context)
        {
            _context = context;
        }

       
        public bool CreateUser(UserRequest user)
        {
            try
            {
                User input = new User
                {
                    FullName = user.FullName,
                    BirthDay = user.BirthDay,
                    Email = user.Email,
                    Address = user.Address,
                    UserName = user.UserName,
                    Password = user.Password,

                };
                _context.users.Add(input);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetUserById(int id)
        {
            return _context.users.SingleOrDefault(x => x.id == id);
        }


        public IEnumerable<User> GetAllUser(string FullName, string Email)
        {
            var DataRt = (from u in _context.users
                          
                          where (string.IsNullOrEmpty(FullName) || u.FullName.Contains(FullName))
                          && (string.IsNullOrEmpty(Email) || u.Email.Contains(Email))
                          //&& (string.IsNullOrEmpty(id.ToString()) || u.id == id)
                          select u).ToList();
            return DataRt;
        }

       
        public bool UpdateUser(int id, User user)
        {
            try
            {
                var entity = _context.users.SingleOrDefault(x => x.id == id);


                entity.FullName = user.FullName;
                entity.BirthDay = user.BirthDay;
                entity.Email = user.Email;
                entity.Address = user.Address;
                entity.UserName = user.UserName;
                entity.Password = user.Password;

                _context.SaveChanges();
 
                return true;
            }
            catch(Exception) 
            {
                return false;
            }
            
            
        }

        public bool DeleteUser(List<int> ids) 
        {
            try 
            {
                var IsDel = (from u in _context.users
                             where ids.Contains(u.id)
                             select u).ToList();
                _context.users.RemoveRange(IsDel);
                _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
          
        }

        public bool Login(string userName, string password)
        {
            var loginInfo = _context.users.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if (loginInfo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
