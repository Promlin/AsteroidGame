using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Workers Worker1 = new FixedWorker("Валентин", 2, 20000);
            Worker1.CountSum("Валентин", 2, 20000);

            Workers Worker2 = new HourWorker("Егор", 56, 400);
            Worker2.CountSum("Егор", 56, 400);

            Console.ReadLine();
        }
    }
}
