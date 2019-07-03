using System;
using System.Collections.Generic;
using System.Text;
using Coypu;

namespace PageObjects.Common
{
    /// <summary>
    /// This class implement all the methods used to operate on the page object
    /// The method of this class are inherited by all the page object
    /// </summary>
    public abstract class PageObject
    {
        internal static string PageTitle { get; set; }
        internal static BrowserSession _browserSession;

        /// <summary>
        /// Checks if the browser is on the calling page.
        /// </summary>
        /// <returns>Returs true if the browser is on the page and false if it isnt.</returns>
        public bool IsAt()
        {
            return _browserSession.Title.Contains(PageTitle);
        }

        /// <summary>
        /// Check if the browser is on the calling page or
        /// if it is on a specific called page
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool IsAt(string title)
        {
            string callingPageTitle = _browserSession.Title.ToLower();
            string calledPageTitle = title.ToLower();
            return callingPageTitle.Contains(calledPageTitle);
        }

        

    }
}
