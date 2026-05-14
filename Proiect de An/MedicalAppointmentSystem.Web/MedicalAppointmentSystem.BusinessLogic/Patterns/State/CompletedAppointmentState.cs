using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.State;

public class CompletedAppointmentState : IAppointmentState
{
    public void Confirm(Appointment appointment)
    {
        throw new InvalidOperationException("A completed appointment cannot be confirmed again.");
    }

    public void Decline(Appointment appointment, string declineReason)
    {
        throw new InvalidOperationException("A completed appointment cannot be declined.");
    }

    public void Complete(Appointment appointment, string doctorComment)
    {
        throw new InvalidOperationException("This appointment is already completed.");
    }

    public void Cancel(Appointment appointment)
    {
        throw new InvalidOperationException("A completed appointment cannot be cancelled.");
    }
}