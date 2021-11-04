using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    static class InputHelper
    {
        public static int QueryInt(string message, int maxValue = 99) //Ask the user for a non-negative int
        {
            int i = -1;
            while (i < 0)
            {
                string ans = AskUser(message);
                int num;
                if (int.TryParse(ans, out num))
                {
                    i = Math.Clamp(num, 0, maxValue);
                }
            }
            return i;
        }

        public static string AskUser(string message) //ask user a question and return the user's answer
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

    }
}
