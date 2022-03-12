using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InformationSecurityAPI.Models
{
    public class CryptographyModel5
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}