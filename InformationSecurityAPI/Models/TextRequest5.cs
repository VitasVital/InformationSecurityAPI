using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSecurityAPI.Models
{
    public class TextRequest5
    {
        public int number_result { get; set; }
        public string n { get; set; }
        public string MillerRabin { get; set; }
        public string Farm { get; set; }
        public string SoloveyStrassen { get; set; }
        public int test_number { get; set; }
        public string bit_number { get; set; }
        public string generated_number { get; set; }
    }
}
