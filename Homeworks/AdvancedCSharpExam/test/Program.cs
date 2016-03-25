using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SnakeMatrix
{
    static int[] FillEvenRows(int count, int[] row)
    {
        for (int i = 0; i < row.Length; i++)
        {
            row[i] = count;
            count++;
        }
        return row;
    }

    static int[] FillOddRows(int count, int[] row)
    {
        for (int i = row.Length - 1; i >= 0; i--)
        {
            row[i] = count;
            count++;
        }
        return row;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0, 4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    static void Main(string[] args)
    {
        Console.Write("Please, enter the number of rows of the matrix: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the number of columns of the matrix: ");
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];
        int[] row = new int[matrix.GetLength(1)];
        int count = 1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                row = FillEvenRows(count, row);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
                count += matrix.GetLength(1);
            }
            else
            {
                row = FillOddRows(count, row);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
                count += matrix.GetLength(1);
            }
        }
        PrintMatrix(matrix);
    }
}
