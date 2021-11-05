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
        static List<string> logs = new List<string>();
        const bool logFillCup = true; //disable so log doesn't get bloated with "added stone to X" messages

        //static StreamWriter file = new StreamWriter();

        public static void SetEvents(Board b, GameController controller)
        {
            b.OnMakeMove += OnMove;
            b.OnFillCup += OnFillCup;
            controller.OnStartTurn += OnStartTurn;
        }

        public static void OnStartGame(string GameType, int cupsPerPlayer, int stonesPerCup)
        {
            logs.Add($"Starting a new game of {GameType} with {cupsPerPlayer} cups per player filled with {stonesPerCup} stones each");
        }

        static void OnStartTurn(Player p)
        {
            logs.Add($"Player {p.name} starts their turn");
        }

        static void OnMove(int index, Cup c, Player p)
        {
            logs.Add($"Player {p.name} makes {c.points} moves from index {index}");
        }

        static void OnFillCup(int index, Cup c, Player p)
        {
            if (logFillCup) 
                logs.Add($"Cup {index} is now at {c.points}");
        }

    }
}
