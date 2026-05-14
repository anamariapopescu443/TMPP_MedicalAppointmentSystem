using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.State;

public class DeclinedAppointmentState : IAppointmentState
{
    public void Confirm(Appointment appointment)
    {
        throw new InvalidOperationException("A declined appointment cannot be confirmed.");
    }

    public void Decline(Appointment appointment, string declineReason)
    {
        throw new InvalidOperationException("This appointment is already declined.");
    }

    public void Complete(Appointment appointment, string doctorComment)
    {
        throw new InvalidOperationException("A declined appointment cannot be completed.");
    }

    public void Cancel(Appointment appointment)
    {
        throw new InvalidOperationException("A declined appointment cannot be cancelled.");
    }
}