using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.State;

public interface IAppointmentState
{
    void Confirm(Appointment appointment);
    void Decline(Appointment appointment, string declineReason);
    void Complete(Appointment appointment, string doctorComment);
    void Cancel(Appointment appointment);
}