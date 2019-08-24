using System;
using System.Collections.Generic;
using System.Linq;
using ConfigManagementDemo.Models;

namespace ConfigManagementDemo
{
    public class ReportManager
    {
        private readonly AppDbContext _dbContext;
        private readonly ConfigItemManager _configItemManager;
        private readonly ConsoleManager _consoleManager;
        
        public ReportManager(ConsoleManager consoleManager)
        {
            _dbContext = new AppDbContext();
            _configItemManager = new ConfigItemManager(consoleManager);
            _consoleManager = consoleManager;
        }

        public void ErasingImpact()
        {
            _consoleManager.Header("Check impact of deleting a CI");
            _configItemManager.MicroTableList();
            Console.Write("Write name of node: ");
            string name = Console.ReadLine()?.ToUpper();
            
            var foundCi = _dbContext.ConfigurationItems.Find(name);
            if (foundCi == null)
            {
                _consoleManager.PressAnyKeyMessage("CI was not found in the system...");
                _consoleManager.LoadFirstScreen();
            }

            CINode node = BuiildNodesForCI(new CINode {Value = foundCi});
            PrintNodeToEraseForCi(node);
            
            _consoleManager.PressAnyKeyMessage();
            _consoleManager.LoadFirstScreen();
        }

        public void DeprecateImpact()
        {
            _consoleManager.Header("Check impact to deprecate a CI");
            _configItemManager.MicroTableList();
            Console.Write("Write name of node: ");
            string name = Console.ReadLine()?.ToUpper();
            
            var foundCi = _dbContext.ConfigurationItems.Find(name);
            if (foundCi == null)
            {
                _consoleManager.PressAnyKeyMessage("CI was not found in the system...");
                _consoleManager.LoadFirstScreen();
            }

            CINode node = BuiildNodesForCI(new CINode {Value = foundCi});
            PrintNodeToDeprecate(node, node.Value.Name);
            
            _consoleManager.PressAnyKeyMessage();
            _consoleManager.LoadFirstScreen();
        }

        public CINode BuiildNodesForCI(CINode node, int level = 0)
        {
            var children = _dbContext.DependencyItems.Where(di => di.BaseCiName == node.Value.Name)
                .Select(di => new CINode {Value = di.DependencyCi}).ToList();

            if (!children.Any())
                return null;
            
            var resultNodes = new List<CINode>();
            
            foreach (var ciNode in children)
            {
                var fnode = BuiildNodesForCI(ciNode, level + 1);
                if (fnode != null)
                    resultNodes.Add(fnode);
                else 
                    resultNodes.Add(ciNode);
            }

            node.Nodes = resultNodes;

            if (level != 0)
                return null;
            return node;
        }

        public void PrintNodeToEraseForCi(CINode node, int level = 0)
        {
            if (node == null)
                return;
            
            Console.Write('|');
            Console.Write(new string('-', level));
            Console.Write(new string('-', level));
            Console.Write(new string('-', level));
            Console.WriteLine(node.Value.ErasingMessage());
            
            if (node.Nodes != null && !node.Nodes.Any()) 
                return;
            
            if (node.Nodes != null)
            {
                foreach (var ciNode in node.Nodes)
                {
                    PrintNodeToEraseForCi(ciNode, level + 1);
                }
            }
        }
        
        public void PrintNodeToDeprecate(CINode node, string original, int level = 0)
        {
            if (node == null)
                return;
            
            Console.Write('|');
            Console.Write(new string('-', level));
            Console.Write(new string('-', level));
            Console.Write(new string('-', level));
            Console.WriteLine(node.Value.DeprecateMessage(original));
            
            if (node.Nodes != null && !node.Nodes.Any()) 
                return;
            
            if (node.Nodes != null)
            {
                foreach (var ciNode in node.Nodes)
                {
                    PrintNodeToDeprecate(ciNode, original, level + 1);
                }
            }
        }
        
    }
}