using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using AsteroidGame.VisualObjects;

namespace AsteroidGame
{
    internal static class Game
    {
        /// <summary>Интервал времени таймера формирования кадра игры</summary>
        private const int __TimerInterval = 100;

        private static BufferedGraphicsContext __Context; //два подчеркивания - поле статическое
        private static BufferedGraphics __Buffer;

        //массив игровых объектов
        private static VisualObject[] __GameObjects;
        private static Bullet __Bullet;
        private static SpaceShip __SpaceShip;

        /// <summary>Высота игрового поля</summary>
        public static int Width { get; private set; }
        /// <summary>Ширина игрового поля</summary>
        public static int Height { get; private set; }


        /// <summary>
        /// Инициализация игровой логики
        /// </summary>
        /// <param name="form">Игровая форма</param>
        public static void Initialize(Form form) //метод для инициализации формы
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = __TimerInterval };  //вызов метода при истечении интервала
            timer.Tick += OnVimerTick;
            timer.Start();
        }

        private static void OnVimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }
        /// <summary>Отрисовка игровых объектов</summary>
        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200)); //отрисовка фигурв
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120)); //залить фигуры цветом

            foreach (var game_object in __GameObjects)
            {
                game_object?.Draw(g);
            }

            __Bullet?.Draw(g);

            __Buffer.Render(); //перенесение изображения на экран
        }

        /// <summary> Загрузка игровых объектов</summary>
        public static void Load()
        {
            List<VisualObject> game_objects = new List<VisualObject>();

            __GameObjects = new VisualObject[30];

            //for (int i = 0; i < 30; i++)
            //{
            //    game_objects.Add(new VisualObject(
            //        new Point(600, i * 20),
            //        new Point(15 - i, 20 - i),
            //        new Size(20, 20)));
            //}

            for (int i = 0; i < 15; i++)
            {
                game_objects.Add(new Star(
                    new Point(600, i * 20),
                    new Point(-i, 0),
                    10));
            }

            Random rnd = new Random();

            const int asteroid_count = 15;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;
            for (int i = 0; i < asteroid_count; i++)
            {
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0,Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0), 
                    asteroid_size));
            }

            __Bullet = new Bullet(200);

            __GameObjects = game_objects.ToArray();
        }

        public static void Update()
        {
            foreach (var game_object in __GameObjects)
            {
                game_object?.Update();
            }

            __Bullet?.Update();

            if (__Bullet is null || __Bullet.Rect.Left > Width)
            {
                Random rnd  = new Random();
                __Bullet = new Bullet(rnd.Next(0, Height));
            }

            for(int i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if(obj is ICollision)
                {
                    var collision_object = (ICollision) obj;
                    if (__Bullet != null)
                    {
                        if (__Bullet.CheckCollision(collision_object))
                        {
                            __Bullet = null;
                            __GameObjects[i] = null;
                            System.Media.SystemSounds.Asterisk.Play();//TODO заменить звук
                        }
                    }
                }
            }
        }

    }
}
