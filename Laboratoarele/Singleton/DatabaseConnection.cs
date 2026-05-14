namespace MedicalAppointmentSystem.Singleton
{
    public class DatabaseConnection
    {
        private static DatabaseConnection? instance;

        private DatabaseConnection()
        {
            Console.WriteLine("Database connection created.");
        }

        public static DatabaseConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseConnection();
            }

            return instance;
        }

        public void Connect()
        {
            Console.WriteLine("Connected to database.");
        }
    }
}