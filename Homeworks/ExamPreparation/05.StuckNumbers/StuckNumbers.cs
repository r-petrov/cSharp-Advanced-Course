using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StuckNumbers
{
    static void Main(string[] args)
    {
        var count = Console.ReadLine();
        var inputNumbers = Console.ReadLine();
        var numbersArray = inputNumbers.Split(' ');
        int counter = 0;

        foreach (var a in numbersArray)
        {
            foreach (var b in numbersArray)
            {
                foreach (var c in numbersArray)
                {
                    foreach (var d in numbersArray)
                    {
                        if (a != b && a != c && a != d && b != c && b != d && c != d)
                        {
                            if (a + b == c + d)
                            {
                                Console.WriteLine("{0}|{1}=={2}|{3}", a, b, c, d);
                                counter++;
                            }
                        }
                    }
                }
            }
        }

        if (counter == 0)
        {
            Console.WriteLine("No");
        }
    }
}
