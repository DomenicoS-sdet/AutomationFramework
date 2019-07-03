using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Utility.Setup.Environment
{
    /// <summary>
    /// Reads the Environment entry specified under the section Environments
    /// </summary>
    public static class EnvironmentReader
    {
        //this method return an EnvironmentElement (Web Page), depending on the pageName
        public static EnvironmentElement get(string pageName)
        {
            //collection of pages where we are going to store the information
            //read from the Environment section
            var PageConfig = new List<EnvironmentElement>();

            var EnvironmentInfo =
                ConfigurationManager.GetSection(EnvironmentsDataSection.SectionName) as EnvironmentsDataSection;
            //if a section environment exist
            if (EnvironmentInfo != null)
            {
                //read all the information relative to the pages entries and store them inside 
                //a collection of pages
                PageConfig.AddRange(from EnvironmentElement environmentElement in EnvironmentInfo.Environment
                                    select new EnvironmentElement()
                                    {
                                        Name = environmentElement.Name,
                                        Url = environmentElement.Url,
                                        PageTitle = environmentElement.PageTitle
                                    });
            }
            //return the page first occurence of the page, inside the PageConfig collection of pages
            //where the name of this page matchs the pageName specified
            return PageConfig.First(x => x.Name == pageName);
        }
    }
}
