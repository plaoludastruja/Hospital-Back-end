using AutoMapper;
using HospitalAPI.Dtos.Address;
using HospitalAPI.Dtos.Allergies;
using HospitalAPI.Dtos.Appointment;
using HospitalAPI.Dtos.BloodConsumptionRecord;
using HospitalAPI.Dtos.BloodSupply;
using HospitalAPI.Dtos.Doctor;
using HospitalAPI.Dtos.Feedback;
using HospitalAPI.Dtos.MapItem;
using HospitalAPI.Dtos.Patient;
using HospitalAPI.Dtos.Person;
using HospitalAPI.Dtos.Rooms;
using HospitalAPI.Dtos.User;
using HospitalAPI.Dtos.Vacation;
using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.BloodConsumptionRecords.Model;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Vacations.Model;

namespace HospitalAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressRequestDto, Address>();
            CreateMap<Address, AddressRequestDto>();

            CreateMap<PersonRequestDto, Person>();
            CreateMap<Person, PersonRequestDto>();

            CreateMap<PatientRequestDto, Patient>()
                .IncludeBase<PersonRequestDto, Person>();
            CreateMap<FeedbackRequestDto, Feedback>();
            CreateMap<Feedback, FeedbackPatientResponseDto>().ForMember(dest => dest.PatientFullname,
                opt => opt.MapFrom(src => ResolveFeedbackPatientFullName(src)));
            CreateMap<Feedback, FeedbackManagerResponseDto>().ForMember(dest => dest.PatientFullname,
                opt => opt.MapFrom(src => ResolveFeedbackPatientFullName(src)));


            CreateMap<MapItemRequestDto, MapItem>();

            CreateMap<PatientRequestDto, Patient>()
                .IncludeBase<PersonRequestDto, Person>();

            CreateMap<BuildingMapRequestDto, BuildingMap>()
                .IncludeBase<MapItemRequestDto, MapItem>();

            CreateMap<FloorMapRequestDto, FloorMap>()
                .IncludeBase<MapItemRequestDto, MapItem>();

            CreateMap<RoomMapRequestDto, RoomMap>()
                .IncludeBase<MapItemRequestDto, MapItem>();

            CreateMap<DoctorRequestDto, Doctor>()
                .IncludeBase<PersonRequestDto, Person>();

            CreateMap<Doctor, DoctorRequestDto>().IncludeBase<Person, PersonRequestDto>();

            CreateMap<RoomRequestDto, Room>();
            CreateMap<AppointmentRequestDto, Appointment>();
            CreateMap<VacationRequestDto, Vacation>();

            CreateMap<BloodConsumptionRecordRequestDto, BloodConsumptionRecord>();
            CreateMap<BloodSupplyDto, BloodSupply>();

            CreateMap<PatientRegistrationDto, Patient>();
            CreateMap<UserLoginDto, User>();

            CreateMap<Patient, PatientInfoDto>().IncludeBase<Person, PersonRequestDto>();
            CreateMap<PatientInfoDto, Patient>().IncludeBase<PersonRequestDto, Person>();

            CreateMap<AllergieInfoDto, Allergie>();
            CreateMap<Allergie, AllergieInfoDto>();


        }

        private static string ResolveFeedbackPatientFullName(Feedback src)
        {
            if (src.IsAnonimous)
            {
                return "Anonymous";
            }
            return src.Patient.Name + " " + src.Patient.Surname;
        }
    }
}
