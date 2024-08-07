using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_automation.models
{
    public class Surgery
    {
        private int _surgery_item_count;
        private double _item_fee;
        private int _surgery_doctor_count;
        private int _surgery_nurse_count;
        public Surgery(int item_count,double fee,int doctor,int nurse) {
            _surgery_item_count = item_count;
            _item_fee = fee;
            _surgery_doctor_count = doctor;
            _surgery_nurse_count = nurse;
        }

        public int GetSurgeryItemCount() {   return _surgery_item_count; } 
        public double GetItemFee() {   return _item_fee; } 

        public int GetDoctorCount() {  return _surgery_doctor_count; } 

        public int GetNurseCount() {  return _surgery_nurse_count; } 
    }
}
