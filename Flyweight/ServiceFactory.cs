namespace MedicalAppointmentSystem.Flyweight
{
    public class ServiceFactory
    {
        private static Dictionary<string, MedicalServiceType> services = new();

        public static MedicalServiceType GetService(string name)
        {
            if (!services.ContainsKey(name))
            {
                services[name] = new MedicalServiceType(name, "Default description");
            }

            return services[name];
        }
    }
}