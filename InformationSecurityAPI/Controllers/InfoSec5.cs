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
    public class InfoSec5 : Controller
    {
        public InfoSec5()
        {
        }
        [HttpPost]
        public JsonResult Post(TextRequest5 textRequest5)
        {
            if (textRequest5.number_result == 1)
            {
                if (textRequest5.n == "")
                {
                    textRequest5.MillerRabin = "Заполни n";
                    textRequest5.Farm = "Заполни n";
                    textRequest5.SoloveyStrassen = "Заполни n";
                    return new JsonResult(textRequest5);
                }
                else
                {
                    Shifrovanie5 shifr = new Shifrovanie5();
                    return new JsonResult(shifr.Result_1(textRequest5));
                }
            }
            else if (textRequest5.number_result == 2)
            {
                if (textRequest5.bit_number == "")
                {
                    textRequest5.generated_number = "Что-то не заполнено";
                    return new JsonResult(textRequest5);
                }
                else
                {
                    Shifrovanie5 shifr = new Shifrovanie5();
                    return new JsonResult(shifr.Result_2(textRequest5));
                }
            }
            else
            {
                return new JsonResult(textRequest5);
            }
        }
    }
}
