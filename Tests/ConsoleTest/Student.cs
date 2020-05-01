using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class Student : ILogger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }
        public int GroupID { get; set; }

        public void Log(string Message)
        {
            Console.WriteLine("Студент {0} пишет в журнал: {1}", Name, Message);
        }

        
    }
}
