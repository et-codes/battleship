using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class GameBoard
    {
        public static int size = 10;
        public char[,] board = new char[size, size];

        public GameBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        public void DisplayBoard()
        {
            for (int i = size - 1; i >= 0; i--)
            {
                Console.Write((i+1).ToString().PadRight(2));
                for (int j = 0; j < size; j++)
                {
                    Console.Write($" {board[j, i]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("+  1  2  3  4  5  6  7  8  9  10");
        }

        public void Update(int x, int y, bool isHit)
        {
            board[x, y] = isHit ? 'X' : 'O';
        }
    }
}
