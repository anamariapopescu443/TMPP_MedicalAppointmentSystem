namespace MedicalAppointmentSystem.Bridge
{
    public interface INotificationChannel
    {
        void Send(string message);
    }
}