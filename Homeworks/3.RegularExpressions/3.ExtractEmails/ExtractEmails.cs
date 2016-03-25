using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ExtractEmails
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string emailPattern = @"([A-z0-9])+([\.\-_])?([A-z0-9])+([\.\-_])?([A-z0-9])+@([A-z])+\-?([A-z]+\.)+([A-z])+";
        MatchCollection matches = Regex.Matches(text, emailPattern);
        Console.WriteLine(matches.Count);
        foreach (var match in matches) 
        {
            Console.WriteLine(match);
        }
    }
}
