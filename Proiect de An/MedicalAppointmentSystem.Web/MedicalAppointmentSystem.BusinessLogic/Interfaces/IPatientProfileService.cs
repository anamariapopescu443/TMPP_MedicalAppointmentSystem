using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Interfaces;

public interface IPatientProfileService
{
    Task<Patient?> GetPatientByIdAsync(int patientId);

    Task UpdatePatientProfileAsync(Patient patient);

    Task UpdateMedicalCardPathAsync(int patientId, string filePath);
}