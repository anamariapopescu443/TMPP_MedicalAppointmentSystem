using MedicalAppointmentSystem.Models;

namespace MedicalAppointmentSystem.Builder
{
    public class AppointmentBuilder : IAppointmentBuilder
    {
        private int id;
        private DateTime date;
        private Doctor? doctor;
        private Patient? patient;
        private MedicalService? service;
        private bool reminder;

        public void SetPatient(string name)
        {
            patient = new Patient(1, name, "000000");
        }

        public void SetDoctor(string name)
        {
            doctor = new Doctor(1, name, "General");
        }

        public void SetService(string serviceName)
        {
            if (serviceName == "Surgery")
                service = new Surgery();
            else
                service = new Consultation();
        }

        public void SetDate(string dateValue)
        {
            date = DateTime.Parse(dateValue);
        }

        public void SetReminder(bool reminder)
        {
            this.reminder = reminder;
        }

        public Appointment GetAppointment()
        {
            var appointment = new Appointment(
                1,
                date,
                doctor!,
                patient!,
                service!
            );

            appointment.Reminder = reminder;

            return appointment;
        }
    }
}