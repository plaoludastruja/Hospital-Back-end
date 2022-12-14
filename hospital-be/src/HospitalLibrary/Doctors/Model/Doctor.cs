﻿using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Doctors.Model
{
    public class Doctor : Person
    {
        public string LicenceNum { get; set; }
        public string Speciality { get; set; }
        public string WorkingTimeStart { get; set; }
        public string WorkingTimeEnd { get; set; }
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual List<Consilium> Consiliums { get; set; }

        public void Update(Doctor doctor)
        {
            base.Update(doctor);
            LicenceNum = doctor.LicenceNum;
            Speciality = doctor.Speciality;
            WorkingTimeStart = doctor.WorkingTimeStart;
            WorkingTimeEnd = doctor.WorkingTimeEnd; 
        }

        public bool IsInWorkHours(DateTime date)
        {
            DateTime WorkTimeStart = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(this.WorkingTimeStart).Hour, DateTime.Parse(this.WorkingTimeStart).Minute, 0);
            DateTime WorkTimeEnd = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(this.WorkingTimeEnd).Hour, DateTime.Parse(this.WorkingTimeEnd).Minute, 0);

            if (DateTime.Compare(date, WorkTimeStart) >= 0
                && DateTime.Compare(date, WorkTimeEnd) < 0)
            {
                return true;
            }
            return false;
        }

        public bool IsSpeciality(String speciality)
        {
            if (speciality.Equals(this.Speciality))
                return true;
            return false;
        }
    }
}
