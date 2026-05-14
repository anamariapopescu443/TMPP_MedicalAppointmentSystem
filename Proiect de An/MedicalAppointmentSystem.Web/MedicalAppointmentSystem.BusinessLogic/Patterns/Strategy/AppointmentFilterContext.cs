using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Strategy;

public class AppointmentFilterContext
{
    private readonly IAppointmentFilterStrategy _strategy;

    public AppointmentFilterContext(IAppointmentFilterStrategy strategy)
    {
        _strategy = strategy;
    }

    public List<Appointment> ApplyFilter(IEnumerable<Appointment> appointments)
    {
        return _strategy.Filter(appointments).ToList();
    }

    public static IAppointmentFilterStrategy CreateStrategy(string? filter)
    {
        return filter switch
        {
            "today" => new TodayAppointmentsStrategy(),
            "tomorrow" => new TomorrowAppointmentsStrategy(),
            "pending" => new PendingAppointmentsStrategy(),
            "confirmed" => new ConfirmedAppointmentsStrategy(),
            "completed" => new CompletedAppointmentsStrategy(),
            "declined" => new DeclinedAppointmentsStrategy(),
            _ => new AllAppointmentsStrategy()
        };
    }
}