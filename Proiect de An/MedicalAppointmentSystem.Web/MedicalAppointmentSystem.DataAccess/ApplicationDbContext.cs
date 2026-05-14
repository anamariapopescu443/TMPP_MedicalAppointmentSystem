using MedicalAppointmentSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MedicalAppointmentSystem.Domain.Enums;

namespace MedicalAppointmentSystem.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<MedicalService> MedicalServices { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Decimal precision for service prices
        modelBuilder.Entity<MedicalService>()
            .Property(s => s.Price)
            .HasPrecision(18, 2);

        // Prevent SQL Server multiple cascade path errors

        modelBuilder.Entity<Doctor>()
            .HasOne(d => d.Hospital)
            .WithMany()
            .HasForeignKey(d => d.HospitalId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Doctor>()
            .HasOne(d => d.Department)
            .WithMany(dep => dep.Doctors)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MedicalService>()
            .HasOne(s => s.Department)
            .WithMany(dep => dep.MedicalServices)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.MedicalService)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.MedicalServiceId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Hospital)
            .WithMany()
            .HasForeignKey(a => a.HospitalId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Department)
            .WithMany()
            .HasForeignKey(a => a.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Notification>()
        .HasOne(n => n.Patient)
        .WithMany(p => p.Notifications)
        .HasForeignKey(n => n.PatientId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.Appointment)
            .WithMany()
            .HasForeignKey(n => n.AppointmentId)
            .OnDelete(DeleteBehavior.NoAction);

        // Seed Hospitals
        modelBuilder.Entity<Hospital>().HasData(
            new Hospital
            {
                Id = 1,
                Name = "Spitalul Clinic Republican",
                Address = "Str. Nicolae Testemitanu 29, Chisinau",
                PhoneNumber = "022000001",
                Description = "Spital public cu mai multe sectii medicale.",
                Type = HospitalType.PublicHospital
            },
            new Hospital
            {
                Id = 2,
                Name = "Medpark, Spital Internațional",
                Address = "Str. Andrei Doga 24, Chisinau",
                PhoneNumber = "022000002",
                Description = "Clinica privata cu servicii medicale moderne.",
                Type = HospitalType.PrivateClinic
            },
            new Hospital
            {
                Id = 3,
                Name = "Centru de Diagnostica Chisinau",
                Address = "Bd. Stefan cel Mare 100, Chisinau",
                PhoneNumber = "022000003",
                Description = "Centru medical specializat in investigatii si diagnostic.",
                Type = HospitalType.DiagnosticCenter
            }
        );

        // Seed Departments
        modelBuilder.Entity<Department>().HasData(
            new Department
            {
                Id = 1,
                Name = "Cardiology",
                HospitalId = 1
            },
            new Department
            {
                Id = 2,
                Name = "Dermatology",
                HospitalId = 1
            },
            new Department
            {
                Id = 3,
                Name = "Neurology",
                HospitalId = 2
            },
            new Department
            {
                Id = 4,
                Name = "Narcology",
                HospitalId = 2
            },
            new Department
            {
                Id = 5,
                Name = "Laboratory",
                HospitalId = 3
            },
            new Department
            {
                Id = 6,
                Name = "Radiology",
                HospitalId = 3
            }
        );

        // Seed Patients
        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Id = 1,
                FirstName = "Ana",
                LastName = "Popescu",
                PhoneNumber = "060000001",
                Email = "ana.popescu@example.com",
                IDNP = "2001000000001",
                Password = "1234",
                DateOfBirth = new DateTime(2001, 5, 12),
                MedicalCardFilePath = null
            },
            new Patient
            {
                Id = 2,
                FirstName = "Ion",
                LastName = "Rusu",
                PhoneNumber = "060000002",
                Email = "ion.rusu@example.com",
                IDNP = "1998000000002",
                Password = "1234",
                DateOfBirth = new DateTime(1998, 9, 20),
                MedicalCardFilePath = null
            }
        );

        // Seed Doctors
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                Id = 1,
                FirstName = "Elena",
                LastName = "Moraru",
                Specialization = "Cardiologist",
                Email = "elena.moraru@clinic.md",
                PhoneNumber = "069111111",
                IDNP = "1980000000001",
                Password = "1234",
                HospitalId = 1,
                DepartmentId = 1
            },
            new Doctor
            {
                Id = 2,
                FirstName = "Victor",
                LastName = "Ciobanu",
                Specialization = "Dermatologist",
                Email = "victor.ciobanu@clinic.md",
                PhoneNumber = "069222222",
                IDNP = "1985000000002",
                Password = "1234",
                HospitalId = 1,
                DepartmentId = 2
            },
            new Doctor
            {
                Id = 3,
                FirstName = "Maria",
                LastName = "Lungu",
                Specialization = "Neurologist",
                Email = "maria.lungu@clinic.md",
                PhoneNumber = "069333333",
                IDNP = "1990000000003",
                Password = "1234",
                HospitalId = 2,
                DepartmentId = 3
            },
            new Doctor
            {
                Id = 4,
                FirstName = "Andrei",
                LastName = "Munteanu",
                Specialization = "Narcologist",
                Email = "andrei.munteanu@clinic.md",
                PhoneNumber = "069444444",
                IDNP = "1988000000004",
                Password = "1234",
                HospitalId = 2,
                DepartmentId = 4
            }
        );

        // Seed Medical Services
        modelBuilder.Entity<MedicalService>().HasData(
            new MedicalService
            {
                Id = 1,
                Name = "Cardiology Consultation",
                Description = "Heart and blood pressure consultation.",
                Price = 400,
                DurationMinutes = 45,
                DepartmentId = 1
            },
            new MedicalService
            {
                Id = 2,
                Name = "ECG Investigation",
                Description = "Electrocardiogram investigation for heart activity.",
                Price = 250,
                DurationMinutes = 20,
                DepartmentId = 1
            },
            new MedicalService
            {
                Id = 3,
                Name = "Dermatology Consultation",
                Description = "Skin examination and treatment recommendations.",
                Price = 350,
                DurationMinutes = 40,
                DepartmentId = 2
            },
            new MedicalService
            {
                Id = 4,
                Name = "Neurology Consultation",
                Description = "Consultation for nervous system problems.",
                Price = 450,
                DurationMinutes = 50,
                DepartmentId = 3
            },
            new MedicalService
            {
                Id = 5,
                Name = "Narcology Consultation",
                Description = "Consultation for addiction-related medical issues.",
                Price = 300,
                DurationMinutes = 45,
                DepartmentId = 4
            },
            new MedicalService
            {
                Id = 6,
                Name = "Blood Test",
                Description = "Basic laboratory blood analysis.",
                Price = 180,
                DurationMinutes = 15,
                DepartmentId = 5
            },
            new MedicalService
            {
                Id = 7,
                Name = "Ultrasound Investigation",
                Description = "Ultrasound diagnostic investigation.",
                Price = 500,
                DurationMinutes = 30,
                DepartmentId = 6
            },
            new MedicalService
            {
                Id = 8,
                Name = "X-Ray Investigation",
                Description = "Radiology investigation for diagnostic purposes.",
                Price = 350,
                DurationMinutes = 20,
                DepartmentId = 6
            }
        );
    }
}