using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_automation.models
{
    public class Nurse
    {
       
        private string _name;
        

        public Nurse(string name) { 
            _name = name;
            
        }

        public string getName()
        {
            return _name;
        }

        

    }
}
