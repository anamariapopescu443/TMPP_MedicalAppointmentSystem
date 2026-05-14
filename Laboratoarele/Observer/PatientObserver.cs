namespace MedicalAppointmentSystem.Observer
{
    public class PatientObserver : IObserver
    {
        private string name;

        public PatientObserver(string name)
        {
            this.name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine(name + " received: " + message);
        }
    }
}