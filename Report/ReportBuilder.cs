using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;
using Report.LogContainers;
using Newtonsoft.Json;

namespace Report
{
    public static class ReportBuilder
    {
        

        public static void SerialiseToJson(string jsonPath, TestRunLogger testRunLogger)
        {

            string json = JsonConvert.SerializeObject(testRunLogger);

            File.WriteAllText(jsonPath, json);

        }

        /// <summary>
        /// Static class to build the HTML report at the end of the test execution
        /// </summary>
        public static void BuildHtmlReport(string reportPath, TestRunLogger testRunLogger)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(Html.header);
            stringBuilder.Append(Html.scripts);
            stringBuilder.Append(Html.CSS);

            stringBuilder.Append($@"<body> <div> <h1 style = ""text-align : center""> Automation Framework Results {testRunLogger.TestExecutionDate} </h1></div>");

            #region Execution Overview Table
            stringBuilder.Append(@"<table id=""overallExecution"">");
            stringBuilder.Append($@"<tr><td>Execution time: {testRunLogger.TestRunExecutionTime}</td></tr>");
            stringBuilder.Append($@"<tr><td>Test Executed total: {testRunLogger.TestRunTotal}</td></tr>");
            stringBuilder.Append($@"<tr><td style = ""color: red"">Test Failed: {testRunLogger.TestRunFailed}</td></tr>");
            stringBuilder.Append($@"<tr><td style = ""color: green"">Test Passed: {testRunLogger.TestRunPassed}</td></tr>");
            stringBuilder.Append($@"<tr><td style = ""color: orange"">Test Inconclusive: {testRunLogger.TestRunInconclusive}</td></tr>");
            stringBuilder.Append("</table>");
            #endregion

            #region Search input fields
            stringBuilder.Append(Html.SearchInput);
            #endregion

            #region Test Results table
            stringBuilder.Append(Html.TestTableHeader);

            foreach(var feature in testRunLogger.GetFeatures())
            {
                
                foreach(var scenario in feature.ReturnScenarios())
                {
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append($@"<td class=""feature"">{feature.FeatureTitle}</td>");

                    stringBuilder.Append($@"<td class=""scenario"">{scenario.ScenarioTitle}</td>");
                    stringBuilder.Append("<td> <table> <tbody>");

                    foreach(var step in scenario.GetStepsList())
                    {
                        stringBuilder.Append("<tr>");
                        stringBuilder.Append($@"<td>{step.StepTitle}</td>");
                        stringBuilder.Append($@"<td><a href=""{step.GetScreenshotAbsolutePath()}"" target=""_blank""><img src=""{step.GetScreenshotAbsolutePath()}"" style=""width: 42px; height: 42px; border: 0;""></a></td>");

                        if (step.StepResult.Equals("Passed"))
                            stringBuilder.Append(@"<td style=""color: green"">Passed</td>");
                        else
                            stringBuilder.Append(@"<td style=""color: red"">Failed</td>");
                        stringBuilder.Append("</tr>");
                    }
                    stringBuilder.Append("</tbody> </table> </td>");

                    if (string.IsNullOrEmpty(scenario.ErrorMessage))
                        stringBuilder.Append("<td></td>");
                    else
                        stringBuilder.Append($"<td>{scenario.ErrorMessage}</td>");

                    if (scenario.ScenarioResult.Equals("Passed"))
                        stringBuilder.Append(@"<td class=""result"" style=""color: green"">Passed</td>");
                    else
                        stringBuilder.Append(@"<td class=""result"" style=""color: red"">Failed</td>");

                    stringBuilder.Append($"<td>{scenario.ScenarioDuration}</td>");

                    stringBuilder.Append("</tr>");

                }
            }
            stringBuilder.Append("</table>");

            #endregion

            stringBuilder.Append("</body> </html>");

            File.WriteAllText(reportPath, stringBuilder.ToString());
        }
    }
}
