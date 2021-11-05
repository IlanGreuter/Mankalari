﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    class GameController
    {

        public GameLogic logic;
        public int currentPlayer;
        public Player[] players;

        public event PlayerEventDelegate OnStartTurn, OnGameEnd;
        public delegate void PlayerEventDelegate(Player p);

        public GameController(string gameType, Player[] players, int stonesPerCup, int cupsPerPlayer)
        {
            this.players = players;
            currentPlayer = 0; //TODO: Maybe make random

            logic = LogicFactory.GetLogic(gameType, players, stonesPerCup, cupsPerPlayer);
            EventLogger.SetEvents(logic.board, this);
            EventLogger.OnStartGame(gameType, cupsPerPlayer, stonesPerCup); //log message to help see where a certain game starts
        }

        void SetNextPlayer()
        {
            if (logic.playAgain) //let current player play again
            {
                logic.playAgain = false;
            }
            else //get next player in the row
            {
                currentPlayer++;
                currentPlayer %= players.Length;
                OnStartTurn?.Invoke(players[currentPlayer]);
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
                ConsoleHelper.PrintToConsole("Move not allowed, Make sure you move from your own, non-empty cup", ConsoleColor.DarkRed);
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
            foreach (Player p in players) //show player scores
            {
                ConsoleHelper.PrintToConsole($"Player {p.name} ended with {p.points} points! \n", ConsoleColor.Yellow);
            }
            EventLogger.OnGameEnd(); // 

        }

    }
}
