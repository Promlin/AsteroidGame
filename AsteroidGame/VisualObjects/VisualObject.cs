using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{

    internal abstract class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        protected VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

    public abstract void Draw(Graphics g);  //отрисовка на экране
        //{
        //    g.DrawEllipse(
        //        Pens.White,
        //        _Position.X, _Position.Y,
        //        _Size.Width, _Size.Height
        //        );
        //    //g.DrawImage;
        //    //Image asteroid = Image.FromFile("Asteroids\browmAsteroid.jpg");
        //    //g.DrawImage(asteroid);
        //}

        virtual public void Update()  //обновление состояния
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;

            if (_Position.X < 0 || _Position.X > Game.Width)
            {
                _Direction.X *= -1;
            }

            if (_Position.Y < 0 || _Position.Y > Game.Height)
            {
                _Direction.Y *= -1;
            }
        }

    }
}
