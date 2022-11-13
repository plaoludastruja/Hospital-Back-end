﻿// <auto-generated />
using System;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    partial class IntegrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("IntegrationLibrary.BloodBankNews.Model.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BloodBankId")
                        .HasColumnType("uuid");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BloodBankId");

                    b.ToTable("blood_bank_news");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBanks.Model.BloodBank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ApiKey")
                        .HasColumnType("text");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("ServerAddress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("blood_banks");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBanks.Model.BloodUsage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BloodUsageReportId")
                        .HasColumnType("uuid");

                    b.Property<double>("milliliters")
                        .HasColumnType("double precision");

                    b.Property<int>("rHFactor")
                        .HasColumnType("integer");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BloodUsageReportId");

                    b.ToTable("blood_usage");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBanks.Model.BloodUsageReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BloodBankId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ReportConfigurationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("timeOfCreation")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BloodBankId");

                    b.HasIndex("ReportConfigurationId");

                    b.ToTable("blood_usage_report");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBanks.Model.ReportConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("BloodBankId")
                        .HasColumnType("uuid");

                    b.Property<int>("RequestFrequency")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BloodBankId");

                    b.ToTable("blood_banks_config");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodRequests.Model.BloodRequest", b =>
                {
                    b.Property<Guid>("requestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("bloodAmountInMilliliters")
                        .HasColumnType("double precision");

                    b.Property<int>("bloodType")
                        .HasColumnType("integer");

                    b.Property<string>("doctorId")
                        .HasColumnType("text");

                    b.Property<bool>("isApproved")
                        .HasColumnType("boolean");

                    b.Property<string>("managerId")
                        .HasColumnType("text");

                    b.Property<string>("reasonsWhyBloodIsNeeded")
                        .HasColumnType("text");

                    b.Property<string>("rejectionComment")
                        .HasColumnType("text");

                    b.HasKey("requestId");

                    b.ToTable("blood_requests");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBankNews.Model.News", b =>
                {
                    b.HasOne("IntegrationLibrary.BloodBanks.Model.BloodBank", "BloodBank")
                        .WithMany()
                        .HasForeignKey("BloodBankId");

                    b.Navigation("BloodBank");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBanks.Model.BloodUsage", b =>
                {
                    b.HasOne("IntegrationLibrary.BloodBanks.Model.BloodUsageReport", null)
                        .WithMany("BloodUsage")
                        .HasForeignKey("BloodUsageReportId");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBanks.Model.BloodUsageReport", b =>
                {
                    b.HasOne("IntegrationLibrary.BloodBanks.Model.BloodBank", "BloodBank")
                        .WithMany()
                        .HasForeignKey("BloodBankId");

                    b.HasOne("IntegrationLibrary.BloodBanks.Model.ReportConfiguration", "ReportConfiguration")
                        .WithMany()
                        .HasForeignKey("ReportConfigurationId");

                    b.Navigation("BloodBank");

                    b.Navigation("ReportConfiguration");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBanks.Model.ReportConfiguration", b =>
                {
                    b.HasOne("IntegrationLibrary.BloodBanks.Model.BloodBank", "BloodBank")
                        .WithMany()
                        .HasForeignKey("BloodBankId");

                    b.Navigation("BloodBank");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBanks.Model.BloodUsageReport", b =>
                {
                    b.Navigation("BloodUsage");
                });
#pragma warning restore 612, 618
        }
    }
}
