using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubsetSums
{
    //static void FindRequiredSumSubArray(int[] array, int number)
    //{
    //    //create an array for the subset with max length 
    //    int[] subset = new int[array.Length];
    //    int temp = 0;

    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        for (int j = i, col = 0; j < array.Length; j++, col++)
    //        {
    //            //add the value of elements of input array one by one
    //            temp += array[j];
    //            subset[col] = array[j];

    //            //if addition is equal to sum (inserted number), then print it 
    //            if (temp == number)
    //            {
    //                int total = 0;
    //                for (int k = 0; k < subset.Length; k++)
    //                {
    //                    total += subset[k];
    //                    Console.Write("{0} = {1}", String.Join(" + ", subset), number);

    //                    //if total and number are equal, then leave the print
    //                    if (total == number)
    //                    {
    //                        Console.Write("\n");
    //                        break;
    //                    }
    //                }
    //            }
    //            //if temp is greater than number then clear the subarray and set temp to zero and leave the loop for next
    //            if (temp > number)
    //            {
    //                Array.Clear(subset, 0, subset.Length);
    //                temp = 0;
    //                break;
    //            }
    //        }
    //    }
    //}
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        char[] separators = new char[]{' '};
        string[] array = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int count = 1 << array.Length; // 2^n

        string[] items = new string[array.Length];
        List<List<int>>subsetsList =new List<List<int>>();
        List<int>numList = new List<int>();
        int counter = 0;

        for (int i = 0; i < count; i++)
        {
            
            BitArray b = new BitArray(BitConverter.GetBytes(i));
            for (int bit = 0; bit < array.Length; bit++)
            {
                items[bit] = b[bit] ? array[bit] : "";
                if (items[bit] != "")
                {
                    numList.Add(int.Parse(items[bit]));
                }
            }
            //int[] numInts = Array.ConvertAll<string, int>(items, int.Parse);
            if (numList.Count != 0 && numList.Sum() == n)
            {
                Console.WriteLine("{0} = {1}", String.Join(" + ", numList), n);
                counter++;
            }
            numList.Clear();
        }

        if (counter == 0)
        {
            Console.WriteLine("No matching subsets.");
        }
        /*
        string[] array = { "A", "B", "C", "D" };
        int count = 1 << array.Length; // 2^n

        for (int i = 0; i < count; i++)
        {
            string[] items = new string[array.Length];
            BitArray b = new BitArray(BitConverter.GetBytes(i));
            for (int bit = 0; bit < array.Length; bit++)
            {
                items[bit] = b[bit] ? array[bit] : "";
            }
            Console.WriteLine(String.Join("", items));
        }*/
    }
}
