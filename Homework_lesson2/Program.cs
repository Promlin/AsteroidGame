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
            Workers Worker1 = new FixedWorker();
            Worker1.CountSum("Валентин", 2, 20000);

            Workers Worker2 = new HourWorker();
            Worker2.CountSum("Егор", 56, 400);

            Workers FixWorker = new FixedWorker();
            string[] FixWorkersArray = FixWorker.FixedWorkerArr;
            FixWorker.Pay(FixWorkersArray, 2, 20000);

            Workers HourWorker = new HourWorker();
            string[] HourWorkerArray = HourWorker.HourWorkersArr;
            HourWorker.Pay(HourWorkerArray, 40, 500);

            Console.ReadLine();
        }
    }
}
