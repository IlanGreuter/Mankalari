using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    class GameController
    {

        public GameLogic logic;
        public int currentPlayer;
        public Player[] players;

        public GameController(string gameType, Player[] players, int stonesPerCup, int cupsPerPlayer)
        {
            this.players = players;
            currentPlayer = 0; //TODO: Maybe make random

            logic = LogicFactory.GetLogic(gameType, players, stonesPerCup, cupsPerPlayer);
        }

        Player GetNextPlayer()
        {
            //TODO
            throw new NotImplementedException();
        }

        public void StartTurn()
        {
            if (!logic.StartTurn(players[currentPlayer])) //if no move is possible
                EndGame();
        }

        public void DoMove()
        {
            //TODO
        }

        public void StartGame()
        {
            //TODO
        }

        public void EndGame()
        {
            //TODO
        }

    }
}
