using Core.Interfaces;
using System;

namespace GameZoneStore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start Store menu
            StoreMainMenu mainMenu = new StoreMainMenu();
            mainMenu.RunMainMenu();

        }

    }
}
