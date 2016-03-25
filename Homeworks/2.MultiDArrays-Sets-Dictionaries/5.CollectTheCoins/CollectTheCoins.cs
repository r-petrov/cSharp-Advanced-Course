using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CollectTheCoins
{
    private static char[][] gameBoard;
    static int coinsCounter = 0;
    static int wallsHitCounter = 0;
    static int rowIndex = 0;
    static int colIndex = 0;
    static int correctRowIndex;
    static int correctColIndex;

    static void MakeMoves(char[] moves)
    {
        for (int i = 0; i < moves.Length; i++)
        {
            if (moves[i] == '<')
            {
                colIndex--;
                CheckForCoins();
            }
            else if(moves[i]=='>')
            {
                colIndex++;
                CheckForCoins();
            }
            else if(moves[i]=='^')
            {
                rowIndex--;
                CheckForCoins();
            }
            else if(moves[i]=='V')
            {
                rowIndex++;
                CheckForCoins();
            }
        }
    }

    static void CheckForCoins()
    {
        char currentCell = new char();
        try
        {
            currentCell = gameBoard[rowIndex][colIndex];
            if (currentCell == '$')
            {
                coinsCounter++;
            }
            correctRowIndex = rowIndex;
            correctColIndex = colIndex;
        }
        catch (IndexOutOfRangeException exc)
        {
            wallsHitCounter++;
            rowIndex = correctRowIndex;
            colIndex = correctColIndex;
        }
    }
    static void PrintResult(int coinsCounter, int wallsHitCounter)
    {
        Console.WriteLine("Coins collected: {0}\nWalls hit: {1}", coinsCounter, wallsHitCounter);
    }
    static void Main(string[] args)
    {
        gameBoard = new char[4][];
        for (int i = 0; i < gameBoard.Length; i++)
        {
            gameBoard[i] = Console.ReadLine().ToCharArray();
        }

        char[] commands = Console.ReadLine().ToCharArray();
        MakeMoves(commands);
        
        PrintResult(coinsCounter, wallsHitCounter);
    }
}
