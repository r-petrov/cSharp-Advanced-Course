using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class SeriesOfLetters
{
    static void Main(string[] args)
    {
        string inputStr = Console.ReadLine();
        string pattern = @"([a-z])\1+";
        Regex regex = new Regex(pattern);
        Console.WriteLine(regex.Replace(inputStr, "$1"));

        //regex = new Regex("(.)\\1+");
        //var str = "something likeeeee!! tttthhiiissss";
        //Console.WriteLine(regex.Replace(str, "$1"));
    }
}
