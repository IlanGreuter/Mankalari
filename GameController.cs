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
        public bool ongoing;

        public GameController(string gameType, Player[] players, int stonesPerCup, int cupsPerPlayer)
        {
            this.players = players;
            currentPlayer = 0; //TODO: Maybe make random

            logic = LogicFactory.GetLogic(gameType, players, stonesPerCup, cupsPerPlayer);
        }

        void SetNextPlayer()
        {
            if (logic.playAgain)
            {
                logic.playAgain = false;
            }
            else
            {
                currentPlayer++;
                currentPlayer %= players.Length;
            }
        }

        public void StartTurn()
        {
            if (!logic.StartTurn(players[currentPlayer])) //if no move is possible
                EndGame();
            else
                DoMove();
        }

        public void DoMove()
        {
            
            int cupIndex = players[currentPlayer].GetInput();

            if (logic.SelectCup(cupIndex, players[currentPlayer])) //if the move was allowed
            {
                SetNextPlayer();
            }
            else
            {
                Console.WriteLine("Move not allowed, please make sure you move from your own cup");
            }
            StartTurn();
        }

        public void StartGame()
        {
            foreach (Player p in players) //reset the scores
                p.points = 0;

            StartTurn();
        }

        public void EndGame()
        {
            logic.OnGameEnd(this);
            foreach (Player p in players)
            {
                Console.WriteLine($"Player {p.name} ended with {p.points} points! \n");
            }
            ongoing = false;

        }

    }
}
