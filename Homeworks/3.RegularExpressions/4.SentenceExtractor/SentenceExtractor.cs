using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class SentenceExtractor
{
    static void Main(string[] args)
    {
        string keyword = Console.ReadLine();
        string text = Console.ReadLine();
        string pattern = @"(\w\s?)* {0} ?(\w\s?)*[\.\?\!]";
        string template = String.Format(pattern, keyword);
        MatchCollection matches = Regex.Matches(text, template);
        foreach (var match in matches)
        {
            Console.WriteLine(match);
        }
    }
}
