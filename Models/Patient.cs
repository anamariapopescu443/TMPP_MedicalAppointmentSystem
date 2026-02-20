namespace MedicalAppointmentSystem.Models;

public class Patient : Person
{
    public string PhoneNumber { get; private set; }

    public Patient(int id, string name, string phoneNumber)
        : base(id, name)
    {
        PhoneNumber = phoneNumber;
    }
}