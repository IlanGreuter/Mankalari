using System;

namespace Mankalari
{
    public class ConsoleMessenger : Messenger
    {
        public override string AskString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public override int AskInt(string message, int maxValue = 99)
        {
            int i = -1;
            while (i < 0)
            {
                string ans = AskString(message);
                int num;
                if (int.TryParse(ans, out num))
                {
                    i = Math.Clamp(num, 0, maxValue);
                }
            }
            return i;
        }

        public override void ShowMessage(string message, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        public override int AskMoveInput(string message) //use ask int
        {
            return AskInt(message, int.MaxValue);
        }

        public override string AskGameMode(string message) //use ask message
        {
            return AskString(message);
        }
    }
}