namespace Battleship
{
    internal class GameController
    {
        private (int x, int y)[] battleship = new (int x, int y)[5];

        public GameController()
        {
            // Set battleship orientation and position
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
            bool gameOver = false;
            int roundsLeft = 8;
            int hits = 0;
            int misses = 0;
            bool keepPlaying = false;
            GameBoard gameBoard = new();

            while (!gameOver)
            {
                InterfaceMethods.DisplayHeader(roundsLeft, hits, misses);
                gameBoard.DisplayBoard();
                InterfaceMethods.DisplaySeparator();

                var (x, y) = GetCoordinates();
                bool isHit = battleship.Contains((x, y));

                if (isHit && gameBoard.AlreadyHit(x, y))
                {
                    Console.WriteLine("UHHH, you already hit that part of the ship, Cap'n.");
                    Console.WriteLine("While it may feel good, it doesn't make the ship sink any faster!");
                }
                else if (isHit)
                {
                    Console.WriteLine("BOOM!  DIRECT HIT!");
                    hits++;
                }
                else
                {
                    Console.WriteLine("SPLASH!  MISS!");
                    misses++;
                }
                roundsLeft--;

                gameBoard.Update(x, y, isHit);

                if (hits == 5 || roundsLeft == 0)
                {
                    gameOver = true;
                }
                else if (roundsLeft - 5 + hits < 0 && !keepPlaying)
                {
                    keepPlaying = InterfaceMethods.AskToContinue();
                    gameOver = !keepPlaying;
                }
                else
                {
                    InterfaceMethods.PressKeyToContinue();
                }
            }
            InterfaceMethods.DisplayResult(hits);
        }

        private (int, int) GetCoordinates()
        {
            int x = InterfaceMethods.GetCoordinate('X');
            int y = InterfaceMethods.GetCoordinate('Y');
            return (x, y);
        }
    }
}
