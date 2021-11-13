using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_API.Contract.Requests;
using CMS_API.Models;

namespace CMS_API.Repositories
{
    public interface IUser
    {
        public IEnumerable<User> GetAllUser(string FullName, string Email);
        public bool CreateUser(UserRequest users);
        public bool UpdateUser(int id, User users);
        public bool DeleteUser(List<int> ids);
        public User GetUserById(int Id);
        public bool Login(string userName, string password);
    }
}
