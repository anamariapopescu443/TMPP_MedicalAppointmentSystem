namespace MedicalAppointmentSystem.Adapter
{
    public class EmailAdapter : INotificationSender
    {
        private readonly OldEmailService _oldEmailService;

        public EmailAdapter(OldEmailService oldEmailService)
        {
            _oldEmailService = oldEmailService;
        }

        public void Send(string message)
        {
            _oldEmailService.SendOldEmail(message);
        }
    }
}