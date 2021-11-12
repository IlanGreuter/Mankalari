using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

namespace Mankalari
{
    class ConsoleInput : InputGetter
    {
        public override InputGetter GetInst()
        {
            inst ??= new ConsoleInput();
            return inst;
        }
        
        public override int AskInt(string message, int maxValue = 99) //get a non-negative int
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

        public override string AskString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        
        public override void ShowMessage(string message, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        public override void ShowMessage(string message, Color? textColor = null)
        {
            Console.WriteLine(message);
        }
    }
}
