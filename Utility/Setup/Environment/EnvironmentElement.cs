using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Utility.Setup.Environment
{
    /// <summary>
    /// This EnvironmentElement allows to read the Web Pages attributes specified on the App.config file
    /// If new attributes are necessary in the future, they need to be specified here
    /// </summary>
    public class EnvironmentElement : ConfigurationElement
    {
        //Name of the web page
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
        //URL of the web page
        [ConfigurationProperty("url", IsRequired = false)]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }
        //Page title of the web page e.g. the tab name on the browser
        [ConfigurationProperty("pageTitle", IsRequired = true)]
        public string PageTitle
        {
            get { return (string)this["pageTitle"]; }
            set { this["pageTitle"] = value; }
        }

    }
}
