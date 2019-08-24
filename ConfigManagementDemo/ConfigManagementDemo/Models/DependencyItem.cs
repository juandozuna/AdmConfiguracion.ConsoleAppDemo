using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigManagementDemo.Models
{
    /// <summary>
    /// Represents a dependency with configuration ITEMS
    /// </summary>
    public class DependencyItem
    {
        /// <summary>
        /// Requiered primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        /// <summary>
        /// Represents the ID of the base CI
        /// </summary>
        public string BaseCiName { get; set; }
        
        /// <summary>
        /// The instance of <see cref="ConfigurationItem"/>
        /// </summary>
        public ConfigurationItem BaseCi { get; set; }
        
        /// <summary>
        /// Represents the name of the dependency
        /// </summary>
        public string DependencyCiName { get; set; }
        
        /// <summary>
        /// Represents an dependency instance of <see cref="ConfigurationItem"/>
        /// </summary>
        public ConfigurationItem DependencyCi { get; set; }
    }
}