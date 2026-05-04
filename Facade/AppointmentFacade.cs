using MedicalAppointmentSystem.Interfaces;
using MedicalAppointmentSystem.Models;
using MedicalAppointmentSystem.Repositories;
using MedicalAppointmentSystem.Services;

namespace MedicalAppointmentSystem.Facade
{
    public class AppointmentFacade
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentFacade()
        {
            IAppointmentRepository repository = new AppointmentRepository();
            INotificationService notificationService = new EmailNotificationService();

            _appointmentService = new AppointmentService(repository, notificationService);
        }

        public void CreateAppointment(
            int appointmentId,
            string patientName,
            string patientPhone,
            string doctorName,
            string doctorSpecialty,
            string serviceType,
            DateTime appointmentDate,
            bool reminder)
        {
            Doctor doctor = new Doctor(1, doctorName, doctorSpecialty);
            Patient patient = new Patient(1, patientName, patientPhone);

            MedicalService medicalService;

            if (serviceType == "Surgery")
            {
                medicalService = new Surgery();
            }
            else
            {
                medicalService = new Consultation();
            }

            Appointment appointment = new Appointment(
                appointmentId,
                appointmentDate,
                doctor,
                patient,
                medicalService
            );

            appointment.Reminder = reminder;

            _appointmentService.CreateAppointment(appointment);

            Console.WriteLine("Appointment created through Facade.");
            appointment.ShowDetails();
        }
    }
}