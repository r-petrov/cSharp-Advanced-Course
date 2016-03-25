using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.ExtractHyperlinks
{
    class ExtractHyperlinks
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            var input = new StringBuilder();

            while (line != "END")
            {
                input.AppendLine(line);
                line = Console.ReadLine();
            }

            string pattern = @"(<a[^>]+)(href\s*=\s*)([""'])?(\S.*?)(?:>|class|\3)";

            MatchCollection matches = Regex.Matches(input.ToString(), pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[4]);
            }
        }
    }
}
