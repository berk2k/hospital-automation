using System;
using System.Collections.Generic;
using hospital_automation.models;
using hospital_automation.service;

namespace hospital_automation
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Doctor doctor1 = new Doctor("Dr. Smith", Doctor.Role.OPERATOR, 500); 
            Doctor doctor2 = new Doctor("Dr. Johnson", Doctor.Role.NORMAL, 300); 

            Nurse nurse1 = new Nurse("Nurse Kelly");
            Nurse nurse2 = new Nurse("Nurse Taylor");
            Nurse nurse3 = new Nurse("Nurse Brown");
            Nurse nurse4 = new Nurse("Nurse Davis");
            Nurse nurse5 = new Nurse("Nurse Wilson");

            
            Hospital hospital = new Hospital();

            
            hospital.AddDoctor(doctor1);
            hospital.AddDoctor(doctor2);
            hospital.AddNurse(nurse1);
            hospital.AddNurse(nurse2);
            hospital.AddNurse(nurse3);
            hospital.AddNurse(nurse4);
            hospital.AddNurse(nurse5);

            
            Patient patient1 = new Patient("Alice", 0, 2, 10);
            Patient patient2 = new Patient("Bob", 1, 3, 15);
            Patient patient3 = new Patient("Charlie", 0, 1, 20);

            
            Surgery surgery1 = new Surgery(10, 50, 2, 3);
            Surgery surgery2 = new Surgery(5, 100, 1, 4);

           
            SurgeryService surgeryService = new SurgeryService();

            
            Console.WriteLine($"Doctor count: {hospital.GetDoctorCount()}");
            Console.WriteLine($"Nurse Count: {hospital.GetNurseCount()}");
            Console.WriteLine($"is Doctor count valid for hospital? {hospital.IsDoctorCountValid()}");
            Console.WriteLine($"is Nurse count valid for hospital? {hospital.IsNurseCountValid()}");

            

            
            Console.WriteLine("All Doctors:");
            foreach (var doc in hospital.GetDoctors())
            {
                Console.WriteLine($"Name: {doc.getDoctorName()}, Role: {doc.getRole()}, Fee: {doc.getDoctorFee()}");
            }

            Console.WriteLine("All Nurses:");
            foreach (var nurse in hospital.GetNurses())
            {
                Console.WriteLine($"Name: {nurse.getName()}");
            }

            
            List<Patient> patients = new List<Patient> { patient1, patient2, patient3 };
            Patient mostCheckupsPatient = surgeryService.MostCheckUpPatientName(patients);
            Console.WriteLine($"Patient with most checkup: {mostCheckupsPatient.Name}, total checkups: {mostCheckupsPatient.AnnualCheckups}");

            
            List<Surgery> surgeries = new List<Surgery> { surgery1, surgery2 };
            double maxSurgeryCost = surgeryService.MostSurgeryCost(surgeries, doctor1);
            Console.WriteLine($"Surgery with most cost: {maxSurgeryCost}");
        }
    }
}
