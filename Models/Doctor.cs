namespace MedicalAppointmentSystem.Models;

public class Doctor : Person
{
    public string Specialty { get; private set; }

    public Doctor(int id, string name, string specialty)
        : base(id, name)
    {
        Specialty = specialty;
    }
}