using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Exercise
{
    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int[,] resultMatrix = new int[matrix1.GetLength(0),matrix2.GetLength(1)];
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                for (int k = 0; k < matrix1.GetLength(1); k++)  //or k < matrix2.GetLength(0)
                {
                    resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return resultMatrix;
    }
    static void Main(string[] args)
    {
        //declaring two matrices
        int[,] matrix0;
        int[,] matrix1;
        List<int[,]> matrices = new List<int[,]>();

        //initializing the matrices
        again:
        for (int i = 0; i < 2; i++)
        {
            Console.Write("Please, enter the number of rows of matrix#{0}:", i + 1);
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Please, enter the number of columns of matrix#{0}:", i + 1);
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows,cols];

            for (int j = 0; j < rows; j++)
            {
                for (int k = 0; k < cols; k++)
                {
                    Console.Write("matrix[{0},{1}] = ", j, k);
                    string inputNum = Console.ReadLine();
                    matrix[j, k] = int.Parse(inputNum);
                }
            }
            matrices.Add(matrix);
        }

        matrix0 = matrices[0];
        matrix1 = matrices[1];
        int[,] multipliedMatrix = new int[matrix0.GetLength(0),matrix1.GetLength(1)];

        if (matrix0.GetLength(1) != matrix1.GetLength(0))
        {
            Console.WriteLine("The matrices you have inputed can not be multiplied!");
            goto again;
        }
        else
        {
            multipliedMatrix = MultiplyMatrices(matrix0, matrix1);
            for (int i = 0; i < multipliedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < multipliedMatrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", multipliedMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
