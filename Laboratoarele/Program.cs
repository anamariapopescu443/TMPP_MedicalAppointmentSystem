using MedicalAppointmentSystem.Strategy;
using MedicalAppointmentSystem.Observer;
using MedicalAppointmentSystem.Command;
using MedicalAppointmentSystem.Memento;
using MedicalAppointmentSystem.Iterator;

class Program
{
    static void Main()
    {
        Console.WriteLine("================= STRATEGY =================");

        var context = new NotificationContext();
        context.SetStrategy(new EmailStrategy());
        context.Execute("Appointment notification");

        context.SetStrategy(new SMSStrategy());
        context.Execute("Appointment notification");


        Console.WriteLine("\n================= OBSERVER =================");

        var subject = new AppointmentSubject();
        subject.Attach(new PatientObserver("Ana"));
        subject.Attach(new PatientObserver("Ion"));
        subject.Notify("New appointment created");


        Console.WriteLine("\n================= COMMAND =================");

        var invoker = new AppointmentInvoker();
        invoker.SetCommand(new CreateAppointmentCommand());
        invoker.Execute();


        Console.WriteLine("\n================= MEMENTO =================");

        var originator = new AppointmentOriginator();
        var history = new AppointmentHistory();

        originator.State = "Appointment created";
        history.Save(originator.Save());

        originator.State = "Appointment date changed";

        var previousState = history.Undo();

        if (previousState != null)
        {
            originator.Restore(previousState);
        }

        Console.WriteLine("Restored state: " + originator.State);


        Console.WriteLine("\n================= ITERATOR =================");

        var collection = new AppointmentCollection();
        collection.Add("Appointment 1: Ana - Consultation");
        collection.Add("Appointment 2: Ion - Surgery");

        var iterator = collection.CreateIterator();

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}