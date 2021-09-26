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
    public class InfoSec2 : Controller
    {
        public InfoSec2()
        {
        }
        [HttpPost]
        public JsonResult Post(TextRequest2 textRequest2)
        {
            if (textRequest2.word is null)
            {

                return new JsonResult("Вы не ввели слово");
            }
            else
            {
                Shifrovanie2 shifr = new Shifrovanie2();
                return new JsonResult(shifr.Vigener(textRequest2));
            }
        }
    }
}