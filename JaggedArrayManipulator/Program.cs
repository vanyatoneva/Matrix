using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for(int i = 0; i < rows; i++)
            {
                jaggedArray[i] = (Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray());
            }
            FirstManipulate(jaggedArray);

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "End")
            {
                if (command[0] == "Add")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);
                    if(row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] += value;
                    }
                }
                else if (command[0] == "Subtract")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);
                    if (row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for(int i = 0; i < jaggedArray.Length; i++)
            {
                for(int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void FirstManipulate(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length - 1; i ++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] *= 2;
                        jaggedArray[i + 1][j] *= 2;
                    }
                }
                else
                {

                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] /= 2;
                    }
                    for(int k = 0; k < jaggedArray[i+1].Length; k++)
                    {
                        jaggedArray[i+1][k] /= 2;
                    }
                }
            }
        }
    }
}
