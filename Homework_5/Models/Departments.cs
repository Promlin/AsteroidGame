using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5.Models
{
    class Departments
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public override string ToString() => $"{Name}";

        public static implicit operator string(Departments v)
        {
            throw new NotImplementedException();
        }
    }
}
