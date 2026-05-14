namespace MedicalAppointmentSystem.Strategy
{
    public class NotificationContext
    {
        private INotificationStrategy? strategy;

        public void SetStrategy(INotificationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Execute(string message)
        {
            if (strategy == null)
            {
                Console.WriteLine("No notification strategy selected.");
                return;
            }

            strategy.Send(message);
        }
    }
}