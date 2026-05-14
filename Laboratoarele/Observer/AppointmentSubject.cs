namespace MedicalAppointmentSystem.Observer
{
    public class AppointmentSubject
    {
        private List<IObserver> observers = new();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
}