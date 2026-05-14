using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.State;

public class PendingAppointmentState : IAppointmentState
{
    public void Confirm(Appointment appointment)
    {
        appointment.Status = AppointmentStatus.Confirmed;
        appointment.DoctorComment = "Appointment confirmed by doctor.";
    }

    public void Decline(Appointment appointment, string declineReason)
    {
        appointment.Status = AppointmentStatus.Declined;
        appointment.DeclineReason = declineReason;
        appointment.DoctorComment = declineReason;
    }

    public void Complete(Appointment appointment, string doctorComment)
    {
        throw new InvalidOperationException("A pending appointment must be confirmed before it can be completed.");
    }

    public void Cancel(Appointment appointment)
    {
        appointment.Status = AppointmentStatus.Cancelled;
        appointment.DoctorComment = "Appointment cancelled.";
    }
}