using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDataBaseTest.Data.Entityes
{
    public class StudentsGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public override string ToString() => $"[{Id}]{Name}";

    }
}
