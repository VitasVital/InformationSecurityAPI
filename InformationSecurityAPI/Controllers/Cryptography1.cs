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
    public class Cryptography1 : Controller
    {
        public CryptographyContext _db;

        public Cryptography1(CryptographyContext context)
        {
            _db = context;
        }
        
        [HttpPost]
        public JsonResult Post(User client)
        {
            User _client = _db
                .Users
                .FirstOrDefault(c => c.Login == client.Login);
            
            if (_client is null == false)
            {
                return new JsonResult("Данный пользователь уже зарегистрирован");
            }
            
            var md5Hash = MD5.Create();
            var sourceBytes = Encoding.UTF8.GetBytes(client.Password);
            var hashBytes = md5Hash.ComputeHash(sourceBytes);
            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            client.Password = hash;
            
            _db.Users.Add(client);
            _db.SaveChanges();
            return new JsonResult("Успешная регистрация");
        }
    }
}
