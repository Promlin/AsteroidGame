using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_lesson2
{
    internal abstract class Workers
    {

        public string[] HourWorkersArr = new string[] { "Варя", "Коля", "Сеня", "Вася" };
        public string[] FixedWorkerArr = new string[] {"Арсений","Игнат" };

        public abstract void CountSum(string name, int period, int value);

        public abstract void Pay(string[] nameArray, int period, int value);
    }
}
