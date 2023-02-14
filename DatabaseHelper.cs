using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace CarDataBase
{
    public static class DatabaseHelper
    {
        public static void ConnectToDatabase()
        {
            string connectionString = "Server=localhost;Database=car;Uid=root;Pwd=12345;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Conexão com o banco de dados MySQL estabelecida com sucesso.");
                System.Console.WriteLine(connection.Database);

                string sql = "INSERT INTO carros (marca, modelo, potencia) VALUES (@marca, @modelo, @potencia)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@marca", "nissan");
                cmd.Parameters.AddWithValue("@modelo", "gtr_skyline");
                cmd.Parameters.AddWithValue("@potencia", "250");

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    Console.WriteLine("Informações adicionadas com sucesso.");
                }
                else
                {
                    Console.WriteLine("Falha ao adicionar informações.");
                }
                connection.Close();

                connection.Open();


                using (MySqlConnection connect = new MySqlConnection(connectionString))
                {
                    //connection.Open();

                    string tableName = "carros";
                    string query = $"DESCRIBE {tableName}";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Colunas da tabela '{0}':", tableName);
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.GetString(0));
                            }
                        }
                    }
                }

            }



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM carros";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("marca: " + reader["marca"].ToString());
                    Console.WriteLine("modelo: " + reader["modelo"].ToString());
                    Console.WriteLine("potencia: " + reader["potencia"].ToString());
                    Console.WriteLine("peso: " + reader["peso"].ToString());
                    Console.WriteLine("torque: " + reader["torque"].ToString());
                    Console.WriteLine("placa: " + reader["placa"].ToString());
                    Console.WriteLine();
                }
            }
        }
        
        class Carro
        {
         
            public string Modelo { get; set; }
            public string Marca { get; set; }
            public string Potencia { get; set; }

            public Carro(string modelo, string marca, string potencia)
            {
                Modelo = modelo;
                Marca = marca;
                Potencia = potencia;
            }

        }

        public static void addCar()
        {
             string connectionString = "Server=localhost;Database=car;Uid=root;Pwd=12345;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Conexão com o banco de dados MySQL estabelecida com sucesso.");
                System.Console.WriteLine(connection.Database);

                string sql = "INSERT INTO carros (marca, modelo, potencia) VALUES (@marca, @modelo, @potencia)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@marca", "nissan");
                cmd.Parameters.AddWithValue("@modelo", "gtr_skyline");
                cmd.Parameters.AddWithValue("@potencia", "250");

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    Console.WriteLine("Informações adicionadas com sucesso.");
                }
                else
                {
                    Console.WriteLine("Falha ao adicionar informações.");
                }
                connection.Close();

                connection.Open();


                using (MySqlConnection connect = new MySqlConnection(connectionString))
                {
                    //connection.Open();

                    string tableName = "carros";
                    string query = $"DESCRIBE {tableName}";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Colunas da tabela '{0}':", tableName);
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.GetString(0));
                            }
                        }
                    }
                }

            }
        }


    }
}





