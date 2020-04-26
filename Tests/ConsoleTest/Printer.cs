using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Printer
    {
        public virtual void Print(string Message)//метод который можно переопределять
        {
            Console.WriteLine(Message);
        }
    }
}
