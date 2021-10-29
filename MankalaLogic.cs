using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    class MankalaLogic : GameLogic
    {

        public MankalaLogic(Board b) : base(b)
        {

        }

        public override bool IsAllowed(int index, Player p)
        {
            return base.IsAllowed(index, p);
        }

        public override void EndAtCup(int index, Player p)
        {
            Cup c = board.GetCup(index);

            if (c.isHomeCup) //another turn if end in homecup
                playAgain = true;
            else if (c.points > 1) //end in non-empty cup (1 cuz move fills empty)
            {
                int i = board.MakeMove(index, p);
                EndAtCup(i, p);
            }
            else if (c.points == 1 && c.owner == p) //end in own empty cup
            {
                Cup opposite = board.GetCup(board.cups.Count - index);
                Cup home = board.GetHomeCup(p);
                home.points += opposite.points + 1;

                opposite.points = 0;
                c.points = 0;
            }
        }

        public override void OnGameEnd(GameController control)
        {
            //capture players' own pieces
            foreach (Cup c in board.cups)
            {
                c.owner.points += c.points;
            }
        }

    }
}
