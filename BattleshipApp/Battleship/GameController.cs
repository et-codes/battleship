using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class GameController
    {
        private bool gameOver = false;
        private int turnsLeft = 8;
        private int hits;
        private int misses;
        private GameBoard gameBoard = new GameBoard();
        private (int x, int y)[] battleship = new (int x, int y)[5]; 

        public GameController()
        {
            // Set battleship position
            var rand = new Random();
            int maxCoordinate = GameBoard.size - 5 - 1;
            int xStart;
            int yStart;

            bool isHorizontal = rand.Next(2) == 1;

            if (isHorizontal)
            {
                xStart = rand.Next(maxCoordinate);
                yStart = rand.Next(GameBoard.size - 1);
            }
            else
            {
                xStart = rand.Next(GameBoard.size - 1);
                yStart = rand.Next(maxCoordinate);
            }

            for (int i = 0; i < 5; i++)
            {
                battleship[i] = isHorizontal 
                    ? (xStart + i, yStart) 
                    : (xStart, yStart + i);
            }
        }

        public void Run()
        {
            while (!gameOver)
            {
                DisplayHeader();
                gameBoard.DisplayBoard();
                DisplayMethods.DisplaySeparator();

                var (x, y) = GetCoordinates();
                bool isHit = FireUpon(x, y);
                gameBoard.Update(x, y, isHit);

                turnsLeft--;
                if (turnsLeft < 5 - hits || hits == 5)
                {
                    gameOver = true;
                }
                DisplayMethods.PressKeyToContinue();
                Console.Clear();
            }
            DisplayMethods.DisplayResult(hits);
        }

        private void DisplayHeader()
        {
            Console.WriteLine($"Turns left: {turnsLeft}  Hits: {hits}  Misses: {misses}");
            DisplayMethods.DisplaySeparator();
        }

        private (int, int) GetCoordinates()
        {
            int x = GetCoordinate('X');
            int y = GetCoordinate('Y');
            return (x, y);
        }

        private int GetCoordinate(char axis)
        {
            bool isValid;
            int output;

            do
            {
                Console.Write($"Enter {axis} coordinate to fire upon [1 - 10]: ");
                string? xText = Console.ReadLine();
                isValid = int.TryParse(xText, out output);
            } while (!isValid && output < 1 && output > 10);

            // "Translate" the coordinate from 1-10 space to 0-9 space
            return output - 1;
        }

        public bool FireUpon(int x, int y)
        {
            if (battleship.Contains((x, y)))
            {
                Console.WriteLine("Hit!");
                hits++;
                return true;
            }
            else
            {
                Console.WriteLine("Miss!");
                misses++;
                return false;
            }
        }

    }
}
