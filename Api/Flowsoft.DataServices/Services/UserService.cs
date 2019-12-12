using Flowsoft.Hms.Database;
using Flowsoft.DataServices.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Flowsoft.Domain.Models;
using Flowsoft.Data;

namespace Flowsoft.DataServices.Services
{
    public class UserService : IUserService
    {
        IDataContext dataContext;
        public UserService(IDataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public Users Authenticate(string username, string password)
        {
            var user = dataContext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if (user != null)
                user.Role = dataContext.Roles.SingleOrDefault(x => x.Id == user.RoleId);
            return user;
        }

        public IEnumerable<Users> GetAll()
        {
            var user = dataContext.Users.ToList();

            return user;
        }

        public Users GetById(int id)
        {
            var user = dataContext.Users.FirstOrDefault(x => x.Id == id);

            // return user without password
            if (user != null)
                user.Password = null;

            return user;
        }
    }
}
