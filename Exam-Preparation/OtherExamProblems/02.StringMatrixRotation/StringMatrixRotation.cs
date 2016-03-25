using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.StringMatrixRotation
{
    class StringMatrixRotation
    {
        static void Main(string[] args)
        {
            string inputDegrees = Console.ReadLine();
            string pattern = @"\d{1,5}";
            var match = Regex.Match(inputDegrees, pattern);
            int degrees = int.Parse(match.ToString());
            int rotationDegrees = 0;

            if (degrees >= 360)
            {
                rotationDegrees = (degrees%360);
            }
            else
            {
                rotationDegrees = degrees;
            }

            string inputRow = Console.ReadLine();
            List<string> matrixRows = new List<string>();

            while (inputRow != "END")
            {
                matrixRows.Add(inputRow);
                inputRow = Console.ReadLine();
            }

            int rowsCount = matrixRows.Count;
            int colsCount = matrixRows.Select(t => t.Length).Concat(new[] { int.MinValue }).Max();

            char[,] inputMatrix = CreateInputMatrix(matrixRows, rowsCount, colsCount);
            
            char[,] outputMatrix = null;

            if (rotationDegrees == 90)
            {
                outputMatrix = RotateNinetyDegrees(matrixRows, colsCount, rowsCount);
            }
            else if(rotationDegrees == 180)
            {
                outputMatrix = RotateOneHundredAndEightyDegrees(matrixRows, rowsCount, colsCount);
            }
            else if (rotationDegrees == 270)
            {
                outputMatrix = RotateTwoHundredAndSeventyDegrees(matrixRows, colsCount, rowsCount);
            }
            else
            {
                outputMatrix = inputMatrix;
            }

            PrintMatrix(outputMatrix);
        }

        private static void PrintMatrix(char[,] outputMatrix)
        {
            for (int row = 0; row < outputMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < outputMatrix.GetLength(1); col++)
                {
                    Console.Write(outputMatrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static char[,] RotateTwoHundredAndSeventyDegrees(List<string> matrixRows, int outputMatrixRowsCount, int outputMatrixColsCount)
        {
            var outputMatrix = new char[outputMatrixRowsCount, outputMatrixColsCount];

            for (int col = 0; col < outputMatrixColsCount; col++)
            {
                string word = matrixRows[col];
                for (int row = outputMatrixRowsCount - 1; row >= 0; row--)
                {
                    if (outputMatrixRowsCount - row - 1 < word.Length)
                    {
                        outputMatrix[row, col] = word[outputMatrixRowsCount - row - 1];
                    }
                    else
                    {
                        outputMatrix[row, col] = ' ';
                    }
                }
            }

            return outputMatrix;
        }

        private static char[,] RotateOneHundredAndEightyDegrees(List<string> matrixRows, int rowsCount, int colsCount)
        {
            var outputMatrix = new char[rowsCount, colsCount];

            for (int row = rowsCount - 1; row >= 0; row--)
            {
                string word = matrixRows[rowsCount - row - 1];
                for (int col = colsCount - 1; col >= 0; col--)
                {
                    if (colsCount - col - 1 < word.Length)
                    {
                        outputMatrix[row, col] = word[colsCount - col - 1];
                    }
                    else
                    {
                        outputMatrix[row, col] = ' ';
                    }
                }
            }

            return outputMatrix;
        }

        private static char[,] RotateNinetyDegrees(List<string> matrixRows, int outputMatrixRowsCount , int outputMatrixColsCount)
        {
            var outputMatrix = new char[outputMatrixRowsCount, outputMatrixColsCount];

            for (int col = outputMatrixColsCount - 1; col >= 0; col--)
            {
                string word = matrixRows[outputMatrixColsCount - col - 1];
                for (int row = 0; row < outputMatrixRowsCount; row++)
                {
                    if (row < word.Length)
                    {
                        outputMatrix[row, col] = word[row];
                    }
                    else
                    {
                        outputMatrix[row, col] = ' ';
                    }
                }
            }

            return outputMatrix;
        }

        private static char[,] CreateInputMatrix(List<string> matrixRows, int rowsCount, int colsCount)
        {
            
            var inputMatrix = new char[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                string word = matrixRows[row];
                for (int col = 0; col < colsCount; col++)
                {
                    if (col < word.Length)
                    {
                        inputMatrix[row, col] = word[col];
                    }
                    else
                    {
                        inputMatrix[row, col] = ' ';
                    }
                }
            }

            return inputMatrix;
        }
    }
}
