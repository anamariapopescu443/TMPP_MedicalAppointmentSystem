namespace MedicalAppointmentSystem.Memento
{
    public class AppointmentHistory
    {
        private Stack<AppointmentMemento> history = new();

        public void Save(AppointmentMemento memento)
        {
            history.Push(memento);
        }

        public AppointmentMemento? Undo()
        {
            if (history.Count == 0)
            {
                return null;
            }

            return history.Pop();
        }
    }
}