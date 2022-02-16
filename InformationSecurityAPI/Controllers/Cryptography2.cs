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
    public class Cryptography2 : Controller
    {
        public CryptographyContext _db;

        public Cryptography2(CryptographyContext context)
        {
            _db = context;
        }
        
        [HttpPost]
        [Route("[action]")]
        public JsonResult PostFirst(UserSession client)
        {
            var md5Hash = MD5.Create();
            var sourceBytes = Encoding.UTF8.GetBytes(client.Password);
            var hashBytes = md5Hash.ComputeHash(sourceBytes);
            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            client.Password = hash;
            
            User _client = _db
                .Users
                .FirstOrDefault(c => c.Login == client.Login && c.Password == client.Password);
            
            if (_client is null)
            {
                return new JsonResult("Данный пользователь не зарегистрирован");
            }
            
            UserSession _client_old = _db
                .UserSessions
                .FirstOrDefault(c => c.Login == client.Login && c.Password == client.Password && c.IsLogged == false && c.IsDeleted == false);
            if (_client_old is null == false)
            {
                _client_old.IsDeleted = true;
            }
            
            client.DateLogin = DateTime.Now.AddDays(7);
            
            _db.UserSessions.Add(client);
            _db.SaveChanges();
            return new JsonResult(client);
        }
        
        [HttpPost]
        [Route("[action]")]
        public JsonResult PostFinish(UserSession client)
        {
            UserSession _client = _db
                .UserSessions
                .FirstOrDefault(c => c.Login == client.Login && c.Password == client.Password && c.IsLogged == false && c.IsDeleted == false);
            
            if (_client is null)
            {
                return new JsonResult("Данный пользователь не пытался авторизоваться");
            }

            if (_client.DateLogin > DateTime.Now)
            {
                _client.IsLogged = true;
                _client.IsDeleted = true;
                _db.SaveChanges();
                return new JsonResult("Авторизация успешно завершилась");
            }
            
            _client.IsLogged = false;
            _client.IsDeleted = true;
            _db.SaveChanges();
            return new JsonResult("Вы не успели авторизоваться");
        }
    }
}