﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal class Bullet : CollisionObject
    {
        private const int __BulletSizeX = 20;
        private const int __BulletSizeY = 5;
        private const int __BulletSpeed = 15;

        public Bullet(int Position)
            : base(new Point(0, Position), Point.Empty, new Size(__BulletSizeX, __BulletSizeY))
        {
        }

        public override void Draw(Graphics g)
        {
            var rect = new Rectangle(_Position, _Size);
            g.FillEllipse(Brushes.Red, rect);   //заменить пулю на изображение
            g.DrawEllipse(Pens.White, rect);
            //Image bullet = Properties.Resources.bullet1;
            //g.DrawImage;
            //Image bullet = Properties.Resources.bullet1;
            //g.DrawImage(bullet);
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + __BulletSpeed, _Position.Y);
        }
    }
}
