using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Pyramid
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<int> growingSeqience = new List<int>();
        
        int currentNumber = 0;

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine().Trim();
            List<int> biggerNumbers = new List<int>();

            if (i == 0)
            {
                growingSeqience.Add(int.Parse(line));
                currentNumber = int.Parse(line);
            }
            else
            {
                string[] pyramidRow = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                biggerNumbers.AddRange(
                    from item in pyramidRow
                    where int.Parse(item) > currentNumber
                    select int.Parse(item));

                if (biggerNumbers.Count == 0)
                {
                    currentNumber++;
                }
                else
                {
                    growingSeqience.Add(biggerNumbers.Min());
                    currentNumber = biggerNumbers.Min();
                }
            }

            //biggerNumbers.Clear();
        }

        Console.WriteLine(String.Join(", ", growingSeqience));
    }
}
