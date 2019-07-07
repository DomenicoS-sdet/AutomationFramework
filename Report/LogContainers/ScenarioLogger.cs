using System;
using System.Collections.Generic;
using System.Text;

namespace Report.LogContainers
{
    public class ScenarioLogger
    {
        public List<StepLogger> _steps = new List<StepLogger>();
        public string ScenarioTitle { get; set; }
        public string ScenarioResult { get; set; }
        public string ScenarioDuration { get; set; }

        /// <summary>
        /// Add a new Step inside the steps list in the Scenario Logger
        /// </summary>
        /// <param name="step"></param>
        public void AddStep(StepLogger step) => _steps.Add(step);
        public List<StepLogger> GetStepsList() => _steps; 
        

    }
}
