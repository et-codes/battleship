/*
Rules
    Project written in C# (.NET Core)
    Game grid will be 10x10
    User will be allowed 8 guesses
    When the battleship is hit 5 times it is considered sunk
Deliverables
    Computer will randomly assign it’s battleship within the dimensions of the grid
    The user will be prompted to select a grid to fire at.
    After each hit/miss, the user will be informed of all prior results
    If a user inputs an incorrect value, user will be notified of the error and re-prompted
*/

using Battleship;

GameBoard board= new GameBoard();
board.DisplayBoard();


