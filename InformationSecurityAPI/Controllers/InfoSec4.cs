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
    public class InfoSec4 : Controller
    {
        public InfoSec4()
        {
        }
        [HttpPost]
        public JsonResult Post(TextRequest4 textRequest4)
        {
            if (textRequest4.number_result == 1)
            {
                if (textRequest4.a == "" || textRequest4.alpha == "" || textRequest4.n == "")
                {
                    textRequest4.result_1 = "Что-то не заполнено";
                    return new JsonResult(textRequest4);
                }
                else
                {
                    Shifrovanie4 shifr = new Shifrovanie4();
                    return new JsonResult(shifr.Result_1(textRequest4));
                }
            }
            else if (textRequest4.number_result == 2)
            {
                if (textRequest4.A == "" || textRequest4.B == "")
                {
                    textRequest4.result_2_nod = "Что-то не заполнено";
                    return new JsonResult(textRequest4);
                }
                else
                {
                    Shifrovanie4 shifr = new Shifrovanie4();
                    return new JsonResult(shifr.Result_2(textRequest4));
                }
            }
            else
            {
                return new JsonResult(textRequest4);
            }
        }
    }
}
