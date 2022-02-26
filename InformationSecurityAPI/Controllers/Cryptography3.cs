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
    public class Cryptography3 : Controller
    {
        private Shifrovanie5 shifrovanie5;
        public Cryptography3()
        {
            shifrovanie5 = new Shifrovanie5();
        }

        public BigInteger GenerateNumber(int bitCount)
        {
            while (true)
            {
                var rng = new RNGCryptoServiceProvider();
                byte[] bytes = new byte[bitCount / 8];
                rng.GetBytes(bytes);
                BigInteger p = new BigInteger(bytes);
                if (p < 0)
                {
                    continue;
                }

                if (shifrovanie5.TestSoloveyStrassen(p) == "Вероятно простое")
                {
                    return p;
                }
            }
        }
        
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetA()
        {
            BigInteger a = GenerateNumber(64);
            BigInteger g = GenerateNumber(64);
            BigInteger p = GenerateNumber(512);
            BigInteger A = shifrovanie5.VozvedenieStepenPoModulu(g, a, p);
            var response = new { mainA = A.ToString(), g = g.ToString(), p = p.ToString(), a = a.ToString() };
            return Json(response);
        }
        
        [HttpPost]
        [Route("[action]")]
        public IActionResult GetB(CryptographyModel3 res)
        {
            BigInteger b = GenerateNumber(64);
            BigInteger bigint_A = BigInteger.Parse(res.A);
            BigInteger bigint_g = BigInteger.Parse(res.g);
            BigInteger bigint_p = BigInteger.Parse(res.p);
            BigInteger B = shifrovanie5.VozvedenieStepenPoModulu(bigint_g, b, bigint_p);
            var response = new { mainB = B.ToString(), b = b.ToString() };
            return Json(response);
        }
        
        [HttpPost]
        [Route("[action]")]
        public IActionResult GetK(CryptographyModel3 res)
        {
            BigInteger bigint_A = BigInteger.Parse(res.A);
            BigInteger bigint_g = BigInteger.Parse(res.g);
            BigInteger bigint_p = BigInteger.Parse(res.p);
            BigInteger K = shifrovanie5.VozvedenieStepenPoModulu(bigint_A, bigint_g, bigint_p);
            var response = new { K = K.ToString() };
            return Json(response);
        }
    }
}