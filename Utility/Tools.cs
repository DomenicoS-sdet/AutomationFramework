using System;
using System.Collections.Generic;
using System.Text;
using Coypu;

namespace Utility
{
    public static class Tools
    {
        public static string TakeScreenshot(string path, BrowserSession session)
        {
            session.SaveScreenshot(path);

            return path;
        }
    }
}
