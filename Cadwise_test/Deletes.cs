using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cadwise_test
{
    internal class Deletes
    {
        string Result { get; set; }

        public Deletes(string target)
        { 
            Result = target;
        }

        public string DeletePunctuation()=> Regex.Replace(Result, @"[^0-9a-zA-Zа-яА-Я\n ]+", ""); 

        public string DeleteShortWords(int length = 0)
        {
            string[] words = Result.Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach(string word in words)
            {
                if(word.Length > length)
                {
                    sb.Append($"{word} ");
                }
                else if (!String.IsNullOrWhiteSpace(word) && Char.IsPunctuation(word[0]))
                {
                    sb.Append($"{word} ");
                }
            }
            return sb.ToString();
        }

        public string DeleteShortWordsAndPunctuation(int length)
        {
            Result = DeletePunctuation();
            return DeleteShortWords(length);
        }
    }
}
