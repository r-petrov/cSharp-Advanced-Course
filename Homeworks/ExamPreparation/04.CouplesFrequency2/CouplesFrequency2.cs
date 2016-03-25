using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CouplesFrequency2
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int totalNumberOfCouples = numbers.Length - 1;

        var coupleFrequencies=new Dictionary<string, int>();

        for (int i = 1; i < numbers.Length; i++)
        {
            string currentCouple = String.Format("{0} {1}", numbers[i - 1], numbers[i]);

            if (!coupleFrequencies.ContainsKey(currentCouple))
            {
                coupleFrequencies.Add(currentCouple, 0);
            }

            coupleFrequencies[currentCouple]++;
        }

        foreach (var coupleFrequency in coupleFrequencies)
        {
            double frequency = coupleFrequency.Value * 100.0 / totalNumberOfCouples;

            Console.WriteLine("{0} -> {1:F2}%", coupleFrequency.Key, frequency);
        }
    }
}
