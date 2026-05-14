namespace MedicalAppointmentSystem.Flyweight
{
    public class MedicalServiceType
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public MedicalServiceType(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Show(int appointmentId)
        {
            Console.WriteLine($"Appointment {appointmentId} -> {Name}");
        }
    }
}