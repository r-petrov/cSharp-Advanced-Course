using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountSymbols
{
    static void Main(string[] args)
    {
        List<char> input = Console.ReadLine().ToCharArray().ToList();
        SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();
        int counter = 1;
        for (int i = 0; i < input.Count; i++)
        {
            for (int j = i + 1; j < input.Count; j++)
            {
                if (input[i].Equals(input[j]))
                {
                    counter++;
                    input.RemoveAt(j);
                    j--;
                }
            }
            occurrences.Add(input[i], counter);
            counter = 1;
        }

        foreach (var item in occurrences)
        {
            Console.WriteLine("{0}: {1} time/s", item.Key, item.Value);
        }
    }
}
