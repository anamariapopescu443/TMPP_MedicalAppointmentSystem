using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.State;

public class CancelledAppointmentState : IAppointmentState
{
    public void Confirm(Appointment appointment)
    {
        throw new InvalidOperationException("A cancelled appointment cannot be confirmed.");
    }

    public void Decline(Appointment appointment, string declineReason)
    {
        throw new InvalidOperationException("A cancelled appointment cannot be declined.");
    }

    public void Complete(Appointment appointment, string doctorComment)
    {
        throw new InvalidOperationException("A cancelled appointment cannot be completed.");
    }

    public void Cancel(Appointment appointment)
    {
        throw new InvalidOperationException("This appointment is already cancelled.");
    }
}