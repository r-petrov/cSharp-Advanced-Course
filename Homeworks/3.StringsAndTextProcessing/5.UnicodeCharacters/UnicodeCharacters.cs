using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UnicodeCharacters
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        //char[] inputArr = input.ToCharArray();
        
        byte[] ascii = Encoding.ASCII.GetBytes(input);
        StringBuilder convertedInput = new StringBuilder();

        for (int i = 0; i < ascii.Length; i++)
        {
            convertedInput.Append("\\u" + ascii[i].ToString("X").PadLeft(4, '0'));
        }

        Console.WriteLine(convertedInput);
    }
}
