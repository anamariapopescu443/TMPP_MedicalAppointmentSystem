namespace MedicalAppointmentSystem.Models;

public class Appointment
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public Doctor Doctor { get; private set; }
    public Patient Patient { get; private set; }
    public MedicalService Service { get; private set; }

    public Appointment(int id, DateTime date,
                       Doctor doctor,
                       Patient patient,
                       MedicalService service)
    {
        Id = id;
        Date = date;
        Doctor = doctor;
        Patient = patient;
        Service = service;
    }
}