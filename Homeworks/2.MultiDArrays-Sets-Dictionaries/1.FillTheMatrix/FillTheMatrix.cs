using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class FillTheMatrix
{
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

    static int[] FillEvenCols(int count, int[] col)
    {
        for (int i = 0; i < col.Length; i++)
        {
            col[i] = count;
            count++;
        }
        return col;
    }

    static int[] FillOddCols(int count, int[] col)
    {
        for (int i = col.Length - 1; i >= 0; i--)
        {
            col[i] = count;
            count++;
        }
        return col;
    }
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrixA = new int[n,n];
        
        //filling matrix A
        int counter = 0;
        for (int i = 0; i < matrixA.GetLength(0); i++)
        {
            for (int j = 0; j < matrixA.GetLength(1); j++)
            {
                matrixA[i, j] = i + 1 + counter;
                counter += n;
            }
            counter = 0;
        }

        //filling matrix B
        int[,] matrixB = new int[n, n];
        int[] col = new int[matrixB.GetLength(0)];
        int count = 1;
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            if (j%2 == 0)
            {
                col = FillEvenCols(count, col);
                for (int i = 0; i < matrixB.GetLength(0); i++)
                {
                    matrixB[i, j] = col[i];
                }
                count += matrixB.GetLength(0);
            }
            else
            {
                col = FillOddCols(count, col);
                for (int i = 0; i < matrixB.GetLength(0); i++)
                {
                    matrixB[i, j] = col[i];
                }
                count += matrixB.GetLength(0);
            }
        }

        Console.WriteLine();
        PrintMatrix(matrixA);
        Console.WriteLine();
        PrintMatrix(matrixB);
    }
}
