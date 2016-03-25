using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.OlympicsAreComing
{
    class OlympicsAreComing
    {
        static void Main(string[] args)
        {
            List<string[]> participants = new List<string[]>();

            for (int i = 0; i < 50; i++)
            {
                string[] input = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                participants.Add(input);
            }


        }
    }
}
