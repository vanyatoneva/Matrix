using System;
using System.Linq;

namespace MaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimmensions = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            int rows = dimmensions[0];
            int cols = dimmensions[1];
            int[,] inputMatrix = new int[rows, cols];
            //Read user matrix
            for(int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();
                for(int j = 0; j < cols; j++)
                {
                    inputMatrix[i, j] = currentRow[j];
                }
            }

            //check max sum 3x3
            int maxSum = int.MinValue;
            int[,] matrixWithMaxSum = new int[3,3];

            maxSum = FindMaxMatrix(matrixWithMaxSum, inputMatrix);
            Console.WriteLine($"Sum = {maxSum}");
            for(int i = 0; i < matrixWithMaxSum.GetLength(0); i++)
            {
                for(int j = 0; j < matrixWithMaxSum.GetLength(1); j++)
                {
                    Console.Write($"{matrixWithMaxSum[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static int FindSumOfElements(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }

        public static int FindMaxMatrix(int[,] matrixWithMaxSum, int[,] inputMatrix)
        {

            int[,] currentMatrix = new int[3, 3];
            int maxSum = int.MinValue;
            for (int i = 0; i < (inputMatrix.GetLength(0) - 2); i++)
            {
                for (int j = 0; j < (inputMatrix.GetLength(1) - 2); j++)
                {
                    //nachalni tochki!
                    for(int k = i; k <= i + 2; k++)
                    {
                        for(int l = j; l <= j + 2; l++)
                        {
                            currentMatrix[k-i, l - j] = inputMatrix[k, l];
                        }
                    }
                    int currentSum = FindSumOfElements(currentMatrix);
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        for (int m = 0; m < currentMatrix.GetLength(0); m++)
                        {
                            for (int n = 0; n < currentMatrix.GetLength(1); n++)
                            {
                                matrixWithMaxSum[m, n] = currentMatrix[m, n];
                            }
                        }

                    }
                }
            }
            
            return maxSum;
        }
    }
}
