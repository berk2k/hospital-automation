using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_automation.models
{
    public class Doctor
    {
        
        private string _doctor_name;
        private Role _doctor_role;
        private double _doctor_fee;

        public Doctor(string doctor_name, Role role, double doctor_fee)
        {
            _doctor_name = doctor_name;
            _doctor_role = role;
            _doctor_fee = doctor_fee;   
        }

        public string getDoctorName()
        {
            return _doctor_name;
        }

        public Role getRole()
        {
            return _doctor_role;
        }

        public double getDoctorFee()
        {
            return _doctor_fee;
        }

        public enum Role
        {
            OPERATOR,NORMAL
        }

        


    }
}
