using Drivers;
using PageObjects.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects.Common
{
    public static class Pages
    {
        public static HomePage HomePage => new HomePage(Browser.browserSession);
    }
}
