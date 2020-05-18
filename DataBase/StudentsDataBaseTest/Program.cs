using StudentsDataBaseTest.Data.Entityes;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsDataBaseTest.Data;

namespace StudentsDataBaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new StudentsDB())
            {
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var students_count = db.Students.Count();
                Console.WriteLine("Students in DB: {0}", students_count);
            }

            using(var db = new StudentsDB())
            {
                if (!db.Groups.Any())
                {
                    var student_n = 1;
                    for(var group_n = 1; group_n < 10; group_n++)
                    {
                        var group = new StudentsGroup
                        {
                            Name = $"Group {group_n}"
                        };

                        for(var i = 0; i < 10; i++)
                        {
                            var student = new Student
                            {
                                Name = $"Student {student_n}",
                                Surname = $"Surname {student_n}",
                                Patronymic = $"Patronymic {student_n}"
                            };
                            group.Students.Add(student);
                            student_n++;
                        }

                        db.Groups.Add(group);
                    }
                }

                db.SaveChanges();
            }

            using(var db = new StudentsDB())
            {
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var students_group_id_7 = db.Students
                    .Include(student => student.Group)
                    .Where(student => student.Group.Id == 7).ToArray();
            }

            Console.ReadLine();
        }
    }
}
