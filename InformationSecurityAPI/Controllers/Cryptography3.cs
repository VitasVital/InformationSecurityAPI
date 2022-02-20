using InformationSecurityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InformationSecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cryptography3 : Controller
    {
        public CryptographyContext _db;

        public Cryptography3(CryptographyContext context)
        {
            _db = context;
        }
        
        [HttpPost]
        [Route("[action]")]
        public JsonResult PostFirst(UserSession client)
        {
            User client_password = _db
                .Users
                .FirstOrDefault(c => c.Login == client.Login);
            
            if (client_password is null)
            {
                return new JsonResult("Данный пользователь не зарегистрирован");
            }
            
            UserSession client_old = _db
                .UserSessions
                .FirstOrDefault(c => c.Login == client.Login && c.Password == client.Password && c.IsLogged == true && c.IsDeleted == false);

            if (client_old is null == false)
            {
                return new JsonResult("Вы уже авторизованы");
            }

            DateTime now = DateTime.Now.AddDays(7);
            var md5Hash = MD5.Create();
            var sourceBytes = Encoding.UTF8.GetBytes(now.ToString());
            var hashBytes = md5Hash.ComputeHash(sourceBytes);
            var hash_time = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            
            sourceBytes = Encoding.UTF8.GetBytes(hash_time + client_password.Password);
            hashBytes = md5Hash.ComputeHash(sourceBytes);
            var hash_result = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            
            client.Password = hash_result;
            client.DateLogin = now;
            
            _db.UserSessions.Add(client);
            _db.SaveChanges();
            return new JsonResult(hash_time);
        }
        
        [Route("[action]/{sentText}")]
        [HttpGet]
        public string GetHashText(string sentText)
        {
            var md5Hash = MD5.Create();
            var sourceBytes = Encoding.UTF8.GetBytes(sentText);
            var hashBytes = md5Hash.ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            return hash;
        }
    }
}