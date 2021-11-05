using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    abstract class GameLogic
    {
        public Board board;
        public bool playAgain;

        public GameLogic(Board b)
        {
            board = b;
            playAgain = false;

            b.OnMakeMove += OnMoveEvent;
        }

        public bool StartTurn(Player p) //returns false if no move is possible
        {
            board.PrintBoard(true); //print board's indexes to help players see what index each cup has
            board.PrintBoard(); //print actual board displaying stones in each cup
            playAgain = false;
            return !board.IsSideEmpty(p);
        }

        public bool SelectCup(int index, Player p) //returns true if a move is allowed from that cup
        {
            index %= board.cups.Count; 

            if (IsAllowed(index, p))
            {
                int i = board.MakeMove(index, p);
                EndAtCup(i, p);
                return true;
            }
            else
                return false;
        }

        public virtual bool IsAllowed(int index, Player p) //returns true if a move should be allowed according to the game's rules
        {
            Cup c = board.GetCup(index);
            if (c.owner == p && c.points > 0 && !c.isHomeCup)
            {
                return true;
            }
            return false;
        }

        public void OnMoveEvent(int index, Cup c, Player p) //draw the board after the player moves
        {
            ConsoleHelper.PrintToConsole($"Player {p.name} moves from {index}", ConsoleColor.Cyan);
        }

        public abstract void EndAtCup(int index, Player p);

        public abstract void OnGameEnd(GameController control);
         
    }
}
