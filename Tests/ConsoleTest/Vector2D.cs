using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Vector2D  //класс - ссылочный типа данных
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }


        public double Angle => Math.Atan2(Y, X);

        public Vector2D() { }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector2D operator +(Vector2D a, Vector2D b) //переопределение оператора
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }

        public static implicit operator double(Vector2D vector)//явное преобразование типа данных
        {
            return vector.Length;
        }
    }

    //структура -- нельзя наследоваться, значимый тип данных
    //нельзя использовать конструктор без параметров
    //в конструкторе все поля должны быть инициализированны
    public struct Vector2dStruct
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
