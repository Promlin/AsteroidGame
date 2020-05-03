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
    class Program
    {
        static void Main(string[] args)
        {
            var decanat = new Decanat();

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

            var student_to_remove = decanat[0];

            decanat.Remove(student_to_remove);

            var random_student = new Student { Name = rnd.GetValue("Алешин", "Петров", "Марочкин") };

            Console.ReadLine();
        }
    }
}
