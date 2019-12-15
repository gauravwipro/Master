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
using Flowsoft.Repository.interfaces;
namespace Flowsoft.DataServices.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Users Authenticate(string username, string password)
        {
            var user = _userRepository.Get().SingleOrDefault(x => x.Username == username && x.Password == password);
            if (user != null)
                user.Role = user.Role;
            return user;
        }

        public IEnumerable<Users> GetAll()
        {
            return _userRepository.Get();
        }
        public Users GetById(int id)
        {
            var user = _userRepository.Get().FirstOrDefault(x => x.Id == id);
            // return user without password
            if (user != null)
                user.Password = null;
            return user;
        }
    }
}
