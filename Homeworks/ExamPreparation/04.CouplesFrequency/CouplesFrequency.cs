using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CouplesFrequency
{
    static void Main(string[] args)
    {
        //input
        string input = Console.ReadLine();

        while (input.Length < 2 || input.Length > 2000)
        {
            input = Console.ReadLine();
        }
        string[] inputNumbers =input.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

        List<string> couples  = new List<string>();

        for (int i = 0; i < inputNumbers.Length - 1; i++)
        {
            couples.Add(inputNumbers[i] + " " + inputNumbers[i + 1]);
        }

        var frequenciesOfCouples = couples.GroupBy(element => element)
            .Select(group => new {Value = group.Key, Count = group.Count()});

        double totalSumOfCouples = 0;

        foreach (var couple in frequenciesOfCouples)
        {
            totalSumOfCouples += couple.Count;
        }

        foreach (var couple in frequenciesOfCouples)
        {
            Console.WriteLine("{0} -> {1:f2}%", couple.Value, (couple.Count / totalSumOfCouples) * 100);
        }
    }
}
