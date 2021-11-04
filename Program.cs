using System;

namespace Mankalari
{
    class Program
    {
        static GameController game;
        static StartMenuController start;
        static void Main(string[] args)
        {
            start = new StartMenuController();
            start.QueryUser();

            game = start.GetGameController();
            game.StartGame();


            //Board b = new Board(4, players, 4, true);
            //Console.WriteLine(b.PrintBoard());
            //b.MakeMove(0, players[0]);
            //Console.WriteLine(b.PrintBoard());
        }


    }
}
