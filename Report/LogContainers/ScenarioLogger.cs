using System;
using System.Collections.Generic;
using System.Text;

namespace Report.LogContainers
{
    public class ScenarioLogger
    {
        private List<StepLogger> _steps = new List<StepLogger>();
        public string ScenarioTitle { get; set; }
        public string ScenarioResult { get; set; }

        public void AddStep(StepLogger step) => _steps.Add(step);
        public List<StepLogger> GetStepsList() => _steps; 
        

    }
}
