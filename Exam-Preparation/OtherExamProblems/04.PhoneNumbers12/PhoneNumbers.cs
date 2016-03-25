using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.PhoneNumbers12
{
    class PhoneNumbers
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

            string pattern = @"([A-Z][a-zA-Z]*)[^a-zA-Z\+]*?(?=\+|[0-9]{2})([0-9\+]{0,1}[0-9][0-9\/(). -]*[0-9])";
            string digitsPattern = @"[()\/\.\-\s]";

            MatchCollection matches = Regex.Matches(input.ToString(), pattern);

            Dictionary<string, string> phoneNumbers = matches.Cast<Match>().ToDictionary(contact => contact.Groups[1].ToString(), 
                contact => contact.Groups[2] + contact.Groups[3].ToString());

            if (phoneNumbers.Count > 0)
            {
                Console.Write("<ol>");
                foreach (var number in phoneNumbers)
                {
                    var outputNum = Regex.Replace(number.Value, digitsPattern, "");

                    Console.Write("<li><b>{0}:</b> {1}</li>", number.Key, outputNum);
                }
                Console.WriteLine("</ol>");
            }
            else
            {
                Console.WriteLine("<p>No matches!</p>");
            }
        }
    }
}
