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
    public class InfoSec1 : Controller
    {
        public InfoSec1()
        {
        }

        [HttpGet]
        public JsonResult Get(string resp, int key)
        {
            //return new JsonResult(_db.Vacancies.ToList());
            if (resp is null)
            {

                return new JsonResult("Вы не ввели слово");
            }
            else
            {
                Shifrovanie1 shifr = new Shifrovanie1();
                return new JsonResult(shifr.Caesar(resp, key));
            }
            //return new JsonResult("dsfsdf");
        }
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    return new JsonResult("dsfsdf");
        //}
        [HttpPost]
        public JsonResult Post(string resp, int key)
        {
            if (resp is null)
            {

                return new JsonResult("Вы не ввели слово" + resp + key);
            }
            else
            {
                Shifrovanie1 shifr = new Shifrovanie1();
                return new JsonResult(shifr.Caesar(resp, key));
            }
        }
    }
}