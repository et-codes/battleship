using Battleship;

var interfaceMethods = new InterfaceMethods();

interfaceMethods.DisplayIntro();
interfaceMethods.PressKeyToContinue();

bool playAgain;
do
{
    var game = new GameController(interfaceMethods);
    game.Run();
    playAgain = interfaceMethods.AskToPlayAgain();
} while (playAgain);
