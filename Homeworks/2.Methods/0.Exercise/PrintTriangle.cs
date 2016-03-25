using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrintTriangle
{
    static void PrintRows(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine();
    }

    static void PrintTopTriangle(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            PrintRows(i);
        }
    }

    static void PrintBottomTriangle(int number)
    {
        for (int i = number; i >= 1; i--)
        {
            PrintRows(i);
        }
    }
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        PrintTopTriangle(n);
        PrintBottomTriangle(n - 1);
    }
}
