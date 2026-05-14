using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Facade;

public interface IAppointmentFacade
{
    Task CreateAppointmentAsync(
        int patientId,
        int hospitalId,
        int departmentId,
        int doctorId,
        int medicalServiceId,
        DateTime appointmentDate,
        string reason,
        AppointmentType type);
}