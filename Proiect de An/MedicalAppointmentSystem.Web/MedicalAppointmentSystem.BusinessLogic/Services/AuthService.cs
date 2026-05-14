using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.DataAccess;
using MedicalAppointmentSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentSystem.BusinessLogic.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;

    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(bool Success, string Role, int UserId, string FullName, string Error)> LoginAsync(
        string email,
        string password)
    {
        var patient = await _context.Patients
            .FirstOrDefaultAsync(p => p.Email == email && p.Password == password);

        if (patient != null)
        {
            return (true, "Patient", patient.Id, patient.FullName, "");
        }

        var doctor = await _context.Doctors
            .FirstOrDefaultAsync(d => d.Email == email && d.Password == password);

        if (doctor != null)
        {
            return (true, "Doctor", doctor.Id, doctor.FullName, "");
        }

        return (false, "", 0, "", "Invalid email or password.");
    }

    public async Task<(bool Success, string Error)> RegisterPatientAsync(Patient patient)
    {
        var emailExists = await _context.Patients.AnyAsync(p => p.Email == patient.Email)
            || await _context.Doctors.AnyAsync(d => d.Email == patient.Email);

        if (emailExists)
        {
            return (false, "This email is already used.");
        }

        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        return (true, "");
    }

    public async Task<(bool Success, string Error)> RegisterDoctorAsync(Doctor doctor)
    {
        var emailExists = await _context.Patients.AnyAsync(p => p.Email == doctor.Email)
            || await _context.Doctors.AnyAsync(d => d.Email == doctor.Email);

        if (emailExists)
        {
            return (false, "This email is already used.");
        }

        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();

        return (true, "");
    }
}