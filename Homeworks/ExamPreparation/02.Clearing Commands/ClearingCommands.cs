using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

public class ClearingCommands
{
    const string CommandStr = "<>^v";
    private static void CleanRight(char[,] matrix, int commandRowPosition, int commandColPosition)
    {
        for (int i = commandRowPosition; i < commandRowPosition + 1; i++)
        {
            for (int j = commandColPosition + 1; j < matrix.GetLength(1); j++)
            {
                if (CommandStr.Contains(matrix[i, j]))
                {
                    break;
                }
                else
                {
                    matrix[i, j] = ' ';
                }
            }
        }
    }

    private static void CleanLeft(char[,] matrix, int commandRowPosition, int commandColPosition)
    {
        for (int i = commandRowPosition; i < commandRowPosition + 1; i++)
        {
            for (int j = commandColPosition - 1; j >= 0; j--)
            {
                if (CommandStr.Contains(matrix[i, j]))
                {
                    break;
                }
                else
                {
                    matrix[i, j] = ' ';
                }
            }
        }
    }

    private static void CleanDown(char[,] matrix, int commandRowPosition, int commandColPosition)
    {
        for (int i = commandColPosition; i < commandColPosition + 1; i++)
        {
            for (int j = commandRowPosition + 1; j < matrix.GetLength(0); j++)
            {
                if (CommandStr.Contains(matrix[j, i]))
                {
                    break;
                }
                else
                {
                    matrix[j, i] = ' ';
                }
            }
        }
    }

    private static void CleanUp(char[,] matrix, int commandRowPosition, int commandColPosition)
    {
        for (int i = commandColPosition; i < commandColPosition + 1; i++)
        {
            for (int j = commandRowPosition - 1; j >= 0; j--)
            {
                if (CommandStr.Contains(matrix[j, i]))
                {
                    break;
                }
                else
                {
                    matrix[j, i] = ' ';
                }
            }
        }
    }

    public static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            Console.Write("<p>");
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(SecurityElement.Escape(matrix[row, col].ToString()));
            }
            Console.WriteLine("</p>");
        }
    }
    static void Main(string[] args)
    {
        List<char[]> inputList = new List<char[]>();
        
        int count = 0;

        string input = Console.ReadLine();
        int inputLength = input.Length;
        while (input.ToLower() != "end")
        {
            char[] matrixRow = input.ToCharArray();
            inputList.Add(matrixRow);
            count++;

            input = Console.ReadLine();
        }

        char[,] matrix = new char[count, inputLength];

        for (int i = 0; i < inputList.Count; i++)
        {
            //char[] matrixRow = inputList[i];
            for (int j = 0; j < inputList[i].Length; j++)
            {
                matrix[i, j] = inputList[i][j];
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == '>')
                {
                    CleanRight(matrix, i, j);
                }
                else if (matrix[i, j] == '<')
                {
                    CleanLeft(matrix, i, j);
                }
                else if(matrix[i, j] == '^')
                {
                    CleanUp(matrix, i, j);
                }
                else if(matrix[i, j] == 'v')
                {
                    CleanDown(matrix, i, j);
                }
                else
                {
                    continue;
                }
            }
        }

        PrintMatrix(matrix);

        /*
         * print the matrix
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write(@"<p>");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                string element = matrix[i, j].ToString();
                if (matrix[i, j] == '>')
                {
                    element = "&gt;";
                }
                else if(matrix[i,j]=='<')
                {
                    element = "&lt;";
                }
                Console.Write(element);
            }
            Console.WriteLine(@"</p>");
        }
        */
    }
}
