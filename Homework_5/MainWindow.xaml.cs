using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string FileName = "Names.txt";

        public class User
        {
            public string Employee { get; set; }
            public string Department { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            List.Items.Add(new User { Employee = "Горшков", Department = "Расследования" });


            using (var file = File.OpenText(FileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var components = line.Split(' ');

                    if (components.Length != 3) continue;

                    List.Items.Add(new User { Employee = components[0], Department = components[1] });

                }
            }
        }


        private void LoadEmployee_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор файла",
                Filter = "*.txt|*.txt"
            };

            if (dialog.ShowDialog() != true) return;

            var file_path = dialog.FileName;

            if (!File.Exists(file_path)) return;

            var file_text = File.ReadAllText(file_path);

            EmployeeTextBox.Text = file_text;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadDepartments_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор файла",
                Filter = "*.txt|*.txt"
            };

            if (dialog.ShowDialog() != true) return;

            var file_path = dialog.FileName;

            if (!File.Exists(file_path)) return;

            var file_text = File.ReadAllText(file_path);

            DepartmentsTextBox.Text = file_text;
        }
    }
    
}
