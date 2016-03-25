using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseNumber
{
    static float GetReversednumber(string input)
    {
        int reversedNumber;
        char[] inputArray = input.ToCharArray();
        string reversedInput = "";

        for (int i = inputArray.Length - 1; i >= 0; i--)
        {
            reversedInput += inputArray[i];
        }
        return float.Parse(reversedInput);
        //if (decimal.Parse(reversedInput) == Math.Floor(decimal.Parse(reversedInput)))
        //{
        //    return (float)Math.Floor(decimal.Parse(reversedInput));
        //}
        //else
        //{
        //    return float.Parse(reversedInput);
        //}
    }
    static void Main(string[] args)
    {
        string inputString = Console.ReadLine();
        Console.WriteLine(GetReversednumber(inputString));
    }
}
