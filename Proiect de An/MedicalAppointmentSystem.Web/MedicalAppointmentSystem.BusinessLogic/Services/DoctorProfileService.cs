using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.DataAccess;
using MedicalAppointmentSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentSystem.BusinessLogic.Services;

public class DoctorProfileService : IDoctorProfileService
{
    private readonly ApplicationDbContext _context;

    public DoctorProfileService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Doctor?> GetDoctorByIdAsync(int doctorId)
    {
        return await _context.Doctors
            .Include(d => d.Hospital)
            .Include(d => d.Department)
            .FirstOrDefaultAsync(d => d.Id == doctorId);
    }

    public async Task UpdateDoctorProfileAsync(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
    }
}