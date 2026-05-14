using MedicalAppointmentSystem.Domain.Enums;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.FactoryMethod;

public static class AppointmentFactoryProvider
{
    public static IAppointmentFactory GetFactory(AppointmentType appointmentType)
    {
        return appointmentType switch
        {
            AppointmentType.Standard => new StandardAppointmentFactory(),
            AppointmentType.Emergency => new EmergencyAppointmentFactory(),
            AppointmentType.FollowUp => new FollowUpAppointmentFactory(),
            AppointmentType.Online => new OnlineAppointmentFactory(),
            _ => new StandardAppointmentFactory()
        };
    }
}