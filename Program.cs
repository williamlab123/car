using MySql.Data.MySqlClient;

namespace CarDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.ConnectToDatabase();
            Console.ReadKey();
            DatabaseHelper.addCar();
            System.Console.WriteLine("");

        }
    }
  
}