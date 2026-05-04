namespace MedicalAppointmentSystem.Composite
{
    public class MedicalServiceLeaf : IMedicalComponent
    {
        private string name;

        public MedicalServiceLeaf(string name)
        {
            this.name = name;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Service: " + name);
        }
    }
}