using MedicalAppointmentSystem.Models;
using MedicalAppointmentSystem.Services;
using MedicalAppointmentSystem.Repositories;
using MedicalAppointmentSystem.Interfaces;
using MedicalAppointmentSystem.Factories;

class Program
{
    static void Main(string[] args)
    {
        Doctor doctor = new Doctor(1, "Dr. Popescu", "Cardiology");
        Patient patient = new Patient(1, "Ana Maria", "123456789");

        // ABSTRACT FACTORY
        IClinicFactory clinicFactory = new PremiumClinicFactory();

        MedicalService service = clinicFactory.CreateService();
        INotificationService notification = clinicFactory.CreateNotificationService();

        Appointment appointment = new Appointment(
            1,
            DateTime.Now,
            doctor,
            patient,
            service
        );

        IAppointmentRepository repository = new AppointmentRepository();

        AppointmentService appointmentService =
            new AppointmentService(repository, notification);

        appointmentService.CreateAppointment(appointment);
    }
}
