namespace MedicalAppointmentSystem.Models;

public class Surgery : MedicalService
{
    public Surgery()
    {
        ServiceName = "Surgery";
    }

    public override decimal GetPrice()
    {
        return 1500;
    }
}