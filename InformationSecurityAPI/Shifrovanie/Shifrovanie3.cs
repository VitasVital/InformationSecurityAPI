using InformationSecurityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace InformationSecurityAPI.Shifrovanie
{
    public class Shifrovanie3
    {
        List<char> letter;
        Random rnd;
        public Shifrovanie3()
        {
            this.letter = new List<char>()
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ж',
                'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о',
                'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч',
                'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
            };
            this.rnd = new Random();
        }

        private string ConvertToBinaty(char letter)
        {
            string binary_letter = "";
            int num = this.letter.IndexOf(letter);
            for (int i =0; i < 5; i++)
            {
                binary_letter += Convert.ToString(num % 2);
                num /= 2;
            }
            return binary_letter;
        }

        private string ConvertToText(string word)
        {
            string new_word = "";
            for (int i = 0; i < word.Length / 5; i++)
            {
                string letter_binary = "";
                for (int j = i * 5; j < i * 5 + 5; j++)
                {
                    letter_binary += word[j];
                }
                int letter_index = 0;
                for (int j = 0; j < letter_binary.Length; j++)
                {
                    if (letter_binary[j] == '1')
                    {
                        letter_index += Convert.ToInt32(Math.Pow(2, j));
                    }
                }
                new_word += this.letter[letter_index];
            }
            return new_word;
        }

        public TextRequest3 Gamming(TextRequest3 textRequest3)
        {
            if (textRequest3.word.Length == 0)
            {
                textRequest3.word_binary = "Слово неверное";
                return textRequest3;
            }
            for (int i = 0; i < textRequest3.word.Length; i++)
            {
                if (!this.letter.Contains(textRequest3.word[i]))
                {
                    textRequest3.word_binary = "Слово неверное";
                    return textRequest3;
                }
            }
            //перевод в двоичный вид исходного сообщения
            for (int i = 0; i < textRequest3.word.Length; i++)
            {
                textRequest3.word_binary += this.ConvertToBinaty(textRequest3.word[i]);
            }


            if (textRequest3.is_generated_key == false)
            {
                if (textRequest3.key.Length == 0)
                {
                    textRequest3.key_binary = "Ключ неверный";
                    return textRequest3;
                }
                for (int i = 0; i < textRequest3.key.Length; i++)
                {
                    if (!this.letter.Contains(textRequest3.key[i]))
                    {
                        textRequest3.key_binary = "Ключ неверный";
                        return textRequest3;
                    }
                }
                //перевод в двоичный вид ключа
                for (int i = 0; i < textRequest3.key.Length; i++)
                {
                    textRequest3.key_binary += this.ConvertToBinaty(textRequest3.key[i]);
                }
            }
            else
            {
                if (textRequest3.key_binary.Length == 0)
                {
                    for (int i = 0; i < textRequest3.word_binary.Length; i++)
                    {
                        textRequest3.key_binary += rnd.Next(0, 2).ToString();
                    }
                }
            }

            //шифрование или расшифровка слова
            int key_binary_index = 0;
            for (int i = 0; i < textRequest3.word_binary.Length; i++)
            {
                if (textRequest3.word_binary[i] == textRequest3.key_binary[key_binary_index])
                {
                    textRequest3.word_result_binary += "0";
                }
                else
                {
                    textRequest3.word_result_binary += "1";
                }
                key_binary_index += 1;
                if (key_binary_index == textRequest3.key_binary.Length)
                {
                    key_binary_index = 0;
                }
            }

            textRequest3.word_result = this.ConvertToText(textRequest3.word_result_binary);

            return textRequest3;
        }
    }
}