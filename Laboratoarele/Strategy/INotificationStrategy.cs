namespace MedicalAppointmentSystem.Strategy
{
    public interface INotificationStrategy
    {
        void Send(string message);
    }
}