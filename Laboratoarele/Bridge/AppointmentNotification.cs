namespace MedicalAppointmentSystem.Bridge
{
    public abstract class AppointmentNotification
    {
        protected INotificationChannel notificationChannel;

        protected AppointmentNotification(INotificationChannel notificationChannel)
        {
            this.notificationChannel = notificationChannel;
        }

        public abstract void Notify(string patientName, string doctorName, DateTime appointmentDate);
    }
}
