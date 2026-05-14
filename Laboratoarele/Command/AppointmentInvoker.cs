namespace MedicalAppointmentSystem.Command
{
    public class AppointmentInvoker
    {
        private ICommand? command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Execute()
        {
            if (command == null)
            {
                Console.WriteLine("No command selected.");
                return;
            }

            command.Execute();
        }
    }
}