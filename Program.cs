using MedicalAppointmentSystem.Builder;
using MedicalAppointmentSystem.Models;
using MedicalAppointmentSystem.Prototype;
using MedicalAppointmentSystem.Singleton;

class Program
{
    static void Main(string[] args)
    {

        // BUILDER
        AppointmentBuilder builder = new AppointmentBuilder();
        AppointmentDirector director = new AppointmentDirector();

        director.BuildStandardAppointment(builder);

        Appointment appointment = builder.GetAppointment();
        appointment.ShowDetails();


        // PROTOTYPE
        MedicalDocument doc1 = new MedicalDocument();
        doc1.Title = "Medical Report";
        doc1.Content = "Patient is healthy.";

        MedicalDocument doc2 = (MedicalDocument)doc1.Clone();
        doc2.Title = "Medical Report Copy";

        doc1.Show();
        doc2.Show();


        // SINGLETON
        DatabaseConnection db1 = DatabaseConnection.GetInstance();
        DatabaseConnection db2 = DatabaseConnection.GetInstance();

        db1.Connect();

        Console.WriteLine(db1 == db2);
    }
}