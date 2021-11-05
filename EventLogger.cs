using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Mankalari
{
    static class EventLogger 
    {
        const bool logFillCup = true; //disable so log doesn't get bloated with "added stone to X" messages

        static StreamWriter file = new StreamWriter("../../../log.txt");//"log.txt");//Path.GetDirectoryName("log.txt"));//@"\log.txt"); // The directory to the txt file.

        public static void SetEvents(Board b, GameController controller)
        {
            b.OnMakeMove += OnMove;
            b.OnFillCup += OnFillCup;
            controller.OnStartTurn += OnStartTurn;
        }

        public static void OnStartGame(string GameType, int cupsPerPlayer, int stonesPerCup)
        {
            file.WriteLine($"Starting a new game of {GameType} with {cupsPerPlayer} cups per player filled with {stonesPerCup} stones each");
        }

        static void OnStartTurn(Player p)
        {
            file.WriteLine($"Player {p.name} starts their turn");
        }

        static void OnMove(int index, Cup c, Player p)
        {
            file.WriteLine($"Player {p.name} moves {c.points} stones from index {index}");
        }

        static void OnFillCup(int index, Cup c, Player p)
        {
            if (logFillCup) 
                file.WriteLine($"Cup {index} is now at {c.points}");
        }

        public static void OnGameEnd()
        {
            file.WriteLine("Game End");
            file.Close();
        }

    }
}
