namespace MedicalAppointmentSystem.Bridge
{
    public class ConfirmationNotification : AppointmentNotification
    {
        public ConfirmationNotification(INotificationChannel notificationChannel)
            : base(notificationChannel)
        {
        }

        public override void Notify(string patientName, string doctorName, DateTime appointmentDate)
        {
            string message = $"Appointment confirmed for {patientName} with {doctorName} on {appointmentDate}.";
            notificationChannel.Send(message);
        }
    }
}