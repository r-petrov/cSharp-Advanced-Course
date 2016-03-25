using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.SumOfAllValues13
{
    class SumOfAllValues
    {
        static void Main(string[] args)
        {
            string keysInput = Console.ReadLine();
            string text = Console.ReadLine();

            string startKeyPattern = @"^([A-Za-z_]+)(?=\d)";
            string endKeyPattern = @"(?<=\d)([A-Za-z_]+)$";
            var startKey = Regex.Match(keysInput, startKeyPattern);
            var endKey = Regex.Match(keysInput, endKeyPattern);

            if (string.IsNullOrEmpty(startKey.ToString()) || string.IsNullOrEmpty(endKey.ToString()))
            {
                Console.WriteLine("<p>A key is missing</p>");
                return;
            }
            
            string pattern = startKey + @"([-+]?\d*\.?\d*)" + endKey;

            MatchCollection matches = Regex.Matches(text, pattern);
            double sum = 0;

            foreach (Match match in matches)
            {
                //double sum = matches.Cast<Match>().Sum(match => double.Parse(match.Groups[1].ToString()));
                double currentValue = double.Parse(match.Groups[1].ToString());
                sum += currentValue;
            }

            Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum > 0 ? sum.ToString() : "nothing");
        }
    }
}
