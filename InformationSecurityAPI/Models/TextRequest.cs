using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSecurityAPI.Models
{
    public class TextRequest
    {
        public string word { get; set; }
        public string key { get; set; }
        public int language { get; set; }
        public bool is_cryptogram { get; set; }
    }
}
