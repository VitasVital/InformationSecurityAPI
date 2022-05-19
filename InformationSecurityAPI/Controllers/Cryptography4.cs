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
using InformationSecurityAPI.Shifrovanie;
using Microsoft.EntityFrameworkCore;

namespace InformationSecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cryptography4 : Controller
    {
        public Cryptography4()
        {
        }
        
        [HttpPost]
        [Route("[action]")]
        public IActionResult EncryptionRC4(CryptographyModel4 res)
        {
            byte[] key = ASCIIEncoding.ASCII.GetBytes(res.K);

            RC4 encoder = new RC4(key);
            byte[] testBytes = ASCIIEncoding.ASCII.GetBytes(res.Message);
            byte[] result = encoder.Encode(testBytes, testBytes.Length);

            RC4 decoder = new RC4(key);
            byte[] decryptedBytes = decoder.Decode(result, result.Length);
            string decryptedString = ASCIIEncoding.ASCII.GetString(decryptedBytes);
            var response = new 
            {
                cryptoMessage = result,
                decryptedMessage = res.Message
            };
            return Json(response);
        }
    }
}