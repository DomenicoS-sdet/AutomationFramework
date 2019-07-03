using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Utility.Setup.Environment
{
    public class EnvironmentCollection : ConfigurationElementCollection
    {
        //Create a new EnvironmentElement from the App.config file
        protected override ConfigurationElement CreateNewElement()
        {
            return new EnvironmentElement();
        }

        //Get the element key from the Configuration element. In this case the key
        //is represented by the "name" e.g. name="SearchPage"
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EnvironmentElement)element).Name;
        }
    }
}
