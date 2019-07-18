using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Report.LogContainers
{
    public class StepLogger
    {
        public string StepTitle { get; set; }
        public string ScreenshotPath { get; set; }
        public string StepResult { get; set; }
        public Table Table { get; set; }

        public string GetScreenshotAbsolutePath()
        {
            var fileName = System.IO.Path.GetFileName(ScreenshotPath);

            return $".\\{fileName}";
        }

    }
}
