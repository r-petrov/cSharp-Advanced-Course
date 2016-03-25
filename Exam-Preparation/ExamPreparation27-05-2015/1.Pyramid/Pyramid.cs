using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Pyramid
{
    class Pyramid
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> sequence = new List<int>();
            int previousNumber = int.Parse(Console.ReadLine().Trim());
            sequence.Add(previousNumber);

            for (int i = 1; i < n; i++)
            {
                //string line = Console.ReadLine();
                //string[] numgersAsStrings = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                //int[] numbers = new int[numgersAsStrings.Length];

                //for (int j = 0; j < numgersAsStrings.Length; j++)
                //{
                //    numbers[j] = int.Parse(numgersAsStrings[j]);
                //}

                int[] numbers = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                int minNumber = Int32.MaxValue;
                bool foundNumber = false;

                for (int j = 0; j < numbers.Length; j++)
                {
                    int currentNumber = numbers[j];

                    if (currentNumber < minNumber && currentNumber > previousNumber)
                    {
                        minNumber = currentNumber;
                        foundNumber = true;
                    }
                }

                if (foundNumber)
                {
                    sequence.Add(minNumber);
                    previousNumber = minNumber;
                }
                else
                {
                    previousNumber++;
                }
            }
        }
    }
}
