namespace MedicalAppointmentSystem.Models;

public abstract class Person
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    protected Person(int id, string name)
    {
        Id = id;
        Name = name;
    }
}