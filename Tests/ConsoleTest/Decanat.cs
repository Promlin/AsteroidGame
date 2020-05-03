
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class Decanat : Storage<Student>
    {
        private int _MaxId = 1;

        public override void Add(Student item)
        {
            item.Id = _MaxId++;
            base.Add(item);
        }
    }
}
