﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    public class Cup
    {
        public int points;
        public Player owner;
        public bool isHomeCup;

        public Cup(int startingPoints, Player owner, bool ishomecup = false)
        {
            points = startingPoints;
            this.owner = owner;
            isHomeCup = ishomecup;
        }

        public override string ToString()
        {
            return (isHomeCup? " " : "") + points.ToString().PadRight(2);
        }

    }
}
