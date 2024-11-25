namespace ADONetSakila
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            DatabaseService databaseService = new DatabaseService(connectionString);
            ActorRepository actorRepository = new ActorRepository(databaseService);
            Controller controller = new Controller(actorRepository);
            controller.Run();
        }
    }
}
