using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.UppercaseWords
{
    class UppercaseWords
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<![A-z])[A-Z]+(?![A-z])";
            //Regex regex = new Regex(pattern);

            string line = Console.ReadLine();

            while (line != "END")
            {
                MatchCollection matches = Regex.Matches(line, pattern);

                int offset = 0;
                foreach (Match match in matches)
                {
                    string word = match.Value;
                    string reversedWord = ReverseLetters(word);
                    //Console.WriteLine(reversedWord);
                    if (reversedWord == word)
                    {
                        reversedWord = DuplicateLetters(reversedWord);
                    }

                    int index = match.Index;
                    line = line.Remove(index + offset, word.Length);
                    line = line.Insert(index + offset, reversedWord);
                    offset += reversedWord.Length - word.Length;
                }

                Console.WriteLine(SecurityElement.Escape(line));
                line = Console.ReadLine();
            }
        }

        private static string ReverseLetters(string word)
        {
            string resultWord = new string(word.ToCharArray().Reverse().ToArray());

            //var value = match.Value.Reverse();
            //string result = String.Join("", value);

            //StringBuilder sb = new StringBuilder();

            //for (int i = word.Length - 1; i >= 0; i--)
            //{
            //    sb.Append(word[i]);
            //}

            return resultWord;
        }

        private static string DuplicateLetters(string value)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                sb.Append(new string(value[i], 2));
            }

            return sb.ToString();
        }
    }
}

/*
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.UppercaseWords
{
    class UppercaseWords
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-z]+)";
            //Regex regex = new Regex(pattern);

            string line = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            while (line != "END")
            {
                MatchCollection matches = Regex.Matches(line, pattern);

                output.AppendLine(ReverseLetters(matches, line));

                line = Console.ReadLine();
            }

            Console.WriteLine(output.ToString());
        }

        private static string ReverseLetters(MatchCollection matches, string line)
        {
            foreach (var match in matches)
            {
                if (match.ToString().All(char.IsUpper))
                {
                    string resultWord = new string(match.ToString().ToCharArray().Reverse().ToArray());

                    if (match.ToString() == resultWord)
                    {
                        resultWord = DuplicateLetters(match.ToString());
                    }

                    line = Regex.Replace(line, match.ToString(), resultWord);
                }
            }

            return line;
        }

        private static string DuplicateLetters(string resultWord)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < resultWord.Length; i++)
            {
                sb.Append(new string(resultWord[i], 2));
            }

            return sb.ToString();
        }
    }
}
 */