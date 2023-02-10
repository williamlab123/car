
namespace CarDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.ConnectToDatabase();
            Console.ReadKey();
        }
    }
}