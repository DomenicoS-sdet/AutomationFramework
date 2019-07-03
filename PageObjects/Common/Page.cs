using System;
using System.Collections.Generic;
using System.Text;
using Utility.Setup.Environment;
using Coypu;

namespace PageObjects.Common
{
    public abstract class Page : PageObject
    {
        public static string Url { get; set; }

        public Page(BrowserSession browserSession)
        {
            Url = EnvironmentReader.get(GetType().Name).Url;
            PageTitle = EnvironmentReader.get(GetType().Name).PageTitle;
            _browserSession = browserSession;
        }

        /// <summary>
        /// Navigates to the page URL.
        /// </summary>
        public void Goto()
        {
            try
            {
                _browserSession.Visit(Url);
            }
            catch (Exception e)
            {
                throw new Exception(GetType().Name + " could not be loaded. Check page url is correct in app.config." +
                                    " " + e.Message);
            }
        }
    }
}
