using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LettersChangeNumbers
{
    static double DivideOrMultiplyNumberWithInt(char ch, double number)
    {
        int position = (int) ch%32;

        if (Char.IsUpper(ch))
        {
            number /= position;
        }
        else
        {
            number *= position;
        }

        return number;
    }

    static double SubstractOrAddIntToNumber(char ch, double number)
    {
        int position = (int)ch % 32;

        if (Char.IsUpper(ch))
        {
            number -= position;
        }
        else
        {
            number += position;
        }

        return number;
    }
    static void Main(string[] args)
    {
        char[] separators = new[] { ' ' };
        string input = Console.ReadLine();
        string[] inputArr = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        while (inputArr.Length > 10)
        {
            input = Console.ReadLine();
            inputArr = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
        
        List<double> numbers = new List<double>();

        for (int i = 0; i < inputArr.Length; i++)
        {
            string currentStr = inputArr[i];
            char firstChar = currentStr[0];
            char lastChar = currentStr[currentStr.Length - 1];
            double number = double.Parse(currentStr.Substring(1, currentStr.Length - 2));

            while (double.TryParse(currentStr.Substring(1, currentStr.Length - 2), out number) == false || number < 1)
            {
                number = double.Parse(currentStr.Substring(1, currentStr.Length - 2));
            }
            
            number = DivideOrMultiplyNumberWithInt(firstChar, number);
            number = SubstractOrAddIntToNumber(lastChar, number);
            numbers.Add(number);
        }

        Console.WriteLine("{0:F2}", numbers.Sum());
    }
}
