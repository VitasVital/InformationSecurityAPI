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
        public string FileHash { get; set; }
        public string result_1 { get; set; }
        public string d { get; set; }
        public string n { get; set; }
        public IFormFile FormFile { get; set; }
    }
}