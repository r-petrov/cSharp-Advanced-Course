using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortArrayOfNumbers
{
    static void Main(string[] args)
    {
    again:
        //Console.Write("Please, enter your integer numbers: ");
        string numbers = Console.ReadLine();
        char[] separators = {' '};
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

        var sortedNums = numsArr.OrderBy(i => i);
        foreach (var item in sortedNums)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
