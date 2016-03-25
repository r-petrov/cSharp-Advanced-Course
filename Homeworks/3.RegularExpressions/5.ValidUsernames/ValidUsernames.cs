using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ValidUsernames
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"\b\w+\b";
        MatchCollection matches = Regex.Matches(input, pattern);
        List<string> usernames = new List<string>();
        foreach (var match in matches)
        {
            usernames.Add(match.ToString());
        }

        string template = @"^[A-z](\w){2,25}";
        List<string> validUsernames = new List<string>();
        for (int i = 0; i < usernames.Count; i++)
        {
            if (Regex.IsMatch(usernames[i], template))
            {
                validUsernames.Add(usernames[i]);
            }
        }

        int bestSum = int.MinValue;
        string nameOne=String.Empty;
        string nameTwo=String.Empty;
        for (int i = 0; i < validUsernames.Count - 1; i++)
        {
            if (validUsernames[i].Length + validUsernames[i + 1].Length > bestSum)
            {
                bestSum = validUsernames[i].Length + validUsernames[i + 1].Length;
                nameOne = validUsernames[i];
                nameTwo = validUsernames[i + 1];
            }
        }
        Console.WriteLine("{0}\n{1}", nameOne, nameTwo);
    }
}
