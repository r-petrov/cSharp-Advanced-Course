using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.SemanticHTML2
{
    class SemanticHTML2
    {
        static void Main(string[] args)
        {
            var row = Console.ReadLine();
            var openTagPattern = @"<div(.*)(id|class)\s*=\s*""(\w+)""(.*)>";
            var closeTagPattern = @"</div>\s*<!--\s*(\w+)\s*-->";

            while (row != "END")
            {
                if (Regex.IsMatch(row, openTagPattern))
                {
                    var matches = Regex.Match(row, @"(id|class)\s*=\s*""(\w+)""");
                    var tagName = matches.Groups[2].Value.Trim();
                    var before = matches.Groups[0].Value.Trim();
                    var result = row.Replace("div", tagName);
                    result = result.Replace(before, "");
                    result = result.Replace("  ", " ");
                    result = result.Replace(" >", ">");
                    Console.WriteLine(result);
                }
                else if (Regex.IsMatch(row, closeTagPattern))
                {
                    var matches = Regex.Match(row, closeTagPattern);
                    var tagName = matches.Groups[1].Value;
                    var result = "</" + tagName + ">";
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine(row);
                }

                row = Console.ReadLine();
            }
        }
    }
}
