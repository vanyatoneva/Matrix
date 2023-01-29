using System;
using System.Linq;

namespace SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] rowsAndCols = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
           //if(rows < 0 && cols < 0)
           // {
           //     Console.WriteLine(0);
           //     return;
          //  }
            
            char[,] matrix = new char[rows, cols];
            int sqares = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currCol[j];
                }
            }
            if (rows < 2 || cols < 2)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] 
                        && matrix[i, j] == matrix[i + 1, j] 
                        && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                             sqares++;
                    }
                }
            }
            Console.WriteLine(sqares);
        }
    }
}
