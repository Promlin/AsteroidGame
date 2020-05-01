using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class Star : VisualObject
    {
        public Star(Point Position, Point Direction, int Size) : base(Position, Direction, new Size(Size, Size))
        {

        }

        /// <summary> Отрисовка звезды</summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            g.DrawLine(Pens.White, _Position.X, _Position.Y, _Position.X + _Size.Width, _Position.Y + _Size.Height);
            g.DrawLine(Pens.White, _Position.X + _Size.Width, _Position.Y, _Position.X, _Position.Y + _Size.Height);
            //g.DrawImage;
            //Image asteroid = Image.FromFile("brownAsteroid.jpg");
            //Point position = new Point(20, 20);
            //g.DrawImage(asteroid, position);
        }

        public override void Update()
        {
            _Position.X += _Direction.X;
            if (_Position.X < 0)
            {
                _Position.X = Game.Width + _Size.Width;
            }
        }

    }
}
