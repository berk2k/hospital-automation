using hospital_automation.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_automation.service
{
    public class SurgeryService
    {
        
        //private Surgery _surgery;

        public SurgeryService(/*Surgery surgery*/)
        {
            
            //_surgery = surgery;
        }

        public bool IsDoctorCountValid(Surgery surgery)
        {
            return surgery.GetDoctorCount() >= 1;
        }

        public bool IsNurseCountValid(Surgery surgery)
        {
            return surgery.GetNurseCount() <= 5;
        }

        public bool CanPatientHaveASurgery(Patient patient)
        {
            if (patient == null) { Console.WriteLine("There is no such patient"); return false; }

            if (patient.AnnualSurgeries >= 1) { return false; }

            return true;
        }

        public bool CanPatientBookACheckUp(Patient patient)
        {
            if (patient == null) { Console.WriteLine("There is no such patient"); return false; }

            if (patient.MonthlyCheckups >= 3 || patient.AnnualCheckups >= 36) { return false; }

            return true;
        }

        public Patient MostCheckUpPatientName(List<Patient> patients)
        {
            var patient = patients.OrderByDescending(p => p.AnnualCheckups).FirstOrDefault();
            if (patient == null)
            {
                throw new InvalidOperationException("No patients available for checkup comparison.");
            }
            return patient;
        }

        public double MostSurgeryCost(List<Surgery> surgeries, Doctor doctor)
        {
            if (surgeries == null)
            {
                throw new InvalidOperationException("No surgeries available to calculate cost.");
            }

            return surgeries.Max(surgeries => CalculateSurgeryCost(surgeries, doctor));
        }

        public double CalculateSurgeryCost(Surgery surgery, Doctor doctor)
        {

            double itemCost = surgery.GetItemFee() * surgery.GetSurgeryItemCount();

            return itemCost + doctor.getDoctorFee();
        }




    }
}
