using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Interfaces;

public interface ILookupService
{
    Task<List<Patient>> GetPatientsAsync();
    Task<List<Hospital>> GetHospitalsAsync();
    Task<List<Department>> GetDepartmentsAsync();
    Task<List<Doctor>> GetDoctorsAsync();
    Task<List<MedicalService>> GetMedicalServicesAsync();
}