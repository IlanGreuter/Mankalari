using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    class Board
    {
        public List<Cup> cups, homeCups;
        public int cupsPerPlayer;
        public bool includeHomeCups;

        public Board(int cupsPerPlayer, Player[] players, int stonesPerCup, bool includeHomeCups)
        {
            this.cupsPerPlayer = cupsPerPlayer;
            this.includeHomeCups = includeHomeCups;

            cups = new List<Cup>();
            homeCups = new List<Cup>(); 

            foreach (Player p in players)
            {
                Cup homecup = new Cup(0, p, true); //player's home cup
                homeCups.Add(homecup);

                for (int i = 0; i < cupsPerPlayer; i++)
                    cups.Add(new Cup(stonesPerCup, p)); //player's normal cups

                if(includeHomeCups) //if homecups participate, mix them in with the regular cups.
                    cups.Add(homecup); 
            }
        }

        public int MakeMove(int index, Player p)
        {
            int moves = cups[index].points;
            cups[index].points = 0; //take the stones out of the cup

            for (int i = ++index; i < index + moves; ++i) // go over the next cups
            {
                Cup c = GetCup(i);
                if (c.isHomeCup && c.owner != p) //dont fill opponent's homecup
                {
                    moves++;
                }
                else //fill other cups, including our own homecup if it is in the cups list
                {
                    c.points++;
                }
            }
            return index + moves;
        }

        public Cup GetCup(int index)
        {
            return cups[index % cups.Count];
        }

        public bool IsSideEmpty(Player p)
        {
            bool sideEmpty = true;
            foreach (Cup c in cups)
            {
                if (c.owner == p && c.points > 0 && !c.isHomeCup)
                    sideEmpty = false;
            }
                return sideEmpty;
        }

        public Cup GetHomeCup(Player p)
        {
            foreach (Cup c in homeCups)
            {
                if (c.owner == p)
                    return c;
            }
            return null;
        }

        public string PrintBoard()
        {
            string board = "";
            bool leftToRight = false;

            for (int homeCupIndex = homeCups.Count - 1; homeCupIndex >= 0; homeCupIndex--)
            {
                board += PrintRow(homeCupIndex, leftToRight);
                leftToRight = !leftToRight;
            } 

            return board;
        }

        public string PrintRow(int homeIndex, bool leftToRight)
        {
            string row = "|"; 
            string home = homeCups[homeIndex].ToString();

            int cupIndex = homeIndex * (cupsPerPlayer + (includeHomeCups? 1 : 0));
            int i = cupIndex + (leftToRight ? 0 : cupsPerPlayer - 1);            

            while (i >= cupIndex && i < (cupIndex + cupsPerPlayer)) //while still in row
            {
                Cup c = GetCup(i);
                row += c + "|";

                i += leftToRight ? 1 : -1;
            }

            if (leftToRight)
            {
                row = "|   " + row + home + "|";
            }
            else
            {
                row = "|" + home + row + "   |";
            }

            return row + "\n";
        }

    }
}
