using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.TargetPractice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            string inputDimensions = Console.ReadLine();
            string[] dimensionsStr = inputDimensions.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int n;
            int m;

            while ((int.TryParse(dimensionsStr[0], out n) == false || int.TryParse(dimensionsStr[1], out m) == false) ||
                   (int.Parse(dimensionsStr[0]) < 1 || int.Parse(dimensionsStr[0]) > 12) || (int.Parse(dimensionsStr[1]) < 1 || int.Parse(dimensionsStr[1]) > 12))
            {
                inputDimensions = Console.ReadLine();
                dimensionsStr = inputDimensions.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            n = int.Parse(dimensionsStr[0]);
            m = int.Parse(dimensionsStr[1]);

            char[,] stairsMatrix = new char[n,m];

            string snake = Console.ReadLine();
            while (snake.IndexOf(" ") != -1)
            {
                snake = Console.ReadLine();
            }

            string[] shotParameters = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            int row;
            int col;
            int radius;

            while ((int.TryParse(shotParameters[0], out row) == false 
                || int.TryParse(dimensionsStr[1], out col) == false 
                || int.TryParse(dimensionsStr[2], out radius) == false) 
                || (int.Parse(shotParameters[0]) < 0 || int.Parse(shotParameters[0]) > n - 1)
                   || (int.Parse(shotParameters[1]) < 0 || int.Parse(shotParameters[1]) > m - 1) 
                   || (int.Parse(shotParameters[2]) < 0 || int.Parse(shotParameters[2]) > 4))
            {
                shotParameters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            row = int.Parse(shotParameters[0]);
            col = int.Parse(shotParameters[1]);
            radius = int.Parse(shotParameters[2]);

            int counter = 0;

            for (int i = stairsMatrix.GetLength(0) - 1; i >= 0; i--)
            {
                
            }
        }


        
    }
}
