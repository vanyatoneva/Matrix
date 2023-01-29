using System;
using System.Threading;

namespace KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] currentLine = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = currentLine[j];
                }
            }
            int removedKnights = 0;
            int attackingMaxKnights = 0;
            int rowPos = -1;
            int colPos = -1;
            while (true)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == 'K')
                        {
                            int attackedKnigths = CountAttacked(i, j, board);
                            if (attackedKnigths > attackingMaxKnights)
                            {
                                attackingMaxKnights = attackedKnigths;
                                rowPos = i;
                                colPos = j;
                            }
                        }
                    }
                }
                if (attackingMaxKnights == 0)
                {
                    break;
                }
                board[rowPos, colPos] = '0';
                attackingMaxKnights = 0;
                rowPos = -1;
                colPos = -1;
                removedKnights++;
            }
            Console.WriteLine(removedKnights);
        }

        private static int CountAttacked(int row, int col, char[,] board)
        {
            //0K0K0
            //K000K
            //00K00
            //K000K
            //0K0K0
            int attackedKnigths = 0;
            //one left/right
            if (row + 1 < board.GetLength(0) && col + 2 < board.GetLength(1))
            {
                if (board[row + 1, col +2] == 'K')
                {
                    attackedKnigths++;
                }
            }
            if (row - 1 >= 0 && col + 2 < board.GetLength(1))
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    attackedKnigths++;
                }
            }
            if (row + 1 < board.GetLength(0) && col - 2 >= 0)
            {
                if (board[row +1 , col - 2] == 'K')
                {
                    attackedKnigths++;
                }
            }
            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    attackedKnigths++;
                }
            }

           // two left/ right
            if (row + 2 < board.GetLength(0) && col + 1 < board.GetLength(1))
            {
                if (board[row + 2, col + 1] == 'K')
                {
                    attackedKnigths++;
                }
            }
            if (row + 2 < board.GetLength(0) && col - 1 >= 0)
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    attackedKnigths++;
                }
            }
            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    attackedKnigths++;
                }
            }
            if (row - 2 >= 0 && col + 1 < board.GetLength(1))
            {
                if (board[row - 2, col + 1] == 'K')
                {
                    attackedKnigths++;
                }
            }
            return attackedKnigths;
        }
    }
}
