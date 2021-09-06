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
        public JsonResult Get()
        {
            //return new JsonResult(_db.Vacancies.ToList());
            return new JsonResult("dsfsdf");
        }
        [HttpPost]
        public JsonResult Post(string resp, int key)
        {
            if (resp is null)
            {

                return new JsonResult("Вы не ввели число");
            }
            else
            {
                Shifrovanie1 shifr = new Shifrovanie1();
                return new JsonResult(shifr.Caesar(resp, key));
            }
        }
    }
}