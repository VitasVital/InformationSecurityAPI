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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InformationSecurityAPI.Shifrovanie;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InformationSecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cryptography5 : Controller
    {
        private Shifrovanie6 _shifrovanie6;
        public Cryptography5()
        {
            _shifrovanie6 = new Shifrovanie6();
        }
        
        [HttpPost]
        [Route("[action]")]
        public IActionResult MD5hashFile([FromForm] CryptographyModel5 file)
        {
            try
            {
                var md5Hash = MD5.Create();
                var sourceBytes = Encoding.UTF8.GetBytes(file.FormFile.ToString());
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return Json(hash);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPost]
        [Route("[action]")]
        public IActionResult MD5hashFileRSAclient([FromForm] CryptographyModel5 file)
        {
            try
            {
                TextRequest6 textRequest6 = new TextRequest6();
                textRequest6.bit_count = "128";
                textRequest6.input_text = file.FileHash;
                
                _shifrovanie6.Result_1(textRequest6);
                return Json(textRequest6);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPost]
        [Route("[action]")]
        public IActionResult MD5hashFileRSAserver([FromForm] CryptographyModel5 file)
        {
            try
            {
                var md5Hash = MD5.Create();
                var sourceBytes = Encoding.UTF8.GetBytes(file.FormFile.ToString());
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                
                TextRequest6 textRequest6 = new TextRequest6();
                
                textRequest6.cryptogram = file.result_1;
                textRequest6.input_d = file.d;
                textRequest6.input_n = file.n;
                _shifrovanie6.Result_2(textRequest6);

                if (textRequest6.result_2 == hash)
                {
                    return Json("Успешно");
                }
                return Json("Не успешно");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        // [HttpPost]
        // [Route("[action]")]
        // public IActionResult PostFile([FromForm] CryptographyModel5 file)
        // {
        //     try
        //     {
        //         string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);
        //         
        //         using (Stream stream = new FileStream(path, FileMode.Create))
        //         {
        //             file.FormFile.CopyTo(stream);
        //             
        //             var md5Hash = MD5.Create();
        //             var sourceBytes = Encoding.UTF8.GetBytes(file.FormFile.ToString());
        //             var hashBytes = md5Hash.ComputeHash(sourceBytes);
        //             var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        //             return Json(hash);
        //         }
        //         return StatusCode(StatusCodes.Status200OK);
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode(StatusCodes.Status500InternalServerError);
        //     }
        // }
    }
}