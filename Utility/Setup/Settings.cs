using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Utility.Setup
{
    public static class Settings
    {
        public static readonly string Browser = ConfigurationManager.AppSettings["Browser"];
    }
}
