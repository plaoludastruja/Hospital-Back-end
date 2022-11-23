﻿using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Vacations.Model;
using HospitalLibrary.Vacations.Repository;
using HospitalLibrary.Vacations.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.DoctorTest
{
    public class VacationTest
    {
        [Fact]
        public void Check_if_doctor_has_appointments_during_vacation()
        {
            Guid DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e");
            
            var doctorAppointmentService = new Mock<IDoctorAppointmentService>();
            var vacationRepo = new Mock<IVacationRepository>();
            var doctorService = new Mock<IDoctorService>();
            VacationService vc = new VacationService(vacationRepo.Object, doctorAppointmentService.Object, doctorService.Object);
            List<Appointment> doctorAppointments = new List<Appointment>();

            doctorAppointments.Add(new Appointment
            {
                DoctorId = DoctorId,
                Schedule = new RoomSchedule{
                    DateTime = new DateTime(2022, 12, 25, 0, 0, 0)
                }
                
            });
            doctorAppointments.Add(new Appointment
            {
                DoctorId = DoctorId,
                Schedule = new RoomSchedule{
                    DateTime = new DateTime(2022, 11, 25, 0, 0, 0)
                }
               
            });
            Vacation vacationTrue = new Vacation()
            {
                DoctorId = DoctorId,
                DateStart = new DateTime(2022, 12, 5, 0, 0, 0),
                DateEnd = new DateTime(2022, 12, 15, 0, 0, 0)
            };
            Vacation vacationFalse = new Vacation()
            {
                DoctorId = DoctorId,
                DateStart = new DateTime(2022, 12, 5, 0, 0, 0),
                DateEnd = new DateTime(2022, 12, 30, 0, 0, 0)
            };




            doctorAppointmentService.Setup(x => x.GetDoctorAppointments(DoctorId)).Returns(doctorAppointments);


            var result = vc.CheckDoctorAvailability(vacationTrue);
            result.ShouldBeTrue();

            var result1 = vc.CheckDoctorAvailability(vacationFalse);
            result1.ShouldBeFalse();

        }

        [Fact]
        public void Check_if_date_is_valid()
        {
            var doctorAppointmentService = new Mock<IDoctorAppointmentService>();
            var vacationRepo = new Mock<IVacationRepository>();
            var doctorService = new Mock<IDoctorService>();
            VacationService vc = new VacationService(vacationRepo.Object, doctorAppointmentService.Object, doctorService.Object);

            var resultTrue = vc.isDateValid(DateTime.Now.AddDays(6));
            resultTrue.ShouldBeTrue();

            var resultFalse = vc.isDateValid(DateTime.Now.AddDays(5));
            resultFalse.ShouldBeFalse();
        }

    }
}