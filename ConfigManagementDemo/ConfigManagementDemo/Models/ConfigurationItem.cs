using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigManagementDemo.Models
{
    /// <summary>
    /// Represents a configuration item
    /// </summary>
    public class ConfigurationItem
    {
        /// <summary>
        /// Represents the name of the CI
        /// </summary>
        [Key]
        public string Name { get; set; }
        
        /// <summary>
        /// Describes de CI
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The person who is responsible
        /// </summary>
        public string Responsible { get; set; }
        
        /// <summary>
        /// Version of the CI using SEUER
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// Represents the dependency items of this file
        /// </summary>
        public IEnumerable<DependencyItem> DependencyItems { get; set; }
        
        /// <summary>
        /// Represents the items that depend on this CI
        /// </summary>
        public IEnumerable<DependencyItem> ItemsThatDepend { get; set; }


        public override string ToString()
        {
            return $"{Name} in charge of -> {Responsible}";
        }

        public string ErasingMessage() => $"You must speak to {Responsible} to delete ({Name})";


        public string DeprecateMessage(string deprecating) =>
            $"You should tell {Responsible} about {Name} to deprecate {deprecating}";
    }
}