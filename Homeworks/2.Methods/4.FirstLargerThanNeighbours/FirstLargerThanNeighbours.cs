using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FirstLargerThanNeighbours
{
    static int GetFirstLargerElementThanNeighbours(params int[] numbers)
    {
        int index = -1;
        bool isLarger = false;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i == 0)
            {
                isLarger = (numbers[0] > numbers[1]) ? true : false;
                if (isLarger == true)
                {
                    index = i;
                    break;
                }
            }
            else if (i < numbers.Length - 1)
            {
                isLarger = ((numbers[i] > numbers[i - 1]) && (numbers[i] > numbers[i + 1])) ? true : false;
                if (isLarger == true)
                {
                    index = i;
                    break;
                }
            }
            else
            {
                isLarger = (numbers[i] > numbers[i - 1]) ? true : false;
                if (isLarger == true)
                {
                    index = i;
                    break;
                }
            }
        }
        return index;
    }

    static void Main(string[] args)
    {
        //input a sequence of numbers from the console
        char[] separators = new[] { ',', ' ' };
        int[] numbers = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        //checking for larger neighbours
        Console.WriteLine(GetFirstLargerElementThanNeighbours(numbers));
    }
}
