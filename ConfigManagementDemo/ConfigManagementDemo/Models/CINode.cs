using System;
using System.Collections.Generic;

namespace ConfigManagementDemo.Models
{
    public class CINode
    {
        public ConfigurationItem Value;
        public IEnumerable<CINode> Nodes;
    }
    
    
   
}