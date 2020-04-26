﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    internal abstract class ImageObject : VisualObject
    {
        private readonly Image _Image;

        protected ImageObject(Point Position, Point Direction, Size Size, Image Image) 
            : base(Position, Direction, Size)
        {
            _Image = Image; 
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_Image, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }
    }

    internal class Asteroid : ImageObject
    {
        //private static readonly Image __Image = Image.FromFile("src\\brownAsteroid.jpg");
        public Asteroid(Point Position, Point Direction, int ImageSize)
            //: base(Position, Direction, new Size(ImageSize, ImageSize), __Image)
            : base(Position, Direction, new Size(ImageSize, ImageSize), Properties.Resources.brownAsteroid)
        {
        }

        public override void Draw(Graphics g)
        {
            
        }
    }
}
