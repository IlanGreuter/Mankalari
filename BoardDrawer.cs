using System;
using System.Collections.Generic;

namespace Mankalari
{
    public static class BoardDrawer
    {
        public static void DrawBoard(Board b, bool showIndex = false) //draws indexed board first (if wanted) then normal board
        {
            if (showIndex)
                DisplayBoard(b, true);
            DisplayBoard(b);
        }
        static void DisplayBoard(Board b, bool showIndex = false)
        {
            string board = "";
            bool leftToRight = false;

            for (int homeCupIndex = b.homeCups.Count - 1; homeCupIndex >= 0; homeCupIndex--) //foreach homecup (AKA row)
            {
                board += PrintRow(homeCupIndex, leftToRight, showIndex, b); 
                leftToRight = !leftToRight; //switch direction after row to show cups counter-clockwise
            }

            ConsoleColor c = showIndex ? ConsoleColor.Red : ConsoleColor.White;
            Messenger.Instance.ShowMessage(board, c);
        }

        static string PrintRow(int homeIndex, bool leftToRight, bool showIndex, Board b) //returns a string representing a row
        {
            string row = "|";

            int cupIndex = homeIndex * (b.cupsPerPlayer + (b.includeHomeCups ? 1 : 0)); //row's starting index
            int i = cupIndex + (leftToRight ? 0 : b.cupsPerPlayer - 1); //leftmost cup's index           

            while (i >= cupIndex && i < (cupIndex + b.cupsPerPlayer)) //while still in current row
            {
                string cupText = showIndex? i.ToString().PadLeft(2) : $"{b.GetCup(i)}"; //show either index or cup's points

                row += cupText + "|";
                i += leftToRight ? 1 : -1;
            }

            string home;
            if (showIndex) //show home's points, home's index (if it has one) or nothing
                home = b.includeHomeCups ? $" {cupIndex + b.cupsPerPlayer}".PadRight(3) : "   ";
            else
                home = b.homeCups[homeIndex].ToString();

            if (leftToRight) // add home and make sure it aligns
                row = "|   " + row + home + "|";
            else
                row = "|" + home + row + "   |";

            return row + "\n";
        }
    }
}