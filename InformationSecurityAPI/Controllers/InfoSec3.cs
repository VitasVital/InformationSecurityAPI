using InformationSecurityAPI.Models;
using InformationSecurityAPI.Shifrovanie;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoSec3 : Controller
    {
        public InfoSec3()
        {
        }
        [HttpPost]
        public JsonResult Post(TextRequest3 textRequest3)
        {
            if (textRequest3.word is null || textRequest3.key is null)
            {

                return new JsonResult("Вы не ввели слово или ключ");
            }
            else
            {
                Shifrovanie3 shifr = new Shifrovanie3();
                return new JsonResult(shifr.Gamming(textRequest3));
            }
        }
    }
}
