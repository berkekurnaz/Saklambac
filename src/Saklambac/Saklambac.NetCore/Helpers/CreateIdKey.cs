using System;
using System.Collections.Generic;
using System.Text;

namespace Saklambac.NetCore.Helpers
{
    public class CreateIdKey
    {

        public static string GetIdKey()
        {
            string apiKey = "";
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                int number = rnd.Next(1, 34);
                string addWord = GetWord(number);
                apiKey = apiKey + addWord;
            }
            return apiKey;
        }

        private static string GetWord(int number)
        {
            string word = "";
            switch (number)
            {
                case 1: word = "a"; break;
                case 2: word = "b"; break;
                case 3: word = "c"; break;
                case 4: word = "d"; break;
                case 5: word = "e"; break;
                case 6: word = "g"; break;
                case 7: word = "f"; break;
                case 8: word = "h"; break;
                case 9: word = "i"; break;
                case 10: word = "j"; break;
                case 11: word = "k"; break;
                case 12: word = "l"; break;
                case 13: word = "m"; break;
                case 14: word = "n"; break;
                case 15: word = "o"; break;
                case 16: word = "p"; break;
                case 17: word = "r"; break;
                case 18: word = "s"; break;
                case 19: word = "t"; break;
                case 20: word = "u"; break;
                case 21: word = "v"; break;
                case 22: word = "y"; break;
                case 23: word = "z"; break;
                case 24: word = "0"; break;
                case 25: word = "1"; break;
                case 26: word = "2"; break;
                case 27: word = "3"; break;
                case 28: word = "4"; break;
                case 29: word = "5"; break;
                case 30: word = "6"; break;
                case 31: word = "7"; break;
                case 32: word = "8"; break;
                case 33: word = "9"; break;
                default: word = "a"; break;
            }
            return word;
        }

    }
}
