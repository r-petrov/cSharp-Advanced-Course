using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BiggerNumber
{
    static int GetMax(int number1, int number2)
    {
        int max = Math.Max(number1, number2);
        return max;
    }
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        Console.WriteLine(GetMax(firstNumber, secondNumber));
    }
}
