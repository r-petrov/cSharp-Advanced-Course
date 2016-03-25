using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximalSum
{
    private static int[] ReadNumsArrayFromTheConsole()
    {
        int[] numsArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        return numsArr;
    }

    static int[,] FillMatrixFromList(List<int[]> rows, int[,] matrix)
    {
        for (int i = 0; i < rows.Count; i++)
        {
            int[] row = rows[i];
            for (int j = 0; j < row.Length; j++)
            {
                matrix[i, j] = row[j];
            }
        }
        return matrix;
    }

    private static int CalculateSumOfMatrix(int[,] matrix, int row, int col, int matrixRows, int matrixCols)
    {
        int sum = 0; 
        for (int i = row; i < row + matrixRows; i++)
        {
            for (int j = col; j < col + matrixCols; j++)
            {
                sum += matrix[i, j];
            }
        }
        return sum;
    }

    
    static void Main(string[] args)
    {
        int[] matrixDimensions = ReadNumsArrayFromTheConsole();
        while (matrixDimensions.Length != 2)
        {
            matrixDimensions = ReadNumsArrayFromTheConsole();
        }

        int[,] matrix = new int[matrixDimensions[0],matrixDimensions[1]];
        List<int[]> matrixRows = new List<int[]>();
        int[] row = new int[matrixDimensions[1]];
        int platformSize = 3;

        for (int i = 0; i < matrixDimensions[0]; i++)
        {
            row = ReadNumsArrayFromTheConsole();
            matrixRows.Add(row);
        }

        matrix = FillMatrixFromList(matrixRows, matrix);
        List<int> bestSumRowAndCol = new List<int>();
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;

        for (int i = 0; i < matrix.GetLength(0) - (platformSize - 1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - (platformSize - 1); j++)
            {
                int sum = CalculateSumOfMatrix(matrix, i, j, platformSize, platformSize);
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = i;
                    bestCol = j;
                }
            }
        }
        bestSumRowAndCol.Add(bestSum);
        bestSumRowAndCol.Add(bestRow);
        bestSumRowAndCol.Add(bestCol);

        Console.WriteLine(bestSumRowAndCol[0]);
        for (int i = bestSumRowAndCol[1]; i <= platformSize; i++)
        {
            for (int j = bestSumRowAndCol[2]; j <= platformSize; j++)
            {
                Console.Write("{0, 4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
