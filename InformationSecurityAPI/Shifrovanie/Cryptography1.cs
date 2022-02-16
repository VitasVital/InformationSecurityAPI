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

namespace InformationSecurityAPI.Shifrovanie
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
            
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(client.Password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                client.Password = sb.ToString();
            }
            
            _db.Users.Add(client);
            _db.SaveChanges();
            return new JsonResult("Успешная регистрация");
        }
    }
}
