using MedicalAppointmentSystem.Flyweight;
using MedicalAppointmentSystem.Decorator;
using MedicalAppointmentSystem.Bridge;
using MedicalAppointmentSystem.Proxy;

class Program
{
    static void Main()
    {
        Console.WriteLine("================= FLYWEIGHT =================");

        var s1 = ServiceFactory.GetService("Consultation");
        var s2 = ServiceFactory.GetService("Consultation");

        var a1 = new AppointmentFlyweight(1, s1);
        var a2 = new AppointmentFlyweight(2, s2);

        a1.Show();
        a2.Show();

        Console.WriteLine("Same instance: " + (s1 == s2));


        Console.WriteLine("\n================= DECORATOR =================");

        INotificationComponent notification = new BasicNotification();
        notification = new EmailDecorator(notification);
        notification = new SMSDecorator(notification);

        notification.Send("Appointment created");


        Console.WriteLine("\n================= BRIDGE =================");

        INotificationChannel emailChannel = new EmailChannel();
        AppointmentNotification confirmationByEmail = new ConfirmationNotification(emailChannel);

        confirmationByEmail.Notify(
            "Ana Maria",
            "Dr. Popescu",
            new DateTime(2026, 6, 10, 10, 30, 0)
        );

        INotificationChannel smsChannel = new SMSChannel();
        AppointmentNotification reminderBySms = new ReminderNotification(smsChannel);

        reminderBySms.Notify(
            "Ana Maria",
            "Dr. Popescu",
            new DateTime(2026, 6, 10, 10, 30, 0)
        );


        Console.WriteLine("\n================= PROXY =================");

        var proxy1 = new AppointmentProxy("user");
        proxy1.Access();

        var proxy2 = new AppointmentProxy("admin");
        proxy2.Access();
    }
}