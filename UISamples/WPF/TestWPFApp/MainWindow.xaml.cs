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

namespace TestWPFApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileButton(object sender, RoutedEventArgs e)
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

            TextAditor.Text = file_text;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
