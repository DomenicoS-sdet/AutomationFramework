using System;
using System.Collections.Generic;
using System.Text;
using Coypu;
using Utility.Setup;
using Coypu.Drivers;

namespace Drivers
{
    public static class Browser
    {
        public static BrowserSession browserSession { get; set; }

        public static void Open()
        {
            string browserName = Settings.Browser;

            switch(browserName)
            {
                case "Chrome":
                    var sessionConfiguration = new SessionConfiguration
                    {
                        Driver = typeof(ChromeWebDriver),
                        Timeout = new TimeSpan(0, 1, 0)
                    };
                    browserSession = new BrowserSession(sessionConfiguration);
                    browserSession.MaximiseWindow();
                    break;
            }
        }

        public static void Close()
        {
            browserSession.Dispose();
        }
    }
}
