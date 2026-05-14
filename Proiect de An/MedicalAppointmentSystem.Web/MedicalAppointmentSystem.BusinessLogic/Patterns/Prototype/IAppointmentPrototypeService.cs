using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Prototype;

public interface IAppointmentPrototypeService
{
    Task<Appointment> CreateFollowUpFromExistingAsync(
        int appointmentId,
        int doctorId,
        DateTime followUpDate);
}