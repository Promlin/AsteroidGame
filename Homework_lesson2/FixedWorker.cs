using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_lesson2
{
    class FixedWorker : Workers
    {
        public FixedWorker(string Name, int Period, int Value)
            : base(Name, Period, Value)
        {
        }

        public override void CountSum(string name, int period, int value)
        {
            Console.WriteLine("За {0} месяцев работник по имени {1} получит: {2} рублей", period, name, period*value);
        }
    }
}
