using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GenericArraySort
{
    static void SortArray<T>(List<T> list) where T : IComparable
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int minValue = i;
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[minValue].CompareTo(list[j]) > 0)
                {
                    minValue = j;
                }
            }
            T temp = list[i];
            list[i] = list[minValue];
            list[minValue] = temp;
        }
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
    }

    static void Main(string[] args)
    {
        List<int> numbers = new List<int>() { 3, 2, 16, 24, 5, 1, 27, 80, 9 };
        List<string> strings = new List<string>() { "am", "em", "omo", "zaz", "cba", "baa" };
        List<DateTime> dates = new List<DateTime>(0) { new DateTime(2002, 3, 1), new DateTime(2015, 5, 6), new DateTime(2014, 1, 1), };

        SortArray(numbers);
        Console.WriteLine();
        SortArray(strings);
        Console.WriteLine();
        SortArray(dates);
        Console.WriteLine();
    }
}
