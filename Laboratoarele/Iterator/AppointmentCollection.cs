namespace MedicalAppointmentSystem.Iterator
{
    public class AppointmentCollection
    {
        private List<string> items = new();

        public void Add(string item)
        {
            items.Add(item);
        }

        public IAppointmentIterator CreateIterator()
        {
            return new AppointmentIterator(items);
        }
    }
}