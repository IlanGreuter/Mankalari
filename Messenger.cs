using System;

namespace Mankalari
{
    public abstract class Messenger
    {
        static Messenger instance;

        public static Messenger Instance
        {
            get { return instance; }
            set { if (instance is null) instance = value; } //
        }

        public abstract string AskString(string message); //ask for a string
        public abstract int AskInt(string message, int maxValue = 99); //ask for an integer
        public abstract void ShowMessage(string message, ConsoleColor textColor); //show a message
        public abstract int AskMoveInput(string message); //ask what move to do
        public abstract string AskGameMode(string message); //ask what game to play
    }
}