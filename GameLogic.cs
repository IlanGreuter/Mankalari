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
        }

        public bool StartTurn(Player p)
        {
            playAgain = false;
            return board.IsSideEmpty(p);
        }

        public bool SelectCup(int index, Player p)
        {
            index %= board.cups.Count(); 

            if (IsAllowed(index, p))
            {
                board.MakeMove(index, p);
                return true;
            }
            else
                return false;
        }

        public virtual bool IsAllowed(int index, Player p)
        {
            Cup c = board.GetCup(index);
            if (c.owner == p && c.points > 0 && !c.isHomeCup)
            {
                return true;
            }
            return false;
        }

        public abstract void EndAtCup(int index, Player p);

        public abstract void OnGameEnd(GameController control);
         
    }
}
