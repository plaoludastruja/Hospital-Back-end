﻿// <auto-generated />
using System;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20221121224604_PersonId_nullable")]
    partial class PersonId_nullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AllergiePatient", b =>
                {
                    b.Property<Guid>("AllergiesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientsId")
                        .HasColumnType("uuid");

                    b.HasKey("AllergiesId", "PatientsId");

                    b.HasIndex("PatientsId");

                    b.ToTable("PatientAllergies");
                });

            modelBuilder.Entity("HospitalLibrary.AcountActivation.Model.AcountActivationInfo", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActivationToken")
                        .HasColumnType("uuid");

                    b.HasKey("PersonId");

                    b.ToTable("AcountActivationInfos");
                });

            modelBuilder.Entity("HospitalLibrary.Admissions.Model.Admission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("arrivalDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("Admissions");
                });

            modelBuilder.Entity("HospitalLibrary.Allergies.Model.Allergie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("HospitalLibrary.Appointments.Model.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("SendOnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDone")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HospitalLibrary.BloodConsumptionRecords.Model.BloodConsumptionRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("BloodType")
                        .HasColumnType("text");

                    b.Property<DateTime>("SendOnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("BloodConsumptionRecords");
                });

            modelBuilder.Entity("HospitalLibrary.BloodSupplies.Model.BloodSupply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BloodSupply");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Floor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.BuildingMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<int>("CoordinateX")
                        .HasColumnType("integer");

                    b.Property<int>("CoordinateY")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("BuildingMaps");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.FloorMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CoordinateX")
                        .HasColumnType("integer");

                    b.Property<int>("CoordinateY")
                        .HasColumnType("integer");

                    b.Property<Guid?>("FloorId")
                        .HasColumnType("uuid");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.ToTable("FloorMaps");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.RoomMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CoordinateX")
                        .HasColumnType("integer");

                    b.Property<int>("CoordinateY")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomMaps");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Model.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HospitalLibrary.Doctors.Model.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<string>("LicenceNum")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<string>("Speciality")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("WorkingTimeEnd")
                        .HasColumnType("text");

                    b.Property<string>("WorkingTimeStart")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("RoomId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalLibrary.Feedbacks.Model.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsAnonimous")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDesiredPublic")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("HospitalLibrary.Patients.Model.AgeGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("GropuName")
                        .HasColumnType("text");

                    b.Property<int>("MaxAge")
                        .HasColumnType("integer");

                    b.Property<int>("MinAge")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AgeGroups");
                });

            modelBuilder.Entity("HospitalLibrary.Patients.Model.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("BloodType")
                        .HasColumnType("integer");

                    b.Property<Guid>("ChoosenDoctorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ChoosenDoctorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("FloorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.ToTable("Rooms");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Room");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.RoomsEquipment", b =>
                {
                    b.Property<Guid>("DoctorRoomId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("DoctorRoomId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("RoomsEquipment");
                });

            modelBuilder.Entity("HospitalLibrary.Users.Model.User", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<bool>("IsAccountActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HospitalLibrary.Vacations.Model.Vacation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DeniedRequestReason")
                        .HasColumnType("text");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<bool>("Urgent")
                        .HasColumnType("boolean");

                    b.Property<int>("VacationStatus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.CafeteriaRoom", b =>
                {
                    b.HasBaseType("HospitalLibrary.RoomsAndEqipment.Model.Room");

                    b.Property<string>("Workhours")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("CafeteriaRoom");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.DoctorRoom", b =>
                {
                    b.HasBaseType("HospitalLibrary.RoomsAndEqipment.Model.Room");

                    b.HasDiscriminator().HasValue("DoctorRoom");
                });

            modelBuilder.Entity("AllergiePatient", b =>
                {
                    b.HasOne("HospitalLibrary.Allergies.Model.Allergie", null)
                        .WithMany()
                        .HasForeignKey("AllergiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.Patients.Model.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalLibrary.Admissions.Model.Admission", b =>
                {
                    b.HasOne("HospitalLibrary.Patients.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.RoomsAndEqipment.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.Appointments.Model.Appointment", b =>
                {
                    b.HasOne("HospitalLibrary.Doctors.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.Patients.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.RoomsAndEqipment.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.BloodConsumptionRecords.Model.BloodConsumptionRecord", b =>
                {
                    b.HasOne("HospitalLibrary.Doctors.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Floor", b =>
                {
                    b.HasOne("HospitalLibrary.BuildingManagment.Model.Building", null)
                        .WithMany("FloorList")
                        .HasForeignKey("BuildingId");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.BuildingMap", b =>
                {
                    b.HasOne("HospitalLibrary.BuildingManagment.Model.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.FloorMap", b =>
                {
                    b.HasOne("HospitalLibrary.BuildingManagment.Model.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorId");

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagmentMap.Model.RoomMap", b =>
                {
                    b.HasOne("HospitalLibrary.RoomsAndEqipment.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.Doctors.Model.Doctor", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.RoomsAndEqipment.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.Feedbacks.Model.Feedback", b =>
                {
                    b.HasOne("HospitalLibrary.Patients.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalLibrary.Patients.Model.Patient", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.Doctors.Model.Doctor", "ChoosenDoctor")
                        .WithMany()
                        .HasForeignKey("ChoosenDoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("ChoosenDoctor");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.Room", b =>
                {
                    b.HasOne("HospitalLibrary.BuildingManagment.Model.Floor", null)
                        .WithMany("RoomList")
                        .HasForeignKey("FloorId");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.RoomsEquipment", b =>
                {
                    b.HasOne("HospitalLibrary.RoomsAndEqipment.Model.DoctorRoom", "DoctorRoom")
                        .WithMany("RoomsEquipment")
                        .HasForeignKey("DoctorRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.RoomsAndEqipment.Model.Equipment", "Equipment")
                        .WithMany("RoomsEquipment")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorRoom");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("HospitalLibrary.Vacations.Model.Vacation", b =>
                {
                    b.HasOne("HospitalLibrary.Doctors.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Building", b =>
                {
                    b.Navigation("FloorList");
                });

            modelBuilder.Entity("HospitalLibrary.BuildingManagment.Model.Floor", b =>
                {
                    b.Navigation("RoomList");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.Equipment", b =>
                {
                    b.Navigation("RoomsEquipment");
                });

            modelBuilder.Entity("HospitalLibrary.RoomsAndEqipment.Model.DoctorRoom", b =>
                {
                    b.Navigation("RoomsEquipment");
                });
#pragma warning restore 612, 618
        }
    }
}
