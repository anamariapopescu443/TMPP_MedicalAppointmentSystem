using MedicalAppointmentSystem.Adapter;
using MedicalAppointmentSystem.Composite;
using MedicalAppointmentSystem.Facade;

class Program
{
    static void Main(string[] args)
    {
        // ================= ADAPTER =================
        OldEmailService oldService = new OldEmailService();
        INotification adapter = new EmailAdapter(oldService);

        adapter.Send("Programare nouă");


        // ================= COMPOSITE =================
        var service1 = new MedicalServiceLeaf("Consultation");
        var service2 = new MedicalServiceLeaf("Analysis");

        var combo = new MedicalServiceComposite();
        combo.Add(service1);
        combo.Add(service2);

        combo.ShowDetails();


        // ================= FACADE =================
        Console.WriteLine("\n================= FACADE =================");

        AppointmentFacade facade = new AppointmentFacade();

        facade.CreateAppointment(
            1,
            "Ana Maria",
            "060000000",
            "Dr. Popescu",
            "General Medicine",
            "Consultation",
            new DateTime(2026, 6, 10, 10, 30, 0),
            true
        );
    }
}