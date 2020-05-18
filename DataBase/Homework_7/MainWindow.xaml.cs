using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Homework_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            const string connection_string_name = "homeworkDB";
            var connection_string = ConfigurationManager.ConnectionStrings[connection_string_name].ConnectionString;


            LoadDepartments(connection_string);




            //LoadDepartments();

            InitializeComponent();
        }

        //public DataTable Select(string selectSQL) 
        //{
        //    DataTable dataTable = new DataTable("dataBase");                

        //    SqlConnection sqlConnection = new SqlConnection("");
        //    sqlConnection.Open();                                          
        //    SqlCommand sqlCommand = sqlConnection.CreateCommand();         
        //    sqlCommand.CommandText = selectSQL;                          
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); 
        //    sqlDataAdapter.Fill(dataTable);

        //    //sqlConnection.Close();

        //    return dataTable;
        //}

        //void LoadDepartments()
        //{
        //    DataTable dt_Depart = Select("SELECT * FROM [dbo].[Department]");  
        //    for (int i = 0; i < dt_Depart.Rows.Count; i++)  
        //    {
        //        Department dataDepartment = new Department()       
        //        {
        //            Name = dt_Depart.Rows[i][1].ToString(),     
        //        };
        //        DepartmentList.Items.Add(dataDepartment); 
        //    }
        //}

        private const string __SqlSelectFromDepartment = @"SELECT * FROM [dbo].[Department]";
        public void LoadDepartments(string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var select_command = new SqlCommand(__SqlSelectFromDepartment, connection);
                using (var reader = select_command.ExecuteReader())
                {
                    //var departments = new List<Department>();
                    //if (reader.HasRows)
                    //    while (reader.Read())
                    //    {
                    //        departments.Add(new Department()
                    //        {
                    //            Name = reader.GetString(1)
                    //        });
                    //    }
                    //DepartmentList.ItemsSource = departments;
                    if(reader.HasRows)
                        while (reader.Read())
                        {
                            Department department = new Department()
                            {
                                Name = reader.GetString(1)
                            };
                            DepartmentList.Items.Add(department);
                        }
                }
            }
        }

    }
}
