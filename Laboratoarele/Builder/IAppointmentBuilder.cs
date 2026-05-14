using MedicalAppointmentSystem.Models;

namespace MedicalAppointmentSystem.Builder
{
    public interface IAppointmentBuilder
    {
        void SetPatient(string name);
        void SetDoctor(string name);
        void SetService(string service);
        void SetDate(string date);
        void SetReminder(bool reminder);

        Appointment GetAppointment();
    }
}