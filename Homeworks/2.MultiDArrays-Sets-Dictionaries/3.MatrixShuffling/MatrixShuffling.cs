using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixShuffling
{
    static string[,] FillMatrixFromConsole(int rows, int cols)
    {
        string[,] matrix = new string[rows,cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = Console.ReadLine();
            }
        }

        return matrix;
    }

    static bool ValidateCommands(string command, int rows, int cols)
    {
        bool isValidCommand = true;
        char[] separators = new[] {' '};
        string[] commandKeywords = command.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        if (commandKeywords[0] != "swap" || commandKeywords.Length != 5 ||
            (int.Parse(commandKeywords[1]) < 0 || int.Parse(commandKeywords[1]) > rows) ||
            (int.Parse(commandKeywords[2]) < 0 || int.Parse(commandKeywords[2]) > cols) || 
            (int.Parse(commandKeywords[3]) < 0 || int.Parse(commandKeywords[3]) > rows) ||
            (int.Parse(commandKeywords[4]) < 0 || int.Parse(commandKeywords[4]) > cols))
            
        {
            isValidCommand = false;
        }

        return isValidCommand;
    }

    static string[,] SwapMatrixCells(string[,] matrix, int x1, int y1, int x2, int y2)
    {
        string container = matrix[x1, y1];
        matrix[x1, y1] = matrix[x2, y2];
        matrix[x2, y2] = container;

        return matrix;
    }

    static void PrintMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0, 4} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    static void Main(string[] args)
    {
        //creating and filling the matrix
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        string[,] matrix = FillMatrixFromConsole(rows, cols);

        //input list of commands
        List<string> commands = new List<string>();
        string inputCommands = String.Empty;

        while (inputCommands != "END")
        {
            inputCommands = Console.ReadLine();
            if (inputCommands != "END")
            {
                commands.Add(inputCommands);
            }
            else
            {
                break;
            }
        }

        for (int i = 0; i < commands.Count; i++)
        {
            char[] separators = new[] {' '};
            string[] commandKeywords = commands[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            bool isValidCommand = ValidateCommands(commands[i], rows, cols);

            if (isValidCommand == false)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input!");
                continue;
            }
            else
            {
                int cellOneRow = int.Parse(commandKeywords[1]);
                int cellOneCol = int.Parse(commandKeywords[2]);
                int cellTwoRow = int.Parse(commandKeywords[3]);
                int cellTwoCol = int.Parse(commandKeywords[4]);
                matrix = SwapMatrixCells(matrix, cellOneRow, cellOneCol, cellTwoRow, cellTwoCol);
                Console.WriteLine();
                PrintMatrix(matrix);
            }
        }
    }
}
