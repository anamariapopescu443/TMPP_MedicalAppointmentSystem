using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.DataAccess;
using MedicalAppointmentSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentSystem.BusinessLogic.Services;

public class LookupService : ILookupService
{
    private readonly ApplicationDbContext _context;

    public LookupService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Patient>> GetPatientsAsync()
    {
        return await _context.Patients
            .OrderBy(p => p.FirstName)
            .ToListAsync();
    }

    public async Task<List<Hospital>> GetHospitalsAsync()
    {
        return await _context.Hospitals
            .OrderBy(h => h.Name)
            .ToListAsync();
    }

    public async Task<List<Department>> GetDepartmentsAsync()
    {
        return await _context.Departments
            .Include(d => d.Hospital)
            .OrderBy(d => d.Name)
            .ToListAsync();
    }

    public async Task<List<Doctor>> GetDoctorsAsync()
    {
        return await _context.Doctors
            .Include(d => d.Hospital)
            .Include(d => d.Department)
            .OrderBy(d => d.FirstName)
            .ToListAsync();
    }

    public async Task<List<MedicalService>> GetMedicalServicesAsync()
    {
        return await _context.MedicalServices
            .Include(s => s.Department)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}