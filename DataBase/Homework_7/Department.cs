using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7
{
    public class Department
    {
        public string Name { get; set; }

        public Department(string name)
        {
            Name = name;
        }

        public Department()
        {
        }

        //public List<Department> Departments { get; set; } = new List<Department>();
    }
}
