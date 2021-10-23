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
            throw new NotImplementedException();
        }

        public override void EndAtCup(int index, Player p)
        {
            throw new NotImplementedException();
        }

        public override void OnGameEnd(GameController control)
        {
            throw new NotImplementedException();
        }

    }
}
