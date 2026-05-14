using MedicalAppointmentSystem.Domain.Enums;
using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.State;

public class ConfirmedAppointmentState : IAppointmentState
{
    public void Confirm(Appointment appointment)
    {
        throw new InvalidOperationException("This appointment is already confirmed.");
    }

    public void Decline(Appointment appointment, string declineReason)
    {
        throw new InvalidOperationException("A confirmed appointment cannot be declined.");
    }

    public void Complete(Appointment appointment, string doctorComment)
    {
        appointment.Status = AppointmentStatus.Completed;
        appointment.DoctorComment = doctorComment;
        appointment.CompletedAt = DateTime.Now;
    }

    public void Cancel(Appointment appointment)
    {
        appointment.Status = AppointmentStatus.Cancelled;
        appointment.DoctorComment = "Confirmed appointment was cancelled.";
    }
}