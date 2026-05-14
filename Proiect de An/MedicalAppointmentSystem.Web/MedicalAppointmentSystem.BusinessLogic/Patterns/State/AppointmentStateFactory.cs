using MedicalAppointmentSystem.Domain.Enums;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.State;

public static class AppointmentStateFactory
{
    public static IAppointmentState Create(AppointmentStatus status)
    {
        return status switch
        {
            AppointmentStatus.Pending => new PendingAppointmentState(),
            AppointmentStatus.Confirmed => new ConfirmedAppointmentState(),
            AppointmentStatus.Declined => new DeclinedAppointmentState(),
            AppointmentStatus.Completed => new CompletedAppointmentState(),
            AppointmentStatus.Cancelled => new CancelledAppointmentState(),
            _ => throw new InvalidOperationException("Unknown appointment status.")
        };
    }
}