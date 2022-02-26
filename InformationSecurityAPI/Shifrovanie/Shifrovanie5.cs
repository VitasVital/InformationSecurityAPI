using InformationSecurityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
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
            List<BigInteger[]> list = new List<BigInteger[]>();
            list.Add(new BigInteger[6]);
            list[0][0] = a;
            list[0][1] = b;

            list[0][2] = a % b;
            list[0][3] = a / b;

            int ind = 0;
            while (list[ind][2] != 0)
            {
                ind += 1;

                list.Add(new BigInteger[6]);

                list[ind][0] = list[ind - 1][1];
                list[ind][1] = list[ind - 1][2];

                list[ind][2] = list[ind][0] % list[ind][1];
                list[ind][3] = list[ind][0] / list[ind][1];
            }

            list[ind][4] = 0;
            list[ind][5] = 1;
            while (ind != 0)
            {
                ind -= 1;

                list[ind][4] = list[ind + 1][5];
                list[ind][5] = list[ind + 1][4] - list[ind + 1][5] * list[ind][3];
            }

            BigInteger x = list[ind][4], y = list[ind][5];
            return x * a + y * b;
        }

        public BigInteger Yacobi(BigInteger a, BigInteger b)
        {
            int r = 1;
            while (a != 0)
            {
                int t = 0;
                while ((a & 1) == 0)
                {
                    t++;
                    a >>= 1;
                }
                if ((t & 1) !=0)
                {
                    BigInteger temp = b % 8;
                    if (temp == 3 || temp == 5)
                    {
                        r = -r;
                    }
                }
                BigInteger a4 = a % 4, b4 = b % 4;
                if (a4 == 3 && b4 == 3)
                {
                    r = -r;
                }
                BigInteger c = a;
                a = b % c;
                b = c;
            }
            return r;
        }
        
        public string TestMillerRabin(BigInteger _n)
        {
            double k = BigInteger.Log(_n);
            
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
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                byte[] _a = new byte[_n.ToByteArray().LongLength];

                BigInteger a;

                do
                {
                    rng.GetBytes(_a);
                    a = new BigInteger(_a);
                }
                while (a < 2 || a >= _n - 2);

                BigInteger x = VozvedenieStepenPoModulu(a, t, _n);

                if (x == 1 || x == _n - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = VozvedenieStepenPoModulu(x, 2, _n);

                    if (x == 1)
                        return "Составное";

                    if (x == _n - 1)
                        break;
                }

                if (x != _n - 1)
                    return "Составное";
            }

            return "Вероятно простое";
        }

        public string TestFarm(BigInteger _n)
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

            BigInteger res = VozvedenieStepenPoModulu(a, _n - 1, _n);

            if (res == 1)
            {
                return "Вероятно простое";
            }
            
            return "Составное";
        }
        public string TestSoloveyStrassen(BigInteger _n)
        {
            double k = BigInteger.Log(_n); //количество раундов
            
            if (_n == 2 || _n == 3)
            {
                return "Вероятно простое";
            }
            if (_n % 2 == 0)
            {
                return "Составное";
            }

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

                BigInteger d = NOD(a, _n);

                if (d > 1)
                {
                    return "Составное";
                }
                
                BigInteger vozvedenieStepenPoModulu = VozvedenieStepenPoModulu(a, (_n - 1) / 2, _n);

                BigInteger yacobi = Yacobi(a, _n);

                if (yacobi < 0)
                {
                    yacobi = _n - 1;
                }

                if (vozvedenieStepenPoModulu != yacobi || yacobi == 0)
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
            
            textRequest5.MillerRabin = TestMillerRabin(_n);
            textRequest5.SoloveyStrassen = TestSoloveyStrassen(_n);
            textRequest5.Farm = TestFarm(_n);

            return textRequest5;
        }
        public TextRequest5 Result_2(TextRequest5 textRequest5)
        {
            int num; //если не удалочь конвертировать, будет значение num
            bool isNum_n = int.TryParse(textRequest5.bit_number, out num);
            if (!isNum_n || textRequest5.bit_number[0] == '-')
            {
                textRequest5.generated_number = "Вы ввели что-то неправильно";
                return textRequest5;
            }
            int _n = int.Parse(textRequest5.bit_number);
            if (_n < 2)
            {
                textRequest5.generated_number = "Вы ввели что-то неправильно";
                return textRequest5;
            }
            

            if (textRequest5.test_number == 1)
            {
                while (true)
                {
                    var rng = new RNGCryptoServiceProvider();
                    byte[] bytes = new byte[_n / 8];
                    rng.GetBytes(bytes);
                    BigInteger p = new BigInteger(bytes);
                    if (p < 0)
                    {
                        continue;
                    }
                    
                    if (TestMillerRabin(p) == "Вероятно простое")
                    {
                        textRequest5.generated_number = Convert.ToString(p);
                        break;
                    }
                }
            }
            else if (textRequest5.test_number == 2)
            {
                while (true)
                {
                    var rng = new RNGCryptoServiceProvider();
                    byte[] bytes = new byte[_n / 8];
                    rng.GetBytes(bytes);
                    BigInteger p = new BigInteger(bytes);
                    if (p < 0)
                    {
                        continue;
                    }
                    
                    if (TestSoloveyStrassen(p) == "Вероятно простое")
                    {
                        textRequest5.generated_number = Convert.ToString(p);
                        break;
                    }
                }
            }
            else if(textRequest5.test_number == 3)
            {
                while (true)
                {
                    var rng = new RNGCryptoServiceProvider();
                    byte[] bytes = new byte[_n / 8];
                    rng.GetBytes(bytes);
                    BigInteger p = new BigInteger(bytes);
                    if (p < 0)
                    {
                        continue;
                    }
                    
                    if (TestFarm(p) == "Вероятно простое")
                    {
                        textRequest5.generated_number = Convert.ToString(p);
                        break;
                    }
                }
            }
            
            return textRequest5;
        }
    }
}
