using InformationSecurityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSecurityAPI.Shifrovanie
{
    public class Shifrovanie2
    {
        List<char> letter;
        List<char> letter2;
        List<char> letter_rus;
        List<char> letter_eng;
        public Shifrovanie2()
        {
            this.letter = new List<char>()
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж',
                'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о',
                'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч',
                'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',

                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

            this.letter2 = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z',

                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

            this.letter_rus = new List<char>()
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж',
                'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о',
                'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч',
                'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
            };

            this.letter_eng = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
        }

        public string Vigener(TextRequest2 textRequest2)
        {
            List<char> letters;
            List<char> letters_lang;
            List<int> indexes_capital_letters = new List<int>();
            string lower_word = "";

            //верхний регистр в нижний
            for (int i = 0; i < textRequest2.word.Length; i++)
            {
                if (Char.IsUpper(textRequest2.word[i]))
                {
                    indexes_capital_letters.Add(i);
                    lower_word += char.ToLower(textRequest2.word[i]);
                }
                else
                {
                    lower_word += textRequest2.word[i];
                }
            }

            string lower_key = "";
            for (int i = 0; i < textRequest2.key.Length; i++)
            {
                if (Char.IsUpper(textRequest2.key[i]))
                {
                    lower_key += char.ToLower(textRequest2.key[i]);
                }
                else
                {
                    lower_key += textRequest2.key[i];
                }
            }
            textRequest2.key = lower_key;

            //если криптограмма, то расшифровка, иначе зашифровка
            if (textRequest2.is_cryptogram)
            {
                letters = textRequest2.language == 2 ? letter : letter2;
                letters_lang = textRequest2.language == 2 ? letter_rus : letter_eng;
            }
            else
            {
                letters = textRequest2.language == 2 ? letter : letter2;
                letters_lang = textRequest2.language == 2 ? letter_rus : letter_eng;
            }

            for (int i = 0; i < textRequest2.key.Length; i++)
            {
                if (!letters_lang.Contains(textRequest2.key[i]))
                {
                    return "Ключ не совпадает с выбранным языком";
                }
            }

            //шифрование или расшифровка слова
            string new_word = "";
            int index_of_key = 0;
            if (!textRequest2.is_cryptogram)
            {
                for (int i = 0; i < lower_word.Length; i++)
                {
                    if (!letters.Contains(lower_word[i]))
                    {
                        return "Вы ввели что-то неправильно";
                    }

                    if (letters.IndexOf(lower_word[i]) + letters_lang.IndexOf(textRequest2.key[index_of_key]) >= letters.Count)
                    {
                        new_word += letters[letters.IndexOf(lower_word[i]) + letters_lang.IndexOf(textRequest2.key[index_of_key]) - letters.Count + 1];
                    }
                    else
                    {
                        new_word += letters[letters.IndexOf(lower_word[i]) + letters_lang.IndexOf(textRequest2.key[index_of_key])];
                    }

                    index_of_key += 1;
                    if (index_of_key == textRequest2.key.Length)
                    {
                        index_of_key = 0;
                    }
                }
            }
            else
            {
                for (int i = 0; i < lower_word.Length; i++)
                {
                    if (!letters.Contains(lower_word[i]))
                    {
                        return "Вы ввели что-то неправильно";
                    }

                    if (letters.IndexOf(lower_word[i]) - letters_lang.IndexOf(textRequest2.key[index_of_key]) < 0)
                    {
                        new_word += letters[letters.Count - (letters_lang.IndexOf(textRequest2.key[index_of_key]) - letters.IndexOf(lower_word[i])) - 1];
                    }
                    else
                    {
                        new_word += letters[letters.IndexOf(lower_word[i]) - letters_lang.IndexOf(textRequest2.key[index_of_key])];
                    }

                    index_of_key += 1;
                    if (index_of_key == textRequest2.key.Length)
                    {
                        index_of_key = 0;
                    }
                }
            }

            //перевод в верхний регистр
            lower_word = "";
            for (int i = 0; i < new_word.Length; i++)
            {
                if (indexes_capital_letters.Contains(i))
                {
                    lower_word += char.ToUpper(new_word[i]);
                }
                else
                {
                    lower_word += new_word[i];
                }
            }
            new_word = lower_word;

            return new_word;
        }
    }
}
