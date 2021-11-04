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
            else if (c.points > 1) //end in non-empty cup (1 cuz move fills empty cups)
            {
                int i = board.MakeMove(index, p);
                ConsoleHelper.PrintToConsole($"Player {p.name} moves from {index}");
                board.PrintBoard();
                EndAtCup(i, p);
            }
            else if (c.points == 1 && c.owner == p) //end in own empty cup
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
