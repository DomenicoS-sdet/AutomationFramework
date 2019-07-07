using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;

namespace Report
{
    public static class ReportBuilder
    {
        /// <summary>
        /// Static class to build the HTML report at the end of the test execution
        /// </summary>
        /// <param name="reportPath"></param>
        public static void BuildReport(string reportPath)
        {
            StringWriter stringWriter = new StringWriter();

            //Write HTML report
            using(HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {

            }
        }
    }
}
