using MedicalAppointmentSystem.Models;
using MedicalAppointmentSystem.Services;
using MedicalAppointmentSystem.Repositories;
using MedicalAppointmentSystem.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        Doctor doctor = new Doctor(1, "Dr. Popescu", "Cardiology");
        Patient patient = new Patient(1, "Ana Maria", "123456789");

        MedicalService service = new Consultation();

        Appointment appointment = new Appointment(
            1,
            DateTime.Now,
            doctor,
            patient,
            service
        );

        IAppointmentRepository repository = new AppointmentRepository();
        INotificationService notification = new EmailNotificationService();

        AppointmentService appointmentService =
            new AppointmentService(repository, notification);

        appointmentService.CreateAppointment(appointment);
    }
}
