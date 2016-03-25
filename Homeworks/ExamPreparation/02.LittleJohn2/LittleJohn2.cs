using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class LittleJohn2
{
    public static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < 4; i++)
        {
            sb.AppendFormat(" {0}", Console.ReadLine());
        }

        const string arrowPattern = @"(>>>----->>)|(>>----->)|(>----->)";

        Regex arrowMatcher = new Regex(arrowPattern);

        var arrows = arrowMatcher.Matches(sb.ToString());

        int largeArrowCount = 0;
        int mediumArrowCount = 0;
        int smallArrowCount = 0;

        foreach (Match arrow in arrows)
        {
            if (!string.IsNullOrEmpty(arrow.Groups[1].Value))
            {
                largeArrowCount++;
            }
            else if (!string.IsNullOrEmpty(arrow.Groups[2].Value))
            {
                mediumArrowCount++;
            }
            else
            {
                smallArrowCount++;
            }
        }

        string numberAsString = String.Format("{0}{1}{2}", smallArrowCount, mediumArrowCount, largeArrowCount);

        long number = long.Parse(numberAsString);

        string binaryNum = Convert.ToString(number, 2);

        string reversedBinaryNum = new string(binaryNum.Reverse().ToArray());

        string resultAsString = binaryNum + reversedBinaryNum;

        long result = Convert.ToInt64(resultAsString, 2);

        Console.WriteLine(result);
    }
}
