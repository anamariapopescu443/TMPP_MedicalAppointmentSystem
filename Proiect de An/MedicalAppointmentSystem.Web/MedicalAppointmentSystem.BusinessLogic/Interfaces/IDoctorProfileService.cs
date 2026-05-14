using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Interfaces;

public interface IDoctorProfileService
{
    Task<Doctor?> GetDoctorByIdAsync(int doctorId);

    Task UpdateDoctorProfileAsync(Doctor doctor);
}