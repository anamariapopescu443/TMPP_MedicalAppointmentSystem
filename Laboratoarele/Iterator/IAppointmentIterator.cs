namespace MedicalAppointmentSystem.Iterator
{
    public interface IAppointmentIterator
    {
        bool HasNext();
        string Next();
    }
}