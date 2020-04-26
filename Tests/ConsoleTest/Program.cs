using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Player player1 = new Player();  обращение при отстутствии конструктора с параметрами
            //player1.Name = "Алёша";
            Player player = new Player("Иванушка");
            Console.WriteLine(player.GetName());

            Vector2D vector1 = new Vector2D(5, 7);
            Vector2D vector2 = new Vector2D(-7, 2);

            Vector2D vector3 = vector1 + vector2;
            double Length = vector3;

            Printer printer = new Printer();
            printer.Print("Ну как же так");
            PrefixPrinter prefix_printer = new PrefixPrinter();
            prefix_printer.PrintData(17.48);

            Console.ReadLine();
        }
    }
}
