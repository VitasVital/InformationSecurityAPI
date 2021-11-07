using InformationSecurityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace InformationSecurityAPI.Shifrovanie
{
    public class Shifrovanie5
    {
        public Shifrovanie5()
        {
        }

        private string ConvertToBinaty(BigInteger number)
        {
            string binary_letter = "";
            if (number == 0)
            {
                return "0";
            }
            while (number >= 1)
            {
                binary_letter += Convert.ToString(number % 2);
                number /= 2;
            }
            return binary_letter;
        }

        public BigInteger VozvedenieStepenPoModulu(BigInteger a, BigInteger alpha, BigInteger n)
        {
            //перевод alpha в двоичный вид
            string binary_alpha = this.ConvertToBinaty(alpha);

            List<BigInteger> number = new List<BigInteger>() { a };
            for (int i = 1; i < binary_alpha.Length; i++)
            {
                number.Add((number[i - 1] * number[i - 1]) % n);
            }

            BigInteger result = 1;
            for (int i = 0; i < binary_alpha.Length; i++)
            {
                if (binary_alpha[i] == '1')
                {
                    result *= number[i];
                }
            }

            result %= n;

            return result;
        }

        private string TestMillerRabin(BigInteger _n)
        {
            return "text";
        }

        private string TestFarm(BigInteger _n)
        {
            BigInteger res = this.VozvedenieStepenPoModulu(3, _n - 1, _n);
            if (res == 1)
            {
                return "Вероятно простое";
            }
            else
            {
                return "Составное";
            }
        }
        private string TestSoloveyStrassen(BigInteger _n)
        {
            return "text";
        }

        public TextRequest5 Result_1(TextRequest5 textRequest5)
        {
            BigInteger num; //если не удалочь конвертировать, будет значение num
            bool isNum_n = BigInteger.TryParse(textRequest5.n, out num);
            if (!isNum_n || textRequest5.n[0] == '-')
            {
                textRequest5.MillerRabin = "Вы ввели что-то неправильно";
                textRequest5.SoloveyStrassen = "Вы ввели что-то неправильно";
                textRequest5.Farm = "Вы ввели что-то неправильно";
                return textRequest5;
            }
            BigInteger _n = BigInteger.Parse(textRequest5.n);
            if (_n == 0)
            {
                textRequest5.MillerRabin = "Вы ввели что-то неправильно";
                textRequest5.SoloveyStrassen = "Вы ввели что-то неправильно";
                textRequest5.Farm = "Вы ввели что-то неправильно";
                return textRequest5;
            }

            switch(textRequest5.test_number_1)
            {
                case 1:
                    textRequest5.MillerRabin = this.TestMillerRabin(_n);
                    break;
                case 2:
                    textRequest5.SoloveyStrassen = this.TestSoloveyStrassen(_n);
                    break;
                case 3:
                    textRequest5.Farm = this.TestFarm(_n);
                    break;
                default:
                    break;
            }

            return textRequest5;
        }
        public TextRequest5 Result_2(TextRequest5 textRequest5)
        {
            return textRequest5;
        }
    }
}
