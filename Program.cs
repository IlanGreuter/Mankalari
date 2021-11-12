using System;

namespace Mankalari
{
    class Program
    {
        static GameController game;
        static StartMenuController start;
        static void Main(string[] args)
        {
            VersionFactory.SetVersion(VersionTypes.Console);
            
            start = new StartMenuController();
            start.QueryUser();

            string ans = "Y";
            while(ans == "Y" || ans == "yes" || ans == "Yes") //allow multiple spellings
            {
                StartGame();
            
                string playagain = Messenger.Instance.AskString("Play Again? Y/N");
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
