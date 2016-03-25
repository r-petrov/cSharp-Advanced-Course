using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StringLength
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        

        if (input.Length < 20)
        {
            string output = input;
            for (int i = 0; i < (20 - input.Length); i++)
            {
                output += "*";
            }
            Console.WriteLine(output);
        }
        else if(input.Length == 20)
        {
            Console.WriteLine(input);
        }
        else
        {
            Console.WriteLine(input.Substring(0, 20));
        }
    }
}
