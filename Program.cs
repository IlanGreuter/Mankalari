using System;

namespace Mankalari
{
    class Program
    {
        static Player[] players = { new Player("1"), new Player("2") };

        static void Main(string[] args)
        {
            Board b = new Board(6, players, 4, true);
            Console.WriteLine(b.PrintBoard());
            b.MakeMove(12, players[0]);
            Console.WriteLine(b.PrintBoard());
        }
    }
}
