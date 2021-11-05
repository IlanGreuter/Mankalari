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
        const string filePath = "../../../log.txt";//The path to the txt file. 
        //By default it wants to put the file where the debug console is in the bin folder so we have to go up a few files

        static StreamWriter file;
        public static void SetEvents(Board b, GameController controller)
        {
            b.OnMakeMove += OnMove;
            b.OnFillCup += OnFillCup;
            controller.OnStartTurn += OnStartTurn;
            controller.OnGameEnd += OnGameEnd;
        }

        public static void OnStartGame(string GameType, int cupsPerPlayer, int stonesPerCup)
        {
            file = new StreamWriter(filePath);  
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

        public static void OnGameEnd(object sender, EventArgs e) //finish log and close filestream
        {
            file.WriteLine("Game End");
            file.Close();
        }
    }
}
