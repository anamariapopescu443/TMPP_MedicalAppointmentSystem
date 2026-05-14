namespace MedicalAppointmentSystem.Composite
{
    public class MedicalServiceComposite : IMedicalComponent
    {
        private List<IMedicalComponent> components = new();

        public void Add(IMedicalComponent component)
        {
            components.Add(component);
        }

        public void ShowDetails()
        {
            Console.WriteLine("Composite Service:");

            foreach (var c in components)
            {
                c.ShowDetails();
            }
        }
    }
}