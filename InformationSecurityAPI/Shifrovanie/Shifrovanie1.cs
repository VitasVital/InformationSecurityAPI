using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSecurityAPI.Shifrovanie
{
    public class Shifrovanie1
    {
        List<string> letter;
        List<string> letter1;
        public Shifrovanie1()
        {
            this.letter = new List<string>() 
            { 
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",

                "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", 
                "З", "И", "Й", "К", "Л", "М", "Н", "О", 
                "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", 
                "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" ,

                "а", "б", "в", "г", "д", "е", "ё", "ж",
                "з", "и", "й", "к", "л", "м", "н", "о",
                "п", "р", "с", "т", "у", "ф", "х", "ц", "ч",
                "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я",

                "A", "B", "C", "D", "E", "F", "G", "H", "I",
                "J", "K", "L", "M", "N", "O", "P", "Q", "R",
                "S", "T", "U", "V", "W", "X", "Y", "Z",

                "a", "b", "c", "d", "e", "f", "g", "h", "i",
                "j", "k", "l", "m", "n", "o", "p", "q", "r",
                "s", "t", "u", "v", "w", "x", "y", "z"
            };

            this.letter1 = new List<string>()
            {
                "z" ,"y" ,"x" ,"w" ,"v" ,"u" ,"t" ,"s"
                ,"r" ,"q" ,"p" ,"o" ,"n" ,"m" ,"l" ,"k" ,"j"
                ,"i" ,"h" ,"g" ,"f" ,"e" ,"d" ,"c" ,"b" ,"a",

                "Z" ,"Y" ,"X" ,"W" ,"V" ,"U" ,"T" ,"S","R" ,
                "Q" ,"P" ,"O" ,"N" ,"M" ,"L" ,"K" ,"J",
                "I" ,"H" ,"G" ,"F" ,"E" ,"D" ,"C" ,"B" ,"A",
                
                "я" ,"ю" ,"э" ,"ь" ,"ы" ,"ъ" ,"щ" ,"ш",
                "ч" ,"ц" ,"х" ,"ф" ,"у" ,"т" ,"с" ,"р" ,"п",
                "о" ,"н" ,"м" ,"л" ,"к" ,"й" ,"и" ,"з",
                "ж" ,"ё" ,"е" ,"д" ,"г" ,"в" ,"б" ,"а",
                
                "Я" ,"Ю" ,"Э" ,"Ь" ,"Ы" ,"Ъ" ,"Щ" ,"Ш",
                "Ч" ,"Ц" ,"Х" ,"Ф" ,"У" ,"Т" ,"С" ,"Р" ,"П",
                "О" ,"Н" ,"М" ,"Л" ,"К" ,"Й" ,"И" ,"З",
                "Ж" ,"Ё" ,"Е" ,"Д" ,"Г" ,"В" ,"Б" ,"А",
                
                "9" ,"8" ,"7" ,"6" ,"5" ,"4" ,"3" ,"2" ,"1" ,"0"
            };
        }

        public string Caesar(string word, int key)
        {
            List<string> letters;
            if (key < 0)
            {
                key *= -1;
                letters = letter1;
            }
            else
            {
                letters = letter;
            }
            key %= letters.Count;
            string new_word = "";
            for (int i = 0; i < word.Length; i++)
            {
                string let = Convert.ToString(word[i]);
                if (!letters.Contains(let))
                {
                    new_word += let;
                    continue;
                }
                if (letters.IndexOf(let) + key >= letters.Count)
                {
                    new_word += letters[letters.IndexOf(let) + key - letters.Count];
                }
                else
                {
                    new_word += letters[letters.IndexOf(let) + key];
                }
            }
            return new_word;
        }
    }
}
