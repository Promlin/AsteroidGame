﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal class SpaceShip : VisualObject, ICollision
    {
        public event EventHandler Destroyed;  //событие разрушения корабля

        private int _Energy = 20;

        public int Energy => _Energy;
        public Rectangle Rect => new Rectangle(_Position, _Size);

        public SpaceShip(Point Position, Point Direction, Size Size) 
            : base(Position, Direction, Size)
        {
        }

        public override void Draw(Graphics g)
        {
            var rect = Rect;
            g.FillEllipse(Brushes.Blue, rect);  //TODO заменить на картинку
            g.DrawEllipse(Pens.Yellow, rect);
        }

        public override void Update(){ }

        public bool CheckCollision(ICollision obj)
        {
            var is_collision = Rect.IntersectsWith(obj.Rect);
            
            if(is_collision && obj is Asteroid asteroid)
            {
                ChangeEnergy(-asteroid.Power);
            }
            
            return is_collision;
        }

        public void ChangeEnergy(int delta)
        {
            _Energy += delta;

            if (_Energy < 0)
                Destroyed?.Invoke(this, EventArgs.Empty);
        }

        public void MoveUp()
        {
            if (_Position.Y > 0)
                _Position.Y -= _Direction.Y;
        }

        public void MoveDown()
        {
            if (_Position.Y - _Size.Height < Game.Height)
                _Position.Y += _Direction.Y;
        }

    }
}
