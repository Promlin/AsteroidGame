using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5.Models
{
    internal class Employee
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Patronimyc { get; set; }
        public string Department { get; set; }
        public string Patronymic { get; internal set; }

        internal IEnumerable<object> Range(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
