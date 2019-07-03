using System.Configuration;

namespace Utility.Setup.Environment
{
    /// <summary>
    /// This class specify the section Environments and the sub section Environment
    /// where are specified the different Web Pages.
    /// The keywork "add" is used to specified when a new Page is added to the Environment
    /// </summary>
    public class EnvironmentsDataSection : ConfigurationSection
    {
        public const string SectionName = "Environments";
        public const string EnvironmentsCollectionName = "Environment";

        [ConfigurationProperty(EnvironmentsCollectionName)]
        [ConfigurationCollection(typeof(EnvironmentCollection), AddItemName = "add")]
        public EnvironmentCollection Environment
        {
            get { return (EnvironmentCollection)base[EnvironmentsCollectionName]; }
        }
    }
}
