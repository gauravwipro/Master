using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Flowsoft.DataServices.Interfaces;
using Flowsoft.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Flowsoft.Hms.Controllers
{
    [Produces("application/json")]
    [EnableCors("CORS")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _config;
        public UsersController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }
        [HttpPost]
        [Route("api/users/authenticate")]
        public User Authenticate(string username, string password)
        {
            User user = new User();
            var users = _userService.Authenticate(username, password);

            // return null if user not found
            if (users == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["AppSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.Id.ToString()),
                    new Claim(ClaimTypes.Role, users.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Role = users.Role.Name;
            user.FirstName = users.FirstName;
            user.LastName = users.LastName;
            // remove password before returning
            user.Password = null;
            user.Id = users.DoctorId.HasValue ? users.DoctorId.Value : user.Id;
            return user;
        }


    }
}
