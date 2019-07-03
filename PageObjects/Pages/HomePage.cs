using System;
using System.Collections.Generic;
using System.Text;
using PageObjects.Common;
using Coypu;

namespace PageObjects.Pages
{
    public class HomePage : Page
    {

        public HomePage(BrowserSession browserSession) : base(browserSession)
        {
            _browserSession = browserSession;
        }

        private ElementScope SearchBtn => _browserSession.FindXPath("//button[text() = ' Search']");

        public bool IsHomePageReady()
        {
            return SearchBtn.Exists();
        }
    }
}
