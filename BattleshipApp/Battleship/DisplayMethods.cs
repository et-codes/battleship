using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public static class DisplayMethods
    {
        public static void DisplaySeparator()
        {
            Console.WriteLine();
            Console.WriteLine(new String('*', 80));
            Console.WriteLine();
        }

        public static void PressKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void DisplayResult(int hits)
        {
            if (hits == 5)
            {
                Console.WriteLine("YOU WIN!");
                Console.WriteLine("You sunk my BATTLESHIP!");
            }
            else
            {
                Console.WriteLine("YOU LOSE!");
                Console.WriteLine("You don't have enough turns left to sink the battleship!");
            }
        }
    }
}
