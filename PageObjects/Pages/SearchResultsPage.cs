using Coypu;
using PageObjects.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects.Pages
{
    public class SearchResultsPage : Page
    {
        public SearchResultsPage(BrowserSession browserSession) : base(browserSession)
        {
            _browserSession = browserSession;
        }

        private ElementScope ResultTable => _browserSession.FindXPath("//table[@class=\"bgwhite table table-striped\"]");

        public bool IsListOfResultsReturned()
        {
            return ResultTable.Exists();
        }
    }
}
