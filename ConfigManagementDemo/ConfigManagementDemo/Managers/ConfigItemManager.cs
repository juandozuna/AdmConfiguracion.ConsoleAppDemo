using System;
using System.Linq;
using ConfigManagementDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfigManagementDemo
{
    public class ConfigItemManager
    {
        private readonly ConsoleManager _consoleManager;
        private readonly AppDbContext _dbContext;
        private readonly string _goBackInput = "999";
        public ConfigItemManager()
        {
            _consoleManager = new ConsoleManager();
            _dbContext = new AppDbContext();
        }

        public void Create()
        {
            _consoleManager.Header("Create new Configuration Item");
            Console.WriteLine();

            ConfigurationItem newCiItem = GetCIFromUserInput();

            bool save = _consoleManager.ConfirmSave();
            if (save)
            {
                _dbContext.ConfigurationItems.Add(newCiItem);
                _dbContext.SaveChanges();
            }
            
            GoBack();
            
        }

        public void List()
        {
            Table table = new Table();
            table.SetHeaders("Name", "Description", "Responsible", "Version", "Dependencies");

            var cis = _dbContext.ConfigurationItems.Include(ci => ci.DependencyItems).ToHashSet();
            foreach (ConfigurationItem ci in cis)
            {
                table.AddRow(ci.Name, ci.Description, ci.Responsible, ci.Version, ci.DependencyItems.Count().ToString());
            }
            
            _consoleManager.Header("List of Configuration Items");
            string tableString = table.ToString();
            Console.WriteLine(tableString);
            _consoleManager.PressAnyKeyMessage();
            GoBack();
        }
        private ConfigurationItem GetCIFromUserInput()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine()?.ToUpper();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Responsible: ");
            string responsibe = Console.ReadLine()?.ToUpper();
            Console.Write("Version (0.0.0): ");
            string version = Console.ReadLine()?.ToUpper();

            return new ConfigurationItem
            {
                Name = name,
                Description = description,
                Responsible = responsibe,
                Version = version
            };
        }

        private void GoingBackMessage()
        {
            Console.WriteLine($"Write {_goBackInput} and press Enter, if you desire to go back");
        }
        
        private void GoBack()
        {
            _consoleManager.LoadFirstScreen();
        }
    }
}