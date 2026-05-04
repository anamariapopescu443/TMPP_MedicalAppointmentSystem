namespace MedicalAppointmentSystem.Memento
{
    public class AppointmentOriginator
    {
        public string State { get; set; } = string.Empty;

        public AppointmentMemento Save()
        {
            return new AppointmentMemento(State);
        }

        public void Restore(AppointmentMemento memento)
        {
            State = memento.State;
        }
    }
}