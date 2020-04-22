using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class PrefixPrinter : Printer //наследование от Printer
    {
        public string Prefix { get; set; } = "Как не стыдно???";
        public void PrintData(double X)
        {
            Console.WriteLine("{1} Уже {0}", X, Prefix);
        }

        public override void Print(string Message)//переопределенный метод Print
        {
            Console.WriteLine(Prefix);
            base.Print(Message);
        }
    }
}
