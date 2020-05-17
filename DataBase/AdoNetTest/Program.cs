using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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

            Console.ReadLine();
        }
    }
}
