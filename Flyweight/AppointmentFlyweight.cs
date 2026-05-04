namespace MedicalAppointmentSystem.Flyweight
{
    public class AppointmentFlyweight
    {
        private int id;
        private MedicalServiceType service;

        public AppointmentFlyweight(int id, MedicalServiceType service)
        {
            this.id = id;
            this.service = service;
        }

        public void Show()
        {
            service.Show(id);
        }
    }
}