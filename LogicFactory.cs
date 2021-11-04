using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    static class LogicFactory
    {

        public static GameLogic GetLogic(string gameType, Player[] players, int stonesPerCup, int cupsPerPlayer)
        {
            Board b;
            switch (gameType.ToUpper())//makes sure input is full caps
            {
                case "MANKALA":
                    b = new Board(cupsPerPlayer, players, stonesPerCup, true);
                    return new MankalaLogic(b);
                case "WARI":
                    b = new Board(cupsPerPlayer, players, stonesPerCup, false);
                    return new WariLogic(b);
                default:
                    throw new NotSupportedException(gameType + "is not a supported gametype");
            }
        }

    }
}
