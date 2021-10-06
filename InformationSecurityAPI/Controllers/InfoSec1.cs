using InformationSecurityAPI.Shifrovanie;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationSecurityAPI.Models;

namespace InformationSecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoSec1 : Controller
    {
        public InfoSec1()
        {
        }
        [HttpPost]
        public JsonResult Post(TextRequest2 textRequest2)
        {
            if (textRequest2.word is null || textRequest2.key is null)
            {

                return new JsonResult("Вы не ввели слово или ключ");
            }
            else
            {
                Shifrovanie1 shifr = new Shifrovanie1();
                return new JsonResult(shifr.Caesar(textRequest2));
            }
        }
    }
}