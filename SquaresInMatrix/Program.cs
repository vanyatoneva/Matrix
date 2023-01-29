using System;
using System.Linq;

namespace SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];
            int sqares = 0;
            for(int i = 0; i < rows; i++)
            {
                int[] currCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for(int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currCol[j];
                }
            }
            for(int i = 0; i < rows - 2; i++)
            {
                for(int j = 0; j < cols - 2; j++)
                {
                    if(matrix[i, j] == matrix[i, j + 1])
                    {
                        if (matrix[i + 1,j] == matrix[i+1, j + 1])
                        {
                            sqares++;
                        }
                    }
                }
            }
            Console.WriteLine(sqares);
        }
    }
}
