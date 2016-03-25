using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CategorizeNumbersAndFindMinMaxAvg
{
    class CategorizeNumbersAndFindMinMaxAvg
    {
        static void Main(string[] args)
        {
        again:
            //Console.Write("Please, enter your floating-point numbers: ");
            string numbers = Console.ReadLine();
            char[] separators = { ' ' };
            string[] numbersArr = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            double[] numsArr = new double[numbersArr.Length];
            for (int i = 0; i < numsArr.Length; i++)
            {
                if (double.TryParse(numbersArr[i], out numsArr[i]) == false)
                {
                    goto again;
                }
                else
                {
                    numsArr[i] = double.Parse(numbersArr[i]);
                }
            }

            // Categorize numbers
            List<double> roundedNumbers = new List<double>();
            List<double> nonZeroFractionNumbers = new List<double>();
            for (int i = 0; i < numsArr.Length; i++)
            {
                if ((decimal) numsArr[i] == Math.Floor((decimal) numsArr[i]))
                {
                    roundedNumbers.Add(numsArr[i]);
                }
                else
                {
                    nonZeroFractionNumbers.Add(numsArr[i]);
                }
            }

            //Printing both arrays along with their minimum, maximum, sum and average
            Console.Write("[");
            for (int i = 0; i < nonZeroFractionNumbers.Count; i++)
            {
                if (nonZeroFractionNumbers[i] == nonZeroFractionNumbers[nonZeroFractionNumbers.Count - 1])
                {
                    Console.Write("{0}]", nonZeroFractionNumbers[i]);
                }
                else
                {
                    Console.Write("{0}, ", nonZeroFractionNumbers[i]);
                }
                
            }
            Console.Write(" -> min: {0:F2}, max: {1:F2}, sum: {2:F2}, avg: {3:F2}", nonZeroFractionNumbers.Min(), nonZeroFractionNumbers.Max(), 
                nonZeroFractionNumbers.Sum(), nonZeroFractionNumbers.Average());
            Console.WriteLine();

            Console.Write("[");
            for (int i = 0; i < roundedNumbers.Count; i++)
            {
                if (roundedNumbers[i] == roundedNumbers[roundedNumbers.Count - 1])
                {
                    Console.Write("{0}]", roundedNumbers[i]);
                }
                else
                {
                    Console.Write("{0}, ", roundedNumbers[i]);
                }
            }
            Console.Write(" -> min: {0:F2}, max: {1:F2}, sum: {2:F2}, avg: {3:F2}", roundedNumbers.Min(), roundedNumbers.Max(),
                roundedNumbers.Sum(), roundedNumbers.Average());
            Console.WriteLine();
        }
    }
}
