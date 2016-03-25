using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.TextGravity
{
    class TextGravity
    {
        static void Main(string[] args)
        {
            int rowLength = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            int numberOfRows = (int)Math.Ceiling((decimal) text.Length/rowLength);
            char[,] matrix = new char[numberOfRows, rowLength];

            int index = 0;

            FillMatrix(matrix, index, text);

            for (int col = 0; col < rowLength; col++)
            {
                RunGravity(matrix, col);
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sb.Append("<tr>");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.AppendFormat("<td>{0}</td>", SecurityElement.Escape(matrix[row, col].ToString()));
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            Console.WriteLine(sb.ToString());
        }

        static void FillMatrix(char[,] matrix, int index, string text)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (index < text.Length)
                    {
                        matrix[row, col] = text[index];
                        index++;
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        static void RunGravity(char[,] matrix, int col)
        {
            while (true)
            {
                bool hasFallen = false;
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    char topChar = matrix[row - 1, col];
                    char currentChar = matrix[row, col];
                    if (currentChar == ' ' && topChar != ' ')
                    {
                        matrix[row, col] = topChar;
                        matrix[row - 1, col] = ' ';
                        hasFallen = true;
                    }
                }

                if (!hasFallen)
                {
                    break;
                }
            }
        }
    }
}
