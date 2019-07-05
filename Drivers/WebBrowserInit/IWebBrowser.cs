using Coypu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drivers.WebBrowserInit
{
    public interface IWebBrowser
    {
        bool CanInit(string webbrowser);

        SessionConfiguration InitWebBrowser();
    }
}
