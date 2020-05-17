using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel.Design;

namespace AdoNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AsteroidsDB-Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //DbConnectionStringBuilder builder = new DbConnectionStringBuilder();

            //var sql_server_connection_string_builder = new SqlConnectionStringBuilder(connection_string);
            //sql_server_connection_string_builder.IntegratedSecurity = false;

            const string connection_string_name = "DefaultConnection";

            var connection_string = ConfigurationManager.ConnectionStrings[connection_string_name].ConnectionString;
            //ExecuteNonQuery(connection_string);
            //ExecuteScalar(connection_string);
            ExecuteReader(connection_string);

            Console.ReadLine();
        }

        private const string __SqlCreateTablePlayer = @"
CREATE TABLE [dbo].[Player]
(
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
    [Email] NVARCHAR(100) NULL,
    [Phone] NVARCHAR(MAX) NULL,
    [Birthday] NVARCHAR(MAX) NULL,
    CONSTRAINT[PK_dbo.People] PRIMARY KEY CLUSTERED([Id] ASC)
);";


        private const string _SqlInsertToPlayerTable = @"INSERT INTO [dbo].[Player] (Name,Birthday,Email,Phone) VALUES (N'{0}','{1}','{2}','{3}');";
        private static void ExecuteNonQuery(string ConnectionString) //метод для подключения к БД и ничего не возвращающий
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open(); //открытие соединения
                //var create_table_commend = new SqlCommand(__SqlCreateTablePlayer, connection);
                //create_table_commend.ExecuteNonQuery();

                var insert_data_command = new SqlCommand(
                    string.Format(_SqlInsertToPlayerTable,
                    "Иванов Александр Петрович",
                    "13.10.2000",
                    "ivanov@server.ru",
                    "+79320230302"), connection);
                insert_data_command.ExecuteNonQuery();
            }
        }

        private const string __SqlCountPlayers = @"SELECT COUNT(*) FROM [dbo].[Player]";

        private static void ExecuteScalar(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var count_command = new SqlCommand(__SqlCountPlayers, connection);
                count_command.ExecuteScalar();
                if (!(count_command.ExecuteScalar() is int count))
                    throw new InvalidOperationException("Ошибка в результате выполнения подсчета количества игроков");
            }
        }

        private const string __SqlSelectFromPlayer = @"SELECT * FROM [dbo].[Player]";

        private static void ExecuteReader(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var select_command = new SqlCommand(__SqlSelectFromPlayer, connection);
                using(var reader = select_command.ExecuteReader())
                {
                    if(reader.HasRows)
                        while (reader.Read())
                        {
                            var id = (int)reader.GetValue(0);
                            var name = reader.GetString(1);
                            var email = reader["Email"] as string;
                            var phone = reader.GetString(reader.GetOrdinal("Phone"));

                            Console.WriteLine("id:{0}\tname:{1}\temail:{2}\tphone:{3}", id, name, email, phone);
                        }
                }
            }
        }
    }
}
