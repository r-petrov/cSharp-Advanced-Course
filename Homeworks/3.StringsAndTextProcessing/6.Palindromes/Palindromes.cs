using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Palindromes
    {
        static string ReverseStrings(string word)
        {
            string reversed = String.Empty;

            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversed += word[i];
            }

            return reversed;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] separators = new[] {' ', ',', '.', '?', '!'};
            string[] inputArr = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> palindromesSortedSet = new SortedSet<string>();

            for (int i = 0; i < inputArr.Length; i++)
            {
                string reversedWord = ReverseStrings(inputArr[i]);
                if (inputArr[i].Equals(reversedWord))
                {
                    palindromesSortedSet.Add(inputArr[i]);
                }
            }

            Console.WriteLine();
            Console.WriteLine(String.Join(", ", palindromesSortedSet));
        }
    }
