using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LargerThanNeighbours
{
    static bool IsLargerThanNeighbours(int index, params int[] numbers)
    {
        bool isLarger = false;

        if (index < 0 || index > numbers.Length - 1)
        {
            Console.WriteLine("Invalid index entered!");
        }
        else if(index == 0)
        {
            isLarger = (numbers[0] > numbers[1]) ? true : false;
        }
        else if(index < numbers.Length - 1)
        {
            isLarger = ((numbers[index] > numbers[index - 1]) && (numbers[index] > numbers[index + 1])) ? true : false;
        }
        else
        {
            isLarger = (numbers[index] > numbers[index - 1]) ? true : false;
        }
        return isLarger;
    }

    static void Main(string[] args)
    {
        //input a sequence of numbers from the console
        char[] separators = new[] {',', ' '};
        int[] numbers = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        //checking for larger neighbours
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(i, numbers));
        }
    }
}
