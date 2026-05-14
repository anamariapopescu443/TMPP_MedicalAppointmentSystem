using MedicalAppointmentSystem.BusinessLogic.Interfaces;
using MedicalAppointmentSystem.DataAccess;
using MedicalAppointmentSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentSystem.BusinessLogic.Services;

public class PatientProfileService : IPatientProfileService
{
    private readonly ApplicationDbContext _context;

    public PatientProfileService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Patient?> GetPatientByIdAsync(int patientId)
    {
        return await _context.Patients
            .FirstOrDefaultAsync(p => p.Id == patientId);
    }

    public async Task UpdatePatientProfileAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMedicalCardPathAsync(int patientId, string filePath)
    {
        var patient = await _context.Patients.FindAsync(patientId);

        if (patient == null)
        {
            throw new Exception("Patient not found.");
        }

        patient.MedicalCardFilePath = filePath;

        await _context.SaveChangesAsync();
    }
}