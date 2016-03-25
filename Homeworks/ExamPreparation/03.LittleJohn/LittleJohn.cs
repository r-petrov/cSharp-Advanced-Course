using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class LittleJohn
{
    static void Main(string[] args)
    {
        List<string> hayOfArrows=new List<string>();

        //input hay
        for (int i = 0; i < 4; i++)
        {
            hayOfArrows.Add(Console.ReadLine());
        }

        //count number of arrows
        List<int> arrowsCounters = new List<int>(){0, 0, 0};
        CountArrows(hayOfArrows, arrowsCounters);

        //Concatenate and turn to binary
        /*
         * var sb = new StringBuilder();
            for(var i=7;i>=0;i--)
            {
              sb.Append((b & (1<<i))==0?'0':'1');
            }
         */

        var finalBynary = EncriptNumberOfArrows(arrowsCounters);

        long countOfArrows = Convert.ToInt64(finalBynary, 2);

        Console.WriteLine(countOfArrows);
    }

    private static string EncriptNumberOfArrows(List<int> arrowsCounters)
    {
        StringBuilder arrowsNumberConcatenation = new StringBuilder();
        for (int i = arrowsCounters.Count - 1; i >= 0; i--)
        {
            arrowsNumberConcatenation.Append(arrowsCounters[i].ToString());
        }

        int concatNums = int.Parse(arrowsNumberConcatenation.ToString());
        string binary = Convert.ToString(concatNums, 2);
        string reversedBinary = new string(binary.Reverse().ToArray());
        string finalBynary = binary + reversedBinary.ToString();

        return finalBynary;
    }

    private static void CountArrows(List<string> hayOfArrows, List<int> arrowsCounters)
    {
        string smallArrowPattern = @">{1}-{5}>{1}";
        string mediumArrowPattern = @">{2}-{5}>{1}";
        string largeArrowPattern = @">{3}-{5}>{2}";

        List<Regex> arrowsRegexes = new List<Regex>()
        {
            new Regex(largeArrowPattern)  , new Regex(mediumArrowPattern), new Regex(smallArrowPattern) 
        };

        MatchCollection matches;

        for (int i = 0; i < hayOfArrows.Count; i++)
        {
            for (int j = 0; j < arrowsRegexes.Count; j++)
            {
                matches = arrowsRegexes[j].Matches(hayOfArrows[i]);
                arrowsCounters[j] += matches.Count;
                hayOfArrows[i] = arrowsRegexes[j].Replace(hayOfArrows[i], "");
            }
        }
    }
}
