using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_automation.models
{
    public class Patient
    {
        public string Name { get; set; }
        public int AnnualSurgeries { get; set; }
        public int MonthlyCheckups { get; set; }

        public int AnnualCheckups {  get; set; }

        public Patient(string name, int annualSurgeries, int monthlyCheckups, int annualCheckups)
        {
            Name = name;
            AnnualSurgeries = annualSurgeries;
            MonthlyCheckups = monthlyCheckups;
            AnnualCheckups = annualCheckups;
        }
    }
}
