using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using HospitalLibrary.Patients.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.Settings.Configurations
{
    public class StartedSchedulingConfiguration : IEntityTypeConfiguration<StartedScheduling>
    {
        public void Configure(EntityTypeBuilder<StartedScheduling> builder)
        {
            builder
                .HasOne(ss => ss.Patient)
                .WithMany()
                .HasForeignKey(ss => ss.PatientId);
        }
    }
}