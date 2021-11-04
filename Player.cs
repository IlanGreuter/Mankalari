using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    class Player
    {
        public string name;
        public int points = 0;

        public Player(string name)
        {
            this.name = name;
        }


        public int GetInput()
        {
            int input = InputHelper.QueryInt($"From where does Player {name} want to move?", 200);

            return input;
        }

    }
}
