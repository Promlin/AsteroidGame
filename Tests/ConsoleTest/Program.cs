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

        private const string __NamesFile = "Names.txt";

        static void Main(string[] args)
        {
            //foreach (var student in GetStudents(__NamesFile))
            //    Console.WriteLine(student.Surname + " " + student.Name + " " + student.Patronimyc);

            //List<Student> students_list = new List<Student>(100);
            ////students_list.Count количество элементов листа
            ////students_list.Capacity = student_list.Count;  количество выделенных ячеек/ подрезание списка

            //int id = 1;
            //var rnd = new Random();

            //foreach (var student in GetStudents(__NamesFile))
            //{
            //    student.Id = id++;
            //    students_list.Add(student);

            //}

            //students_list.RemoveAt(2);

            //var student_2 = students_list[2];
            //students_list.IndexOf(student_2);
            //students_list.BinarySearch(); //более быстрыйй поиск

            ////Сортировка списка по увеличению фамилии
            //students_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s1.Surname, s2.Surname));

            ////сортировка по имени
            //students_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s1.Name, s2.Name));

            //students_list.Clear();

            //students_list.AddRange(GetStudents(__NamesFile)); //добавление студентов в список

            //Student[] students_array = students_list.ToArray(); //превращение списка в массив
            //var new_student_list = new List<Student>(students_array); //обратно к списку

            //var list = new ArrayList(new_student_list);

            //list.Add(42);
            //list.Add("Hello world!");


            //Stack<Student> student_stack = new Stack<Student>(100); //стек - элемнты друг на друге
            //foreach (var student in GetStudents(__NamesFile))
            //{
            //    student_stack.Push(student);
            //}
            //var last_student = student_stack.Pop(); //достаем последего добавленного студента

            //Queue<Student> student_queue = new Queue<Student>(100); //очередь
            //while (student_queue.Count > 0)
            //    student_queue.Enqueue(student_stack.Pop());  //преобразуем стек в очередь

            //Dictionary<string, List<Student>> surname_students = new Dictionary<string, List<Student>>();   //словарь - пары ключ-значение
            //foreach (var student in GetStudents(__NamesFile))
            //{
            //    var surname = student.Surname;
            //    if (surname_students.ContainsKey(surname))
            //        surname_students[surname].Add(student);
            //    else
            //    {
            //        var new_list = new List<Student>();
            //        new_list.Add(student);
            //        surname_students.Add(surname, new_list);
            //    }

            //}

            //Console.WriteLine(new string('-', Console.BufferWidth));

            //if (surname_students.TryGetValue("Ясаев", out var students))
            //{
            //    foreach (var student in students)
            //        Console.WriteLine(student);
            //}

            IEnumerable<Student> students = GetStudents(__NamesFile);

            Console.ReadLine();
        }

        private static IEnumerable<Student> GetStudents(string FileName)
        {
            var rnd = new Random();

            using (var file = File.OpenText(FileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var components = line.Split(' ');

                    if (components.Length != 3) continue;

                    var student = new Student();
                    student.Surname = components[0];
                    student.Name = components[1];
                    student.Patronimyc = components[2];
                    student.Ratings = rnd.GetValues(20, 2, 6);

                    yield return student;
                }
            }


            //yield return new Student();
            //yield break;  для генератора 
        }
    }
}
