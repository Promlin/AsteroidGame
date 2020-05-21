using FileHosting.Interfaces;
using FileHosting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student student = new Student
            //{
            //    Name = "Student name",
            //    Surname = "Student surname",
            //    Birthday = DateTime.Now
            //};

            //var binary_formatter = new BinaryFormatter();
            //var xml_serializer = new XmlSerializer(typeof(Student));

            //using (var bin_file = File.Create("student.bin"))
            //using (var xml_file = File.Create("student.xml"))
            //{
            //    binary_formatter.Serialize(bin_file, student);
            //    xml_serializer.Serialize(xml_file, student);
            //}

            //Student s1, s2;
            //using(var bin_file = File.Open("student.bin", FileMode.Open))
            //using(var xml_file = File.Open("student.xml", FileMode.Open))
            //{
            //    s1 = (Student)binary_formatter.Deserialize(bin_file);
            //    s2 = (Student)xml_serializer.Deserialize(xml_file);
            //}

            var host = new ServiceHost(typeof(FileService),
                new Uri("http://localhost:8080/FileService")
                //new Uri("net.tcp://localhost/FileService"),
                //new Uri("net.pipe://localhost/FileService")
                );

            host.AddServiceEndpoint(
                typeof(IFileService),
                new BasicHttpBinding(),
                "http://localhost:8080/FileService"
                );

            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });

            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "Mex");

            host.Open();

            Console.WriteLine("Хост запущен");
            Console.ReadLine();

        }

        
    }

    //[Serializable]
    //public class Student
    //{
    //    public string Name { get; set; }
    //    public string Surname { get; set; }
    //    public DateTime Birthday { get; set; }
    //}
}
