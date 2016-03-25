using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LongestIncreasingSequence
{
    static void Main(string[] args)
    {
    again:
        string numbers = Console.ReadLine();
        char[] separators = { ' ' };
        string[] numbersArr = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int[] numsArr = new int[numbersArr.Length];
        for (int i = 0; i < numsArr.Length; i++)
        {
            if (int.TryParse(numbersArr[i], out numsArr[i]) == false)
            {
                goto again;
            }
            else
            {
                numsArr[i] = int.Parse(numbersArr[i]);
            }
        }

        int counter = 1;
        int maxLength = 1;
        int lastNumberIndex = 0;
        Console.Write("{0} ", numsArr[0]);
        for (int i = 1; i < numsArr.Length; i++)
        {
            if (numsArr[i - 1] < numsArr[i])
            {
                Console.Write("{0} ", numsArr[i]);
                counter++;
            }
            else
            {
                Console.WriteLine();
                Console.Write("{0} ", numsArr[i]);
                counter = 1;
            }
            if (counter > maxLength)
            {
                maxLength = counter;
                lastNumberIndex = i;
            }
        }

        //print the longest sequence of increasing numbers
        Console.WriteLine();
        Console.Write("Longest: ");
        for (int i = lastNumberIndex - maxLength + 1; i <= lastNumberIndex; i++)
        {
            Console.Write("{0} ", numsArr[i]);
        }
        Console.WriteLine();
    }
}
