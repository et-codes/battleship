namespace Battleship
{
    public class InterfaceMethods
    {
        public void DisplaySeparator()
        {
            Console.WriteLine($"\n{new String('*', 80)}\n");
        }

        public void DisplayHeader(int turnsLeft, int hits, int misses)
        {
            Console.Clear();
            Console.WriteLine($"Rounds left: {turnsLeft}  Hits: {hits}  Misses: {misses}");
            DisplaySeparator();
        }

        public (int, int) GetCoordinates()
        {
            int x = GetCoordinate('X');
            int y = GetCoordinate('Y');
            return (x, y);
        }

        public int GetCoordinate(char axis)
        {
            bool isInvalid;
            int output;

            do
            {
                isInvalid = false;
                Console.Write($"Enter {axis} coordinate to fire upon [1 - 10]: ");
                string? xText = Console.ReadLine();
                if (!int.TryParse(xText, out output) || output < 1 || output > 10)
                {
                    isInvalid = true;
                    Console.WriteLine("Please enter an integer between 1 and 10.");
                }
            } while (isInvalid);

            // Translate the coordinate from 1-10 space to 0-9 space
            return output - 1;
        }

        public void PressKeyToContinue()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public void DisplayResult(int hits, Ship ship)
        {
            Console.Clear();
            if (hits == 5)
            {
                Console.WriteLine("YOU WON!\n");
                Console.WriteLine($"You sunk the enemy {ship.Name}!  Great job, Captain!");
            }
            else
            {
                Console.WriteLine("YOU LOST!\n");
                Console.WriteLine($"You don't have enough shells left to sink the {ship.Name}!");
                if (hits == 0)
                {
                    Console.WriteLine("You couldn't even find it, and have been demoted.  Go swab the deck!");
                }
                else
                {
                    Console.WriteLine("At least you found its location, and have disabled it.");
                    Console.WriteLine("The rest of the fleet will arrive soon to finish it off.");
                }
            }
        }

        public void DisplayIntro()
        {
            DisplaySeparator();
            Console.WriteLine("Welcome to the game of BATTLESHIP!");
            DisplaySeparator();
            Console.WriteLine("In this game your mission is to find the location of the enemy battleship.");
            Console.WriteLine("Your vessel only has 8 artillery rounds on board, and it takes hits to 5 critical");
            Console.WriteLine("points on the battleship's hull to sink her.  The only problem is the fog!  You");
            Console.WriteLine("don't know where the ship is!  You'll have to make some lucky guesses early on");
            Console.WriteLine("if you want to have enough rounds to sink the ship.\n");
            Console.WriteLine("Let us know when you are ready to begin your mission, Captain!\n");
        }

        public bool AskToContinue()
        {
            Console.WriteLine("\nYou don't have enough shells left to sink the ship.");
            Console.Write("Do you still want to continue? (y/n) ");
            return GetYesOrNo();
        }

        public bool AskToPlayAgain()
        {
            Console.Write("\nWould you like to play again? (y/n) ");
            return GetYesOrNo();
        }

        private bool GetYesOrNo()
        {
            var playerResponse = Console.ReadLine();
            return playerResponse == null ? false : (playerResponse.ToLower() == "y");
        }
    }
}
