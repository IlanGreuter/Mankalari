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
        }


    }
}
