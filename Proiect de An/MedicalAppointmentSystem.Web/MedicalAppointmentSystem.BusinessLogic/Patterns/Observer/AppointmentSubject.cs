using MedicalAppointmentSystem.Domain.Models;

namespace MedicalAppointmentSystem.BusinessLogic.Patterns.Observer;

public class AppointmentSubject
{
    private readonly List<IAppointmentObserver> _observers = new();

    public void Attach(IAppointmentObserver observer)
    {
        _observers.Add(observer);
    }

    public async Task NotifyAsync(Appointment appointment, string eventMessage)
    {
        foreach (var observer in _observers)
        {
            await observer.UpdateAsync(appointment, eventMessage);
        }
    }
}