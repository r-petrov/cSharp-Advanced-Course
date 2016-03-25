using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class XRemoval
{
    static void Main(string[] args)
    {
        List<char[]> textLines = new List<char[]>();

        for (int i = 0; i < 100; i++)
        {
            string input = Console.ReadLine();
            
            while ((input.Length) > 100)
            {
                input = Console.ReadLine();
            }

            char[] rowSymbols = input.ToArray();

            if (input.ToLower() == "end")
            {
                break;
            }
            else
            {
                textLines.Add(rowSymbols);
            }
        }

        int minRowLength = int.MaxValue;
        for (int i = 0; i < textLines.Count; i++)
        {
            if (textLines[i].Length < minRowLength)
            {
                minRowLength = textLines[i].Length;
            }
        }
        Console.WriteLine(minRowLength);
        for (int i = 2; i < textLines.Count; i++)
        {
            for (int j = 0; j < minRowLength - 2; j++)
            {
                
            }
        }

        for (int i = 0; i < textLines.Count; i++)
        {
            for (int j = 0; j < textLines[i].Length; j++)
            {
                Console.Write(textLines[i][j]);
            }
            Console.WriteLine();
        }
    }
}
