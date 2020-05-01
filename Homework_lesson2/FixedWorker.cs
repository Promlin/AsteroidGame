using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_lesson2
{
    class FixedWorker : Workers
    {


        public override void CountSum(string name, int period, int value)
        {
            Console.WriteLine("За {0} месяцев работник по имени {1} получит: {2} рублей", period, name, period*value);
        }

        public override void Pay(string[] nameArray, int period, int value)
        {
            for (int i = 0; i < FixedWorkerArr.Length; i++)
            {
                Console.WriteLine("За {0} месяцев работник по имени {1} получит: {2} рублей", period, nameArray[i], period * value);
            }
        }
    }
}
