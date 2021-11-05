using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    class WariLogic : GameLogic
    {
        public WariLogic(Board b) : base (b)
        {

        }

        protected override bool IsAllowed(int index, Player p)
        {
            return base.IsAllowed(index, p);
        }

        protected override void EndAtCup(int index, Player p)
        {
            Cup c = board.GetCup(index);
            if (c.owner != p && (c.points == 2 || c.points == 3)) //steal only if landed in opponents and it has 2 or 3 stones
            {
                Cup home = board.GetHomeCup(p);
                home.points += c.points;
                c.points = 0;
            }
        }

        public override void OnGameEnd(GameController control)
        {
            foreach (Cup home in board.homeCups)
            {
                home.owner.points = home.points;
            }
        }

    }
}
