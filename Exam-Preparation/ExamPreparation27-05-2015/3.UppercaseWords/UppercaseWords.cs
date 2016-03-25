using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.UppercaseWords
{
    class UppercaseWords
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?<![A-z])[A-Z]+(?![A-z])");
            StringBuilder line = new StringBuilder(Console.ReadLine()); 

            while (line.ToString() != "END")
            {
                MatchCollection matches = regex.Matches(line.ToString());

                int offset = 0;
                foreach (Match match in matches)
                {
                    string word = match.Value;
                    string reversed = Reverse(word);

                    if (reversed == word)
                    {
                        reversed = DoubleEachLetter(reversed);
                    }

                    int index = match.Index;
                    line.Remove(index + offset, word.Length);
                    line.Insert(index + offset, reversed);
                    offset += reversed.Length - word.Length;
                }

                Console.WriteLine(SecurityElement.Escape(line.ToString()));
                line = new StringBuilder(Console.ReadLine());
            }
        }

        private static string DoubleEachLetter(string reversed)
        {
            StringBuilder doubled = new StringBuilder();

            for (int i = 0; i < reversed.Length; i++)
            {
                doubled.Append(new string(reversed[i], 2));
            }

            return doubled.ToString();
        }

        private static string Reverse(string value)
        {
            StringBuilder reversed = new StringBuilder();

            for (int i = value.Length - 1; i >= 0; i--)
            {
                reversed.Append(value[i]);
            }

            return reversed.ToString();
        }
    }
}