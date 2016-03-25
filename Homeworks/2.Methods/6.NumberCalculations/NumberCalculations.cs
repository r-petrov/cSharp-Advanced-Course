using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumberCalculations
{
    static int GetMinimumElement(List<int> numbers)
    {
        int minElement = int.MaxValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            minElement = (minElement < numbers[i]) ? minElement : numbers[i];
        }
        return minElement;
    }

    static int GetMaximumElement(List<int> numbers)
    {
        int maxElement = int.MinValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            maxElement = (maxElement > numbers[i]) ? maxElement : numbers[i];
        }
        return maxElement;
    }

    static int CalculateAverage(List<int> numbers)
    {
        int sum = 0;
        int count = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
            count++;
        }
        return sum/count;
    }

    static int CalculateSum(List<int> numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    static int CalculateProduct(List<int> numbers)
    {
        int product = 1;
        for (int i = 0; i < numbers.Count; i++)
        {
            product *= numbers[i];
        }
        return product;
    }

    static double GetMinimumElement(List<double> numbers)
    {
        double minElement = double.MaxValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            minElement = (minElement < numbers[i]) ? minElement : numbers[i];
        }
        return minElement;
    }

    static double GetMaximumElement(List<double> numbers)
    {
        double maxElement = double.MinValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            maxElement = (maxElement > numbers[i]) ? maxElement : numbers[i];
        }
        return maxElement;
    }

    static double CalculateAverage(List<double> numbers)
    {
        double sum = 0;
        double count = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
            count++;
        }
        return sum / count;
    }

    static double CalculateSum(List<double> numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    static double CalculateProduct(List<double> numbers)
    {
        double product = 1;
        for (int i = 0; i < numbers.Count; i++)
        {
            product *= numbers[i];
        }
        return product;
    }

    static decimal GetMinimumElement(List<decimal> numbers)
    {
        decimal minElement = decimal.MaxValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            minElement = (minElement < numbers[i]) ? minElement : numbers[i];
        }
        return minElement;
    }

    static decimal GetMaximumElement(List<decimal> numbers)
    {
        decimal maxElement = decimal.MinValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            maxElement = (maxElement > numbers[i]) ? maxElement : numbers[i];
        }
        return maxElement;
    }

    static decimal CalculateAverage(List<decimal> numbers)
    {
        decimal sum = 0;
        decimal count = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
            count++;
        }
        return sum / count;
    }

    static decimal CalculateSum(List<decimal> numbers)
    {
        decimal sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    static decimal CalculateProduct(List<decimal> numbers)
    {
        decimal product = 1;
        for (int i = 0; i < numbers.Count; i++)
        {
            product *= numbers[i];
        }
        return product;
    }

    static void Main(string[] args)
    {
        again:
        char[] separators = new[] { ',', ' ' };
        string[] inputArr = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        List<int> intNumbers = new List<int>();
        List<double>doubleNumbers = new List<double>();
        List<decimal> decimalNumbers = new List<decimal>();

        for (int i = 0; i < inputArr.Length; i++)
        {
            int intElement;
            double doubleElement;
            decimal decimalElement;

            if (int.TryParse(inputArr[i], out intElement))
            {
                intNumbers.Add(intElement);
            }
            else if(double.TryParse(inputArr[i], out doubleElement))
            {
                doubleNumbers.Add(doubleElement);
            }
            else if(decimal.TryParse(inputArr[i], out decimalElement))
            {
                decimalNumbers.Add(decimalElement);
            }
            else
            {
                Console.WriteLine("You entered invalid values");
                goto again;
                break;
            }
        }

        if (intNumbers.Count == inputArr.Length)
        {
            Console.WriteLine(GetMinimumElement(intNumbers));
            Console.WriteLine(GetMaximumElement(intNumbers));
            Console.WriteLine(CalculateAverage(intNumbers));
            Console.WriteLine(CalculateSum(intNumbers));
            Console.WriteLine(CalculateProduct(intNumbers));
        }
        else if (doubleNumbers.Count == inputArr.Length)
        {
            Console.WriteLine(GetMinimumElement(doubleNumbers));
            Console.WriteLine(GetMaximumElement(doubleNumbers));
            Console.WriteLine(CalculateAverage(doubleNumbers));
            Console.WriteLine(CalculateSum(doubleNumbers));
            Console.WriteLine(CalculateProduct(doubleNumbers));
        }
        else if (decimalNumbers.Count == inputArr.Length)
        {
            Console.WriteLine(GetMinimumElement(decimalNumbers));
            Console.WriteLine(GetMaximumElement(decimalNumbers));
            Console.WriteLine(CalculateAverage(decimalNumbers));
            Console.WriteLine(CalculateSum(decimalNumbers));
            Console.WriteLine(CalculateProduct(decimalNumbers));
        }
        else
        {
            Console.WriteLine("Please, enter only integer or only floating point numbers: ");
            goto again;
        }
    }
}
