using System;
using System.Collections.Generic;
using System.Text;
using Coypu;
using Utility.Setup;
using Coypu.Drivers;

namespace Drivers
{
    public class Browser
    {
        private BrowserSession browser;

        public void Open()
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
                    break;
            }
        }
    }
}
