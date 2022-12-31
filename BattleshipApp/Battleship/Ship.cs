using System;
namespace Battleship
{
	public class Ship
	{
        public (int x, int y)[] Positions { get; set; }
        public string Name { get; set; }

        public Ship(int shipLength, string name)
		{
			Positions = new (int x, int y)[shipLength];
            Name = name;

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

            for (int i = 0; i < shipLength; i++)
            {
                Positions[i] = isHorizontal
                    ? (xStart + i, yStart)
                    : (xStart, yStart + i);
            }
        }

        public bool IsHit(int x, int y)
        {
            return Positions.Contains((x, y));
        }
	}
}

