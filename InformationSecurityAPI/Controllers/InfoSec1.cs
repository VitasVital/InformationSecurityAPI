﻿using InformationSecurityAPI.Shifrovanie;
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

        [HttpGet]
        public JsonResult Get(string resp, int key)
        {
            if (resp is null)
            {

                return new JsonResult("Вы не ввели слово");
            }
            else
            {
                Shifrovanie1 shifr = new Shifrovanie1();
                return new JsonResult(shifr.Caesar(resp, key));
            }
        }
        [HttpPost]
        public JsonResult Post(TextRequest textRequest)
        {
            if (textRequest.resp is null)
            {

                return new JsonResult("Вы не ввели слово" + textRequest.resp + textRequest.key);
            }
            else
            {
                Shifrovanie1 shifr = new Shifrovanie1();
                return new JsonResult(shifr.Caesar(textRequest.resp, textRequest.key));
            }
        }
    }
}