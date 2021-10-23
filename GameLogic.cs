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
        }

        public bool StartTurn(Player p)
        {
            playAgain = false;
            return board.IsSideEmpty(p);
        }

        public bool SelectCup(int index, Player p)
        {
            if (IsAllowed(index, p))
            {
                board.MakeMove(index, p);
                return true;
            }
            else
                return false;
        }

        public abstract bool IsAllowed(int index, Player p);

        public abstract void EndAtCup(int index, Player p);

        public abstract void OnGameEnd(GameController control);

        public bool CanPlayAgain()
        {
            return playAgain;
        }
 
    }
}
