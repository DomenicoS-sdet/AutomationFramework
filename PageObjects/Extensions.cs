using Coypu;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public static class Extensions
    {
        /// <summary>
        /// Gets the value of the attribute for this element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static string GetAttribute(this ElementScope element, string attribute)
        {
            return ((IWebElement)element.Native).GetAttribute(attribute);
        }
    }
}
