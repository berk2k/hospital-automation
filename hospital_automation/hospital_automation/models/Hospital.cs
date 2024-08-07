using System;
using System.Collections.Generic;
using System.Linq;

namespace hospital_automation.models
{
    public class Hospital
    {
        private const int MaxDoctorCount = 20;
        private const int MaxNurseCount = 50;

        private List<Doctor> _doctors;
        private List<Nurse> _nurses;

        public Hospital()
        {
            _doctors = new List<Doctor>();
            _nurses = new List<Nurse>();
        }

        public Hospital(List<Doctor> doctors, List<Nurse> nurses)
        {
            _doctors = doctors;
            _nurses = nurses;
        }

        public void AddDoctor(Doctor doctor)
        {
            if (_doctors.Count >= MaxDoctorCount)
            {
                throw new InvalidOperationException("Cannot add more doctors. Maximum count reached.");
            }
            _doctors.Add(doctor);
        }

        public void RemoveDoctor(Doctor doctor)
        {
            _doctors.Remove(doctor);
        }

        public void AddNurse(Nurse nurse)
        {
            if (_nurses.Count >= MaxNurseCount)
            {
                throw new InvalidOperationException("Cannot add more nurses. Maximum count reached.");
            }
            _nurses.Add(nurse);
        }

        public void RemoveNurse(Nurse nurse)
        {
            _nurses.Remove(nurse);
        }

        public List<Doctor> GetDoctors()
        {
            return _doctors;
        }

        public List<Nurse> GetNurses()
        {
            return _nurses;
        }

        public bool IsDoctorCountValid()
        {
            return _doctors.Count <= MaxDoctorCount;
        }

        public bool IsNurseCountValid()
        {
            return _nurses.Count <= MaxNurseCount;
        }

        public int GetDoctorCount()
        {
            return _doctors.Count;
        }

        public int GetNurseCount()
        {
            return _nurses.Count;
        }
    }
}
