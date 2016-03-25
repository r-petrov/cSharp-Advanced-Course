using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequencesOfEqualStrings
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        char[] separators = new char[] { ' ' };
        string[] strings = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        List<string> equalElements = new List<string>();

        for (int i = 0; i < strings.Length; i++)
        {
            if (strings[i] == "")
            {
                continue;
            }
            string element = strings[i];
            equalElements.Add(element);
            for (int j = i + 1; j < strings.Length; j++)
            {
                if (element.Equals(strings[j]))
                {
                    equalElements.Add(strings[j]);
                    strings[j] = "";
                    
                }
            }
            Console.Write(String.Join(" ", equalElements));
            Console.WriteLine();
            equalElements.Clear();
        }
    }
}
