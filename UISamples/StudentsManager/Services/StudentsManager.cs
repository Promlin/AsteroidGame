using StudentsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Services
{
    class StudentsManager
    {
        public List<StudentsGroup> Groups { get; }

        public StudentsManager()
        {
            var student_id = 1;
            Groups = Enumerable.Range(1, 10)
                .Select(i => new StudentsGroup
                {
                    Id = i,
                    Name = $"Group {i}",
                    Students = Enumerable
                    .Range(1, 10)
                    .Select(j => new Student
                    {
                        Id = student_id,
                        Name = $"Name {student_id}",
                        Surname = $"Surname {student_id}",
                        Patronymic = $"Patronymic {student_id++}"
                    })
                    .ToList()
                })
                .ToList();

            foreach (var group in Groups)
                foreach (var student in group.Students)
                    student.Group = group;
        }
    }
}
