using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    class MankalaLogic : GameLogic
    {
        //chaining moves on ending in a non-empty cup is a variant rule of mancala
        //it essentialy feels like the board is randomized after a move
        protected bool allowChainedMoves = true, stealAllowed = true; //can potentially be overwritten in a subclass

        public MankalaLogic(Board b) : base(b)
        {
        }

        protected override bool IsAllowed(int index, Player p)
        {
            return base.IsAllowed(index, p);
        }

        protected override void EndAtCup(int index, Player p)
        {
            Cup c = board.GetCup(index);

            if (c.isHomeCup) //another turn if end in homecup
                playAgain = true;
            else if (c.points > 1) //end in non-empty cup (1 cuz move fills empty cups)
            {
                if (allowChainedMoves)
                {
                    int i = board.MakeMove(index, p);
                    EndAtCup(i, p);
                }
            }
            else if (c.points == 1 && c.owner == p && stealAllowed) //end in own empty cup
            {
                Cup opposite = board.GetOppositeCup(index);
                if (opposite.points > 0) // only steal if opposite cup is empty
                {
                    Cup home = board.GetHomeCup(p);
                    home.points += opposite.points + 1;

                    opposite.points = 0;
                    c.points = 0;
                }
            }
        }

        public override void OnGameEnd(GameController control)
        {
            //in most versions at the end of the game the players add all their stones from their own cups to their score
            //this rule wasn't mentioned in the assignment but we added it anyway
            foreach (Cup c in board.cups) //capture players' own pieces
            {
                c.owner.points += c.points;
            }
        }
    }
}
