using LabCMS.Seedwork.EquipmentDomain;
using LabCMS.Seedwork.PersonnelDomain;
using LabCMS.Seedwork.ProjectDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using LabCMS.Seedwork.Converters;
using LabCMS.Seedwork.TestFieldDomain;
using LabCMS.Seedwork.FixtureDomain;

namespace LabCMS.Seedwork
{
    public class Repository:DbContext
    {
        public Repository(DbContextOptions<Repository> options):base(options){}
        public DbSet<Version> Versions => Set<Version>();
        public DbSet<Project> Projects => Set<Project>();

        public DbSet<EquipmentHourlyRate> EquipmentHourlyRates => Set<EquipmentHourlyRate>();
        public DbSet<UsageRecord> EquipmentUsageRecords => Set<UsageRecord>();
        public DbSet<MachineDownRecord> MachineDownRecords => Set<MachineDownRecord>();

        public DbSet<Person> People => Set<Person>();

        public DbSet<TestField> TestFields => Set<TestField>();

        public DbSet<Fixture> Fixtures => Set<Fixture>();
        public DbSet<FixtureDomain.Role> FixtureDomainRoles => Set<FixtureDomain.Role>();
        public DbSet<CheckoutRecord> FixtureCheckoutRecords => Set<CheckoutRecord>();
        public DbSet<CheckinRecord> FixtureCheckinRecords => Set<CheckinRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Version>()
                .HasData(new()
                {
                    No = "1.0.0",
                    Comment = "Initial Version"
                },
                SeedworkVersion.Version);

            ConfigureProjectDomain(modelBuilder);
            ConfigureEquipmentDomain(modelBuilder);
        }

        private void ConfigureProjectDomain(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasIndex(item => item.Name)
                .IsUnique();
        }
        private void ConfigureEquipmentDomain(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsageRecord>()
                .HasIndex(item => item.ProjectNo);
            // modelBuilder.Entity<UsageRecord>()
            //     .HasIndex(item => item.EquipmentNo)
            //     .IncludeProperties(item=>item.TestType);
            modelBuilder.Entity<UsageRecord>()
                .HasIndex(item => item.StartTime);
            modelBuilder.Entity<UsageRecord>()
                .Property(item => item.StartTime)
                .HasConversion(EFCoreValueConverters.DataTimeOffsetUtcSecondsConverter);
            modelBuilder.Entity<UsageRecord>()
                .Property(item => item.EndTime)
                .HasConversion(EFCoreValueConverters.DataTimeOffsetUtcSecondsConverter);
            
            modelBuilder.Entity<CheckoutRecord>()
                .Property(item=>item.CheckoutDate)
                .HasConversion(EFCoreValueConverters.DataTimeOffsetUtcSecondsConverter);
            modelBuilder.Entity<CheckoutRecord>()
                .Property(item=>item.PlanndReturnDate)
                .HasConversion(EFCoreValueConverters.DataTimeOffsetUtcSecondsConverter);
            modelBuilder.Entity<CheckoutRecord>()
                .Property(item=>item.TimeStamp)
                .HasConversion(EFCoreValueConverters.DataTimeOffsetUtcSecondsConverter);

            modelBuilder.Entity<CheckinRecord>()
                .Property(item=>item.CheckinDate)
                .HasConversion(EFCoreValueConverters.DataTimeOffsetUtcSecondsConverter);
            modelBuilder.Entity<CheckinRecord>()
                .Property(item=>item.TimeStamp)
                .HasConversion(EFCoreValueConverters.DataTimeOffsetUtcSecondsConverter);
        }
    
    }
}