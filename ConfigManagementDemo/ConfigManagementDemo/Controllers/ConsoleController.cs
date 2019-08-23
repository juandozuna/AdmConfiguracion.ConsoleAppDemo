using System;
using System.Collections.Generic;

namespace ConfigManagementDemo
{
    public class ConsoleController
    {
        private readonly MenuManager _menuManager;
        private readonly List<string> _menu = new List<string>
        {
            "Add New CI", //1
            "List All CI", //2
            "Add CI dependency to CI", //3
            "Simulate Erasing CI", //4
            "Simulate Deprecating CI", //5
            "Simulate an Upgrade", //6
            "Credits"//7
        };

        public ConsoleController()
        {
            _menuManager = new MenuManager(_menu);
        }

        public void Start()
        {
            Header(); 
            _menuManager.MainMenu();
            int selectedOption = _menuManager.GetMenuOption();

            if (selectedOption == -1)
                Start();
            else
            {
                Console.WriteLine("Option is " + selectedOption);
            }
        }



        private void Header()
        {
            Clear();
            string headerText = "Welcome to CI Managment Console Software";
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (headerText.Length / 2)) + "}", headerText));
            Console.WriteLine("======================================== ");
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
