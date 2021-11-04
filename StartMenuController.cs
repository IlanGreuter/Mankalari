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
        //public string[] names;
        static Player[] players = { new Player("1"), new Player("2") };
        const int maxValue = 99;


        public void QueryUser()
        {
            while (gameType == "")
            {
                string ans = ConsoleHelper.AskUser("Would you like to play Mankala or Wari?");
                ans = ans.ToUpper();
                if (ans == "MANKALA" || ans == "WARI")
                    gameType = ans;
            }
            cupsPerPlayer = ConsoleHelper.QueryInt($"Enter how many cups you want per player (between 1 and {maxValue}).");
            stonePerCup = ConsoleHelper.QueryInt($"Enter how many stones each cup should start with (between 1 and {maxValue})");
        }




        public GameController GetGameController()
        {
            //create the players from the names, currently disabled 
            //Player[] players = new Player[names.Length];
            //for (int i = 0; i < names.Length; i++)
                //players[i] = new Player(names[i]);

            return new GameController(gameType, players, stonePerCup, cupsPerPlayer);
        }
    }
}
