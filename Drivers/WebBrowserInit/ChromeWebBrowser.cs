using System;
using System.Collections.Generic;
using System.Text;
using Coypu;
using Coypu.Drivers.Selenium;

namespace Drivers.WebBrowserInit
{
    public class ChromeWebBrowser : IWebBrowser
    {
        public bool CanInit(string webbrowser)
        {
            return webbrowser.Equals("Chrome", StringComparison.OrdinalIgnoreCase);
        }

        public SessionConfiguration InitWebBrowser()
        {
            var sessionConfiguration = new SessionConfiguration
            {
                Driver = typeof(SeleniumWebDriver),
                Timeout = new TimeSpan(0, 1, 0),
                Browser = Coypu.Drivers.Browser.Chrome
            };

            return sessionConfiguration;
        }
    }
}
