using System;
using System.Linq;

namespace DiagonalDiffernce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                int[] col = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for(int j = 0; j < n; j++)
                {
                    matrix[i, j] = col[j];
                }

            }

            int sumLeft = 0;
            int sumRight = 0;
            for(int i = 0, j = n - 1; i < n && j >=0 ; i++, j --)
            {
                sumLeft += matrix[i, i];
                sumRight += matrix[i, j];
            }
            Console.WriteLine(Math.Abs(sumLeft - sumRight));
        }
    }
}
