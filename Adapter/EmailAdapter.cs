namespace MedicalAppointmentSystem.Adapter
{
    public class EmailAdapter : INotification
    {
        private OldEmailService oldService;

        public EmailAdapter(OldEmailService service)
        {
            oldService = service;
        }

        public void Send(string message)
        {
            oldService.SendEmail(message);
        }
    }
}