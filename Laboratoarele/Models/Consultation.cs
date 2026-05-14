namespace MedicalAppointmentSystem.Models;

public class Consultation : MedicalService
{
    public Consultation()
    {
        ServiceName = "Consultation";
    }

    public override decimal GetPrice()
    {
        return 200;
    }
}