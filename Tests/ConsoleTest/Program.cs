using ConsoleTest.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.IO;
using ConsoleTest.Service;

namespace ConsoleTest
{
    internal delegate int StringProcessor(string str); //делегат 

    internal delegate void StudentProcessor(Student student);

    class Program
    {
        static void Main(string[] args)
        {
            var decanat = new Decanat();

            decanat.SubscribeToAdd(PrintStudent);

            var rnd = new Random();

            for(int i = 0; i < 100; i++)
            {
                decanat.Add(new Student
                {
                    Name = $"Name {i}",
                    Surname = $"Surname {i}",
                    Patronimyc = $"Patronymic {i}",
                    Ratings = rnd.GetValues(rnd.Next(20,30), 3, 6)
                });
            }

            //foreach (var student in decanat)
            //{
            //    Console.WriteLine(student.Name);
            //}

            var student_to_remove = decanat[0];

            decanat.Remove(student_to_remove);

            var random_student = new Student { Name = rnd.GetValue("Алешин", "Петров", "Марочкин") };

            //decanat.SafeToFile("decanat.csv");

            var decanat2 = new Decanat();

            decanat2.LoadFromFile("decanat.csv");

            StringProcessor str_processor = new StringProcessor(GetStringLength);
            var length = str_processor("Hello world");
            Console.WriteLine(length);

            //StudentProcessor process = new StudentProcessor(PrintStudent);
            //process(random_student);

            //process = RateStudent;
            //process(random_student);

            ProcessStudent(decanat2, PrintStudent);

            var decanat3 = new Decanat();
            ProcessStudent(decanat2, decanat3.Add);

            Console.ReadLine();
        }

        private static int GetStringLength(string str)
        {
            return str.Length;
        }

        private static void PrintStudent(Student student)
        {
            Console.WriteLine("[{0}]{1}{2}{3} - {4}", student.Id,
                student.Surname, student.Name, student.Patronimyc, student.AverageRating);
        }

        private static void RateStudent(Student student)
        {
            var rnd = new Random();
            student.Ratings.AddRange(rnd.GetValues(5, 2, 6));
        }

        private static void ProcessStudent(IEnumerable<Student> students, StudentProcessor Processor)
        {
            foreach(var student in students)
            {
                Processor(student);
            }
        }
    }
}
