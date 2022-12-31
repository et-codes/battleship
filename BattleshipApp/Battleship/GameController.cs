namespace Battleship
{
    internal class GameController
    {
        private Ship battleship = new Ship(5);
        private readonly InterfaceMethods interfaceMethods;
        int roundsLeft = 8;
        int hits = 0;
        int misses = 0;
        GameBoard gameBoard = new();

        public GameController(InterfaceMethods interfaceInstance)
        {
            interfaceMethods = interfaceInstance;
        }

        public void Run()
        {
            bool gameOver = false;
            bool stopPlaying = true;

            while (!gameOver)
            {
                DisplayGameBoard();

                var (x, y) = interfaceMethods.GetCoordinates();
                bool isHit = battleship.IsHit(x, y);

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

                gameOver = hits == 5 || roundsLeft == 0;

                if (!gameOver && roundsLeft - 5 + hits < 0 && stopPlaying)
                {
                    stopPlaying = !interfaceMethods.AskToContinue();
                    gameOver = stopPlaying;
                }
                else
                {
                    interfaceMethods.PressKeyToContinue();
                }
            }
            interfaceMethods.DisplayResult(hits);
        }

        private void DisplayGameBoard()
        {
            interfaceMethods.DisplayHeader(roundsLeft, hits, misses);
            gameBoard.DisplayBoard();
            interfaceMethods.DisplaySeparator();
        }
    }
}
