using DAL;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using DAL.Helper;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL
{
    public partial class UserBLL : IUserBLL
    {
        private IUserDAL _res;
        private string Secret;
        public UserBLL(IUserDAL res, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = res;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public User Authenticate(string username, string password)
        {
            var user = _res.GetUser(username, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.hoten.ToString()),
                    new Claim(ClaimTypes.Role, user.role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user;

        }

        public User GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(User model)
        {
            return _res.Create(model);
        }
        public bool Update(User model)
        {
            return _res.Update(model);
        }
        public List<User> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
        {
            return _res.Search(pageIndex, pageSize, out total, hoten, taikhoan);
        }
    }

}
