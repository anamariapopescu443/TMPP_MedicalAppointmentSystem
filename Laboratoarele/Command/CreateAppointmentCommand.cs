namespace MedicalAppointmentSystem.Command
{
    public class CreateAppointmentCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Appointment created!");
        }
    }
}