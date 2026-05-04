namespace MedicalAppointmentSystem.Bridge
{
    public class ReminderNotification : AppointmentNotification
    {
        public ReminderNotification(INotificationChannel notificationChannel)
            : base(notificationChannel)
        {
        }

        public override void Notify(string patientName, string doctorName, DateTime appointmentDate)
        {
            string message = $"Reminder: {patientName}, you have an appointment with {doctorName} on {appointmentDate}.";
            notificationChannel.Send(message);
        }
    }
}