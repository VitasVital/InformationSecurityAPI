using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSecurityAPI.Models
{
    public class TextRequest3
    {
        public string word { get; set; }
        public string key { get; set; }
        public bool is_generated_key { get;set;}
        public string word_binary { get; set; }
        public string key_binary { get; set; }
        public string word_result_binary { get; set; }
        public string word_result { get; set; }
    }
}
