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

                // using (var connect = new MySqlConnection(connectionString))
                // {

                //     using (var command = new MySqlCommand("SHOW TABLES", connection))
                //     {
                //         using (var reader = command.ExecuteReader())
                //         {
                //             while (reader.Read())
                //             {
                //                 for (int i = 0; i < reader.FieldCount; i++)
                //                 {
                //                     Console.WriteLine(reader.GetValue(i));
                //                 }
                //             }
                //         }
                //     }
                // }
                //   connection.Close();

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
                // using (var connecti = new MySqlConnection(connectionString))
                // {
                //     //connection.Open();

                //     using (var command = new MySqlCommand("SELECT COLUMN_NAME, COLUMN_TYPE, IS_NULLABLE, COLUMN_KEY, COLUMN_DEFAULT, EXTRA FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'your_database_name' AND TABLE_NAME = 'your_table_name'", connection))
                //     {
                //         using (var reader = command.ExecuteReader())
                //         {
                //             while (reader.Read())
                //             {
                //                 Console.WriteLine("Column name: {0}, Column type: {1}, Is nullable: {2}, Column key: {3}, Column default: {4}, Extra: {5}", reader["COLUMN_NAME"], reader["COLUMN_TYPE"], reader["IS_NULLABLE"], reader["COLUMN_KEY"], reader["COLUMN_DEFAULT"], reader["EXTRA"]);
                //             }
                //         }
                //     }
                // }
            }
            //   using (MySqlConnection connection = new MySqlConnection(connectionString))
            // {
            //     connection.Open();

            //     string showColumnsQuery = "SHOW COLUMNS FROM carros";
            //     using (MySqlCommand command = new MySqlCommand(showColumnsQuery, connection))
            //     {
            //         using (MySqlDataReader reader = command.ExecuteReader())
            //         {
            //             while (reader.Read())
            //             {
            //                 Console.WriteLine("Column name: " + reader["Field"]);
            //                 Console.WriteLine("Data type: " + reader["Type"]);
            //                 Console.WriteLine("Is Nullable: " + reader["Null"]);
            //                 Console.WriteLine("Key: " + reader["Key"]);
            //                 Console.WriteLine("Default Value: " + reader["Default"]);
            //                 Console.WriteLine("Extra: " + reader["Extra"]);
            //                 Console.WriteLine("----------------------------------------");
            //             }
            //         }

            // using (var connection = new MySqlConnection(connectionString))
            // {
            //     connection.Open();

            //     var cmd = new MySqlCommand("SELECT * FROM carros LIMIT 1", connection);
            //     using (var reader = cmd.ExecuteReader())
            //     {
            //         var schema = reader.GetSchemaTable();
            //         foreach (DataRow column in schema.Rows)
            //         {
            //             Console.WriteLine("Column name: " + column["ColumnName"]);
            //             Console.WriteLine("Data type: " + column["DataType"]);
            //             Console.WriteLine("Is Nullable: " + column["AllowDBNull"]);
            //             Console.WriteLine("Key: " + column["IsKey"]);
            //             Console.WriteLine("Default Value: " + column["ColumnDefaultValue"]);
            //             Console.WriteLine("Extra: " + column["Extra"]);
            //             Console.WriteLine("----------------------------------------");
            //         }
            //     }
            // }
            // Use a string de conexão para criar uma nova conexão ao banco de dados


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

    }
}





