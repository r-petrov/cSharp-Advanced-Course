using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ReplaceATag
{
    static void Main(string[] args)
    {
        string inputTags = "<ul>\n<li>\n<a href=http://softuni.bg>SoftUni<//a>\n<//li>\n<//ul>";
        Console.WriteLine(inputTags);
        string pattern = @"<a.*href=((?:.|\n)*?(?=>))>((?:.|\n)*?(?=<))<\/a>";
        string replace = @"[URL href=$1]$2[/URL]";
        var replaced = Regex.Replace(inputTags, pattern, replace);
        Console.WriteLine(replaced);
       
    }
}
