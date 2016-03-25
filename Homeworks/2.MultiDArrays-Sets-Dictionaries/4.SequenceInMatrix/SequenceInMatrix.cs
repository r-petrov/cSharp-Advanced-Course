using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SequenceInMatrix
{
    private static int[] ReadNumsArrayFromTheConsole()
    {
        int[] numsArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        return numsArr;
    }

    static List<string[]> InputMatrixRows(int rows)
    {
        List<string[]> matrixRows = new List<string[]>();
        char[] separators = new[] { ' ' };
        for (int i = 0; i < rows; i++)
        {
            string[] row = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();
            matrixRows.Add(row);
        }

        return matrixRows;
    }
    static string[,] FillMatrixFromList(List<string[]> rows, string[,] matrix)
    {
        for (int i = 0; i < rows.Count; i++)
        {
            string[] row = rows[i];
            for (int j = 0; j < row.Length; j++)
            {
                matrix[i, j] = row[j];
            }
        }
        return matrix;
    }

    static int CountRow(string[,] matrix, int i, int j)
    {
        int counter = 1;
        for (int k = j + 1; k < matrix.GetLength(1); k++)
        {
            if (matrix[i, k].Equals(matrix[i, j]))
            {
                counter++;
            }
        }

        return counter;
    }

    static int CountColumn(string[,] matrix, int i, int j)
    {
        int counter = 1;
        for (int k = i + 1; k < matrix.GetLength(0); k++)
        {
            if (matrix[k, j].Equals(matrix[i, j]))
            {
                counter++;
            }
        }
        return counter;
    }

    static int CountDiagonal(string[,] matrix, int i, int j)
    {
        int counter = 1;
        int diagonalLength = (matrix.GetLength(0) < matrix.GetLength(1)) ? matrix.GetLength(0) : matrix.GetLength(1);

        for (int k = j + 1; k < diagonalLength; k++)
        {
            if (matrix[k, k].Equals(matrix[i, j]))
            {
                counter++;
            }
        }

        return counter;
    }
   
    static void Main(string[] args)
    {
        //create and fill the matrix
        int[] matrixDimensions = ReadNumsArrayFromTheConsole();
        while (matrixDimensions.Length != 2)
        {
            matrixDimensions = ReadNumsArrayFromTheConsole();
        }

        string[,] matrix = new string[matrixDimensions[0],matrixDimensions[1]];
        List<string[]> matrixRows = InputMatrixRows(matrixDimensions[0]);
        
        matrix = FillMatrixFromList(matrixRows, matrix);
        int biggestCount = 0;
        string mostFrequentElement = String.Empty;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int rowCount = CountRow(matrix, i, j);
                int colCount = CountColumn(matrix, i, j);
                int diagonalCount = CountDiagonal(matrix, i, j);
                int temp = Math.Max(Math.Max(rowCount, colCount), diagonalCount);

                if (temp > biggestCount)
                {
                    biggestCount = temp;
                    mostFrequentElement = matrix[i, j];
                }
            }
        }

        for (int i = 0; i < biggestCount; i++)
        {
            if (i == biggestCount - 1)
            {
                Console.WriteLine(mostFrequentElement);
                break;
            }
            Console.Write(mostFrequentElement + ", ");
        }
    }
}
