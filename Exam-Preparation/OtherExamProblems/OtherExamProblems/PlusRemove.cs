using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherExamProblems
{
    class PlusRemove
    {
        static void Main(string[] args)
        {
            var inputMatrix = new List<char[]>();
            var outputMatrix = new List<char[]>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                var matrixRow = input.ToCharArray();
                outputMatrix.Add(matrixRow);
                var lowerMatrixRow = input.ToLower().ToCharArray();
                inputMatrix.Add(lowerMatrixRow);

                input = Console.ReadLine();
            }

            RemovePlusShapes(inputMatrix, outputMatrix);

            PrintJaggedMatrix(outputMatrix);
        }

        private static void PrintJaggedMatrix(List<char[]> outputMatrix)
        {
            foreach (var result in outputMatrix)
            {
                foreach (var ch in result)
                {
                    if (ch != '\0')
                    {
                        Console.Write(ch);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void RemovePlusShapes(List<char[]> inputMatrix, List<char[]> outputMatrix)
        {
            for (int row = 1; row < inputMatrix.Count - 1; row++)
            {
                var maxLength = Math.Min(inputMatrix[row - 1].Length - 1,
                    Math.Min(inputMatrix[row].Length - 2, inputMatrix[row + 1].Length - 1));

                for (int col = 0; col < maxLength; col++)
                {
                    var first = inputMatrix[row - 1][col + 1];
                    var second = inputMatrix[row][col];
                    var third = inputMatrix[row][col + 1];
                    var fourth = inputMatrix[row][col + 2];
                    var fifth = inputMatrix[row + 1][col + 1];

                    if (first == second && second == third && third == fourth && fourth == fifth)
                    {
                        outputMatrix[row - 1][col + 1] = '\0';
                        outputMatrix[row][col] = '\0';
                        outputMatrix[row][col + 1] = '\0';
                        outputMatrix[row][col + 2] = '\0';
                        outputMatrix[row + 1][col + 1] = '\0';
                    }
                }
            }
        }
    }
}
