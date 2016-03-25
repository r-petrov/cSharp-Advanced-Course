using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountSubstringOccurrences
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string keyword = Console.ReadLine();

        string text = input.ToLower();
        int index = text.IndexOf(keyword);
        int count = 0;

        while (index != -1)
        {
            index = text.IndexOf(keyword, index + 1);
            count++;
        }
        Console.WriteLine(count);
    }
}
