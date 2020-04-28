using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_lesson2
{
    internal abstract class Workers
    {
        protected string _Name;
        protected int _Period;
        protected int _Value;

        protected Workers(string Name, int Period, int Value)
        {
            _Name = Name;
            _Period = Period;
            _Value = Value;
        }

        public abstract void CountSum(string name, int period, int value);

    }
}
