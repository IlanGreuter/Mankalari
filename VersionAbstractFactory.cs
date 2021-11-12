using System;
using System.Diagnostics;

namespace Mankalari
{
    public static class VersionAbstractFactory
    {
        public static void SetVersion(VersionTypes versionType)
        {
            switch (versionType)
            {
                //case VersionType.MonoGame:
                    //BoardDrawer.Instance = new MonoBoardDrawer();
                    //Messenger.Instance = new ConsoleMessenger();
                    //Break
                case VersionTypes.Console:
                default:
                    BoardDrawer.Instance = new BoardDrawerConsole();
                    Messenger.Instance = new ConsoleMessenger();
                    break;
            }
        }
    }

    public enum VersionTypes
    {
        Console
        //, Monogame
    }
}