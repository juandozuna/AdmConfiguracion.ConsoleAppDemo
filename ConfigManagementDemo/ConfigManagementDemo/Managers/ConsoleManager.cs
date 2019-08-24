using System;
using System.Collections.Generic;

namespace ConfigManagementDemo
{
    public class ConsoleManager
    {
        private readonly MenuManager _menuManager;
        private readonly List<string> _menu = new List<string>
        {
            "Add New CI", //1
            "List All CI", //2
            "Add CI dependency to CI", //3
            "Impact of Erasing CI", //4
            "Impact of  Deprecating CI", //5
            "Impact of an Upgrade", //6
            "Credits"//7
        };

        private readonly Dictionary<int, Action> _options;

        public ConsoleManager()
        {
            _menuManager = new MenuManager(_menu);
            _options = new Dictionary<int, Action>
            {
                {1, AddNewCiOption},
                {2, ListAllCIs},
                {3, AddDependencyToCi},
                {4, ImpactOfErasing},
                {5, ImpactOfDeprecating},
                {6, ImpactOfUpdate},
                {7, Credits}
            };
        }

        public void Start()
        {
            LoadFirstScreen();
        }


        public void LoadFirstScreen()
        {
            Header(); 
            _menuManager.MainMenu();
            int selectedOption = _menuManager.GetMenuOption();

            if (selectedOption == -1)
                LoadFirstScreen();
            else
            {
                _options[selectedOption]();
            }
        }

        public void Header(string subtitle = "")
        {
            Clear();
            string headerText = "Welcome to CI Managment Console Software";
            Console.WriteLine(headerText);
            Console.WriteLine("======================================== ");

            if (subtitle != string.Empty)
            {
                Console.WriteLine($"--- {subtitle.ToUpper()} ---");
                Console.WriteLine("---------" + new string('-', subtitle.Length));
            }
        }

        public bool ConfirmSave(string message = "Do you want to save?")
        {
            Console.WriteLine();
            Console.Write($"{message} (Y/N) -> ");

            string response = Console.ReadLine()?.ToUpper();

            if (response == "Y")
                return true;
            return false;
        }
        
        public void PressAnyKeyMessage(string message = "Press any key to continue...")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
        
        private void AddNewCiOption()
        {
            var configManager = new ConfigItemManager();
            configManager.Create();
        }
        private void ListAllCIs()
        {
            var configManager = new ConfigItemManager();
            configManager.List();
        }

        private void AddDependencyToCi()
        {
            
        }

        private void ImpactOfErasing()
        {
            
        }


        private void ImpactOfDeprecating()
        {
            
        }

        private void ImpactOfUpdate()
        {
            
        }

        private void Credits()
        {
            
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
