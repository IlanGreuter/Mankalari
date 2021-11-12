using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mankalari
{
    public abstract class InputGetter
    {
        protected InputGetter inst;
        public abstract InputGetter GetInst();
        public abstract int AskInt(string message, int maxValue = 99);
        public abstract string AskString(string message); 
        public abstract void ShowMessage(string message, ConsoleColor textColor = ConsoleColor.White);
        public abstract void ShowMessage(string message, Color? textColor = null); //Color.White isnt a compile time constant so this is a workaround
    }
}
