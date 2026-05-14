namespace MedicalAppointmentSystem.Prototype
{
    public class MedicalDocument : IPrototype
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        public IPrototype Clone()
        {
            return (MedicalDocument)this.MemberwiseClone();
        }

        public void Show()
        {
            Console.WriteLine($"Document: {Title}");
            Console.WriteLine(Content);
        }
    }
}