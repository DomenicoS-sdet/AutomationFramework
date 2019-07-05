using System;
using System.Collections.Generic;
using System.Text;
using Coypu;
using Utility.Setup;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using Drivers.WebBrowserInit;
using System.Linq;

namespace Drivers
{
    public static class Browser
    {
        public static BrowserSession browserSession { get; set; }

        private static List<IWebBrowser> _browsers = new List<IWebBrowser>
        {
            {new ChromeWebBrowser() }
        };

        public static void Open()
        {
            browserSession = new BrowserSession(_browsers.SingleOrDefault(w => w.CanInit(Settings.Browser)).InitWebBrowser());
            browserSession.MaximiseWindow();          
        }

        public static void Close()
        {
            browserSession.Dispose();
        }
    }
}
