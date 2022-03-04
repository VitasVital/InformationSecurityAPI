using InformationSecurityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace InformationSecurityAPI.Shifrovanie
{
    public class Shifrovanie4 : Controller
    {
        public Shifrovanie4()
        {
        }
        public string ConvertToBinaty(BigInteger number)
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

        

        public TextRequest4 Result_1(TextRequest4 textRequest4)
        {
            BigInteger num; //если не удалочь конвертировать, будет значение num
            bool isNum_a = BigInteger.TryParse(textRequest4.a, out num);
            bool isNum_alpha = BigInteger.TryParse(textRequest4.alpha, out num);
            bool isNum_n = BigInteger.TryParse(textRequest4.n, out num);
            if (!isNum_a || !isNum_alpha || !isNum_n || textRequest4.a[0] == '-' || textRequest4.alpha[0] == '-' || textRequest4.n[0] == '-')
            {
                textRequest4.result_1 = "Вы ввели что-то неправильно";
                return textRequest4;
            }
            BigInteger _a = BigInteger.Parse(textRequest4.a);
            BigInteger _alpha = BigInteger.Parse(textRequest4.alpha);
            BigInteger _n = BigInteger.Parse(textRequest4.n);
            if (_a == 0 || _alpha == 0 || _n == 0)
            {
                textRequest4.result_1 = "Вы ввели что-то неправильно";
                return textRequest4;
            }

            //перевод alpha в двоичный вид
            string binary_alpha = ConvertToBinaty(_alpha);

            List<BigInteger> number = new List<BigInteger>() { _a };
            for (int i = 1; i < binary_alpha.Length; i++)
            {
                number.Add((number[i - 1] * number[i - 1]) % _n);
            }

            BigInteger result = 1;
            for (int i = 0; i < binary_alpha.Length; i++)
            {
                if (binary_alpha[i] == '1')
                {
                    result *= number[i];
                }
            }
            result %= _n;
            textRequest4.result_1 = Convert.ToString(result);

            return textRequest4;
        }

        public TextRequest4 Result_2(TextRequest4 textRequest4)
        {
            BigInteger num; //если не удалочь конвертировать, будет значение num
            bool isNum_A = BigInteger.TryParse(textRequest4._A, out num);
            bool isNum_B = BigInteger.TryParse(textRequest4._B, out num);
            if (!isNum_A || !isNum_B || textRequest4._A[0] == '-' || textRequest4._B[0] == '-')
            {
                textRequest4.result_2_x = "Вы ввели что-то неправильно";
                textRequest4.result_2_y = "Вы ввели что-то неправильно";
                textRequest4.result_2_nod = "Вы ввели что-то неправильно";
                return textRequest4;
            }
            BigInteger a = BigInteger.Parse(textRequest4._A);
            BigInteger b = BigInteger.Parse(textRequest4._B);

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
            textRequest4.result_2_x = Convert.ToString(x);
            textRequest4.result_2_y = Convert.ToString(y);
            textRequest4.result_2_nod = Convert.ToString(x * a + y * b);

            return textRequest4;
        }
    }
}
