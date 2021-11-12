using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    class StartMenuController
    {
        public string gameType = "";
        public int stonePerCup;
        public int cupsPerPlayer;
        static Player[] players = { new Player("1"), new Player("2") };
        const int maxValue = 99;


        public void QueryUser()
        {
            while (gameType == "")
            {
                string ans = Messenger.Instance.AskGameMode("Would you like to play Mankala or Wari?");
                ans = ans.ToUpper();
                if (VerifyGameMode(ans))
                    gameType = ans;
            }
            cupsPerPlayer = Messenger.Instance.AskInt($"Enter how many cups you want per player (between 1 and {maxValue}).");
            stonePerCup = Messenger.Instance.AskInt($"Enter how many stones each cup should start with (between 1 and {maxValue})");
        }

        public bool VerifyGameMode(string gameMode)
        {
            if (gameMode == "MANKALA" || gameMode == "MANCALA") 
                return true;
            if (gameMode == "WARI")
                return true;

            return false;
        }


        public GameController GetGameController()
        {
            return new GameController(gameType, players, stonePerCup, cupsPerPlayer);
        }
    }
}
