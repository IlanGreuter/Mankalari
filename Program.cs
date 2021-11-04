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

            string ans = "Y";
            while(ans == "Y" || ans == "yes" || ans == "Yes") //allow multipe spellings
            {
                StartGame();
                string playagain = ConsoleHelper.AskUser("Play Again? Y/N");
                ans = playagain;
            }


        }

        static void StartGame()
        {
            game = start.GetGameController();
            game.StartGame();
        }

    }
}
