namespace MedicalAppointmentSystem.Proxy
{
    public class RealAppointmentAccess : IAppointmentAccess
    {
        public void Access()
        {
            Console.WriteLine("Accessing appointment data...");
        }
    }
}