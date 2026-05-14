namespace MedicalAppointmentSystem.Iterator
{
    public class AppointmentIterator : IAppointmentIterator
    {
        private List<string> items;
        private int index = 0;

        public AppointmentIterator(List<string> items)
        {
            this.items = items;
        }

        public bool HasNext()
        {
            return index < items.Count;
        }

        public string Next()
        {
            return items[index++];
        }
    }
}