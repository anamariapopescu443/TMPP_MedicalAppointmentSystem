namespace MedicalAppointmentSystem.Builder
{
    public class AppointmentDirector
    {
        public void BuildStandardAppointment(IAppointmentBuilder builder)
        {
            builder.SetPatient("Ana Maria");
            builder.SetDoctor("Dr. Popescu");
            builder.SetService("Consultation");
            builder.SetDate("2026-06-10");
            builder.SetReminder(true);
        }
    }
}