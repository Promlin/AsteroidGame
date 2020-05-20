using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDataBaseTest.Data.Entityes
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public virtual StudentsGroup Group { get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }

    
}
