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
    public class InfoSec6 : Controller
    {
        public InfoSec6()
        {
        }
        [HttpPost]
        public JsonResult Post(TextRequest6 textRequest6)
        {
            if (textRequest6.number_result == 1)
            {
                if (textRequest6.bit_count == "" || textRequest6.input_text == "")
                {
                    textRequest6.result_1 = "Что-то не заполнено";
                    return new JsonResult(textRequest6);
                }
                Shifrovanie6 shifr = new Shifrovanie6();
                return new JsonResult(shifr.Result_1(textRequest6));
            }
            if (textRequest6.number_result == 2)
            {
                if (textRequest6.cryptogram == "" || textRequest6.input_d == "" || textRequest6.input_n == "")
                {
                    textRequest6.result_2 = "Что-то не заполнено";
                    return new JsonResult(textRequest6);
                }
                Shifrovanie6 shifr = new Shifrovanie6();
                return new JsonResult(shifr.Result_2(textRequest6));
            }
            return new JsonResult(textRequest6);
        }
    }
}