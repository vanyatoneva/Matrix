using System;
using System.Linq;

namespace SnakePath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimmensions = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            char[,] snakePath = new char[dimmensions[0], dimmensions[1]];
            char[] snake = Console.ReadLine().ToCharArray();
            int snakeIndex = 0;
            for(int i = 0; i < snakePath.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < snakePath.GetLength(1); j++)
                    {
                        snakePath[i, j] = snake[snakeIndex++];
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int j = snakePath.GetLength(1) - 1; j >=0; j--)
                    {
                        snakePath[i, j] = snake[snakeIndex++];
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
            }

            for(int i = 0; i < snakePath.GetLength(0); i++)
            {
                for(int j = 0; j < snakePath.GetLength(1); j++)
                {
                    Console.Write($"{snakePath[i,j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
