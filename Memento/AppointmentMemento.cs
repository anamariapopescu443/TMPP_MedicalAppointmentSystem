namespace MedicalAppointmentSystem.Memento
{
    public class AppointmentMemento
    {
        public string State { get; }

        public AppointmentMemento(string state)
        {
            State = state;
        }
    }
}