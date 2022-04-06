using DentalApps.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DentalApps.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<TreatmentCategory> TreatmentCategories => Set<TreatmentCategory>();
        public DbSet<SubTreatmentCategory> SubTreatmentCategories => Set<SubTreatmentCategory>();
        public DbSet<Treatment> Treatments => Set<Treatment>();
        public DbSet<SubTreatment> SubTreatments => Set<SubTreatment>();
        public DbSet<DoctorSchedule> DoctorSchedules => Set<DoctorSchedule>();
        public DbSet<RegisterSchedule> RegisterSchedules => Set<RegisterSchedule>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Treatment>().HasOne<Patient>(t => t.Patient)
                .WithMany(p => p.Treatments).HasForeignKey(t => t.PatientID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RegisterSchedule>().HasOne<Patient>(r=>r.Patient)
            .WithMany(p=>p.RegisterSchedules).HasForeignKey(r=>r.PatientID)
            .OnDelete(DeleteBehavior.Restrict);

            //menambahkan unique index untuk MedicalRecordNumber
            builder.Entity<Patient>().HasIndex(p=>p.MedicalRecordNumber).IsUnique();

            //menambahkan unique index untuk PrefixMR
            builder.Entity<Tenant>().HasIndex(p=>p.PrefixMR).IsUnique();
        }
    }
}