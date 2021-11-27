using InformationSecurityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
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

        public BigInteger NOD(BigInteger a, BigInteger b)
        {
            BigInteger p = 1, q = 0, r = 0, s = 1, x, y;
            while (a > 0 && b > 0)
            {
                if (a >= b)
                {
                    a = a - b;
                    p = p - r;
                    q = q - s;
                }
                else
                {
                    b = b - a;
                    r = r - p;
                    s = s - q;
                }
            }
            if (a > 0)
            {
                x = p;
                y = q;
                return a;
            }
            else
            {
                x = r;
                y = s;
                return b;
            }
        }

        private string TestMillerRabin(BigInteger _n)
        {
            int k = 5; //количество раундов
            if (_n == 2 || _n == 3)
            {
                return "Вероятно простое";
            }
            if (_n % 2 == 0)
            {
                return "Составное";
            }

            // представим n − 1 в виде (2^s)·t, где t нечётно, это можно сделать последовательным делением n - 1 на 2
            BigInteger t = _n - 1;
            int s = 0;
            while (t % 2 == 0)
            {
                t /= 2;
                s += 1;
            }

            for (int i = 0; i < k; i++)
            {
                // выберем случайное целое число a в отрезке [2, n − 2]
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                byte[] _a = new byte[_n.ToByteArray().LongLength];

                BigInteger a;

                do
                {
                    rng.GetBytes(_a);
                    a = new BigInteger(_a);
                }
                while (a < 2 || a >= _n - 2);

                BigInteger x = this.VozvedenieStepenPoModulu(a, t, _n);

                // если x == 1 или x == n − 1, то перейти на следующую итерацию цикла
                if (x == 1 || x == _n - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    // x ← x^2 mod n
                    x = this.VozvedenieStepenPoModulu(x, 2, _n);

                    // если x == 1, то вернуть "составное"
                    if (x == 1)
                        return "Составное";

                    // если x == n − 1, то перейти на следующую итерацию внешнего цикла
                    if (x == _n - 1)
                        break;
                }

                if (x != _n - 1)
                    return "Составное";
            }

            return "Вероятно простое";
        }

        private string TestFarm(BigInteger _n)
        {
            if (_n == 2 || _n == 3)
            {
                return "Простое";
            }
            if (_n % 2 == 0)
            {
                return "Составное";
            }

            // выберем случайное целое число a в отрезке [2, n − 2]
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            byte[] _a = new byte[_n.ToByteArray().LongLength];

            BigInteger a;

            do
            {
                rng.GetBytes(_a);
                a = new BigInteger(_a);
            }
            while (a < 2 || a >= _n - 2);

            BigInteger res = this.VozvedenieStepenPoModulu(a, _n - 1, _n);

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
            int k = 5; //количество раундов

            for (int i = 1; i < k; i++)
            {
                // выберем случайное целое число a в отрезке [2, n − 2]
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                byte[] _a = new byte[_n.ToByteArray().LongLength];

                BigInteger a;

                do
                {
                    rng.GetBytes(_a);
                    a = new BigInteger(_a);
                }
                while (a < 2 || a >= _n - 2);

                if (this.NOD(a, _n) != 1)
                {
                    return "Составное";
                }

                BigInteger vozvedenieStepenPoModulu = this.VozvedenieStepenPoModulu(a, (_n - 1) / 2, _n);

                if (vozvedenieStepenPoModulu != 1 && vozvedenieStepenPoModulu != -1)
                {
                    return "Составное";
                }
            }

            return "Вероятно простое";
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
            if (_n < 2)
            {
                textRequest5.MillerRabin = "Вы ввели что-то неправильно";
                textRequest5.SoloveyStrassen = "Вы ввели что-то неправильно";
                textRequest5.Farm = "Вы ввели что-то неправильно";
                return textRequest5;
            }
            
            textRequest5.MillerRabin = this.TestMillerRabin(_n);
            textRequest5.SoloveyStrassen = this.TestSoloveyStrassen(_n);
            textRequest5.Farm = this.TestFarm(_n);

            return textRequest5;
        }
        public TextRequest5 Result_2(TextRequest5 textRequest5)
        {
            BigInteger num; //если не удалочь конвертировать, будет значение num
            bool isNum_n = BigInteger.TryParse(textRequest5.bit_number, out num);
            if (!isNum_n || textRequest5.bit_number[0] == '-')
            {
                textRequest5.generated_number = "Вы ввели что-то неправильно";
                return textRequest5;
            }
            BigInteger _n = BigInteger.Parse(textRequest5.bit_number);
            if (_n < 2)
            {
                textRequest5.generated_number = "Вы ввели что-то неправильно";
                return textRequest5;
            }
            
            BigInteger result = 1;
            BigInteger result_2 = 1;
            for (BigInteger i = 0; i < _n - 1; i++)
            {
                result *= 2;
                result_2 *= 2;
            }
            result_2 *= 2;
            result_2 -= 1;

            if (textRequest5.test_number == 1)
            {
                while (result < result_2)
                {
                    if (this.TestMillerRabin(result_2) == "Вероятно простое")
                    {
                        textRequest5.generated_number = Convert.ToString(result_2);
                        break;
                    }
                    result_2 -= 2;
                }
            }
            else if (textRequest5.test_number == 2)
            {
                while (result < result_2)
                {
                    if (this.TestSoloveyStrassen(result_2) == "Вероятно простое")
                    {
                        textRequest5.generated_number = Convert.ToString(result_2);
                        break;
                    }
                    result_2 -= 2;
                }
            }
            else if(textRequest5.test_number == 3)
            {
                while (result < result_2)
                {
                    if (this.TestFarm(result_2) == "Вероятно простое")
                    {
                        textRequest5.generated_number = Convert.ToString(result_2);
                        break;
                    }
                    result_2 -= 2;
                }
            }
            
            return textRequest5;
        }
    }
}
