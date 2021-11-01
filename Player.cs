using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalari
{
    class Player
    {
        string name;
        public int points = 0;

        public Player(string name)
        {
            this.name = name;
        }


        public int GetInput()
        {
            int input = -1;

            while (input < 0)
            {
                string txt = Console.ReadLine();
                int i;
                if (int.TryParse(txt, out i)) //make sure input is a number
                {
                    input = i;
                }
                else
                    Console.WriteLine("Input is not a number! Please write numbers only!");

                if (i < 0) //make sure input is positive
                {
                    Console.WriteLine("Negative numbers are not allowed!");
                    input = -1;
                }    
            }

            return input;
        }

    }
}
