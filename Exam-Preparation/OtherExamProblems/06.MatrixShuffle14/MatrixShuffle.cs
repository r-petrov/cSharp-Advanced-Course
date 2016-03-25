namespace _06.MatrixShuffle14
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class MatrixShuffle
    {
        public static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            var matrix = new char[matrixSize, matrixSize];

            FillSpirallyMatrix(matrixSize, matrix, text);

            //// PrintMatrix(matrix);

            string outputSentence = GetWhiteSquaresChars(matrix) + GetBlackSquaresChars(matrix);
            string pattern = @"[^A-Za-z0-9]*";
            string sentence = Regex.Replace(outputSentence, pattern, string.Empty);
            string reversedSentence = new string(sentence.ToCharArray().Reverse().ToArray());

            if (sentence.ToLower() == reversedSentence.ToLower())
            {
                Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", outputSentence);
            }
            else
            {
                Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", outputSentence);
            }
        }

        public static void FillSpirallyMatrix(int matrixSize, char[,] matrix, string text)
        {
            int positionX = 0;
            int positionY = 0;
            int stepsCount = matrixSize - 1;
            int currentStep = 0;
            int stepChange = 0;
            int direction = 0;

            for (int i = 0; i < matrixSize * matrixSize; i++)
            {
                matrix[positionX, positionY] = text[i];

                if (currentStep < stepsCount)
                {
                    currentStep++;
                }
                else
                {
                    currentStep = 1;

                    if (i <= (matrixSize - 1) * 3 && stepChange == 2)
                    {
                        stepsCount--;
                    }
                    else if (i > (matrixSize - 1) * 3 && stepChange == 1)
                    {
                        stepsCount--;
                    }

                    if (i <= (matrixSize - 1) * 3)
                    {
                        stepChange = (stepChange + 1) % 3;
                    }
                    else
                    {
                        stepChange = (stepChange + 1) % 2;
                    }

                    direction = (direction + 1) % 4;
                }

                switch (direction)
                {
                    case 0:
                        positionY++;
                        break;
                    case 1:
                        positionX++;
                        break;
                    case 2:
                        positionY--;
                        break;
                    case 3:
                        positionX--;
                        break;
                }
            }
        }

        private static string GetBlackSquaresChars(char[,] matrix)
        {
            var blackSquaresChars = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 1; col < matrix.GetLength(1); col += 2)
                    {
                        blackSquaresChars.Append(matrix[row, col]);
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col += 2)
                    {
                        blackSquaresChars.Append(matrix[row, col]);
                    }
                }
            }

            return blackSquaresChars.ToString();
        }

        private static string GetWhiteSquaresChars(char[,] matrix)
        {
            var whiteSquaresChars = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col += 2)
                    {
                        whiteSquaresChars.Append(matrix[row, col]);
                    }
                }
                else
                {
                    for (int col = 1; col < matrix.GetLength(1); col += 2)
                    {
                        whiteSquaresChars.Append(matrix[row, col]);
                    }
                }
            }

            return whiteSquaresChars.ToString();
        }

        //// private static void PrintMatrix(char[,] matrix)
        //// {
        ////     for (int row = 0; row < matrix.GetLength(0); row++)
        ////     {
        ////         for (int col = 0; col < matrix.GetLength(1); col++)
        ////         {
        ////             Console.Write(matrix[row, col]);
        ////         }

        ////         Console.WriteLine();
        ////     }
        //// }
    }
}
