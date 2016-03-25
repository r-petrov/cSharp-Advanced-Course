using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortArrayOfNumbersOwnAlgoritm
{
    static void Main(string[] args)
    {
    again:
        //Console.Write("Please, enter your integer numbers: ");
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

        // realizing sorting algorithm
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < numsArr.Length - 1; i++)
            {
                if (numsArr[i] > numsArr[i + 1])
                {
                    int biggerElement = numsArr[i];
                    numsArr[i] = numsArr[i + 1];
                    numsArr[i + 1] = biggerElement;
                    swapped = true;
                }
            }
        } while (swapped == true);

        foreach (var item in numsArr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
