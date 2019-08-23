using System;
using System.Collections;
using System.Collections.Generic;
using ConfigManagementDemo.Helpers;

namespace ConfigManagementDemo
{
    public class MenuManager
    {
        private readonly List<string> _menuItems;

        public MenuManager(List<string> menuItems)
        {
            _menuItems = menuItems;
        }

        public void MainMenu()
        {
            Console.WriteLine("----- MAIN MENU -----");
            for (int i = 0; i < _menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_menuItems[i]}");
            }
            Console.WriteLine($"{_menuItems.Count + 1}) Exit Application");
        }

        public int GetMenuOption()
        {
            Console.WriteLine("------------------------");
            Console.Write("Select an option:  ");
            string input = Console.ReadLine();
            int option = 0;

            bool result = Int32.TryParse(input, out option);
            bool betweenValidRange = option > 0 && option <= _menuItems.Count;

            if (!result)
            {
                InvalidOptionMessage();
                return -1;
            }

            if (!betweenValidRange)
            {
                NotValidOption();
                return -1;
            }

            if (option == _menuItems.Count + 1) 
            {
                Application.Exit();
            }

            return option;
        }


        private void InvalidOptionMessage()
        {
            Console.WriteLine("Invalid Input");
            ConsoleHelper.PressAnyKeyMessage();
            Console.ReadKey();
        }


        private void NotValidOption()
        {
            Console.WriteLine("Not a valid option");
            ConsoleHelper.PressAnyKeyMessage();
            Console.ReadKey();
        }
    }
}
