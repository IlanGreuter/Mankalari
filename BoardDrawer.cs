using System;
using System.Collections.Generic;

namespace Mankalari
{
    public abstract class BoardDrawer
    {
        static BoardDrawer instance;

        public static BoardDrawer Instance
        {
            get { return instance; }
            set { if (instance is null) instance = value; } //
        }

        public abstract void DrawBoard(Board b, bool showIndex = false); //showIndex helps for debugging or for console version
    } 
}