namespace MedicalAppointmentSystem.Proxy
{
    public class AppointmentProxy : IAppointmentAccess
    {
        private RealAppointmentAccess realService = new RealAppointmentAccess();
        private string role;

        public AppointmentProxy(string role)
        {
            this.role = role;
        }

        public void Access()
        {
            if (role == "admin")
            {
                realService.Access();
            }
            else
            {
                Console.WriteLine("Access denied!");
            }
        }
    }
}