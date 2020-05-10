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
        private static readonly List<Bullet> __Bullets = new List<Bullet>();

        private static SpaceShip __SpaceShip;
        public static Timer __Timer;

        public static Action<String> Log { get; set; }

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

            __Timer = new Timer { Interval = __TimerInterval };  //вызов метода при истечении интервала
            __Timer.Tick += OnVimerTick;
            __Timer.Start();

            form.KeyDown += OnFormKeyDown;

            Log?.Invoke("выполнена  инициализация");
        }

        //private static void OnTestButtonClick(object Sender, EventArgs e)
        //{
        //    MessageBox.Show("Кнопка нажата");
        //}

        private static int __CtrlKeyPressed;
        private static int __UpKeyPressed;
        private static int __DownKeyPressed;
        private static void OnFormKeyDown(object sender, KeyEventArgs E)
        {
            switch (E.KeyCode)
            {
                case Keys.ControlKey:
                    //__Bullets.Add(new Bullet(__SpaceShip.Rect.Y));
                    __CtrlKeyPressed++;
                    break;

                case Keys.Up:
                    //__SpaceShip.MoveUp();
                    __UpKeyPressed++;
                    break;

                case Keys.Down:
                    //__SpaceShip.MoveDown();
                    __DownKeyPressed++;
                    break;
            }

            Log?.Invoke($"Нажата кнопка {E.KeyCode}");
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

            __SpaceShip.Draw(g);

            __Bullets.ForEach(bullet => bullet.Draw(g));

            if (!__Timer.Enabled) return;

            __Buffer.Render(); //перенесение изображения на экран
        }

        /// <summary> Загрузка игровых объектов</summary>
        public static void Load()
        {
            Log?.Invoke("Загрузка данных сцены...");

            List<VisualObject> game_objects = new List<VisualObject>();

            __GameObjects = new VisualObject[30];

            const int star_count = 150;
            const int star_size = 5;
            const int star_max_speed = 20;
            Random rnd = new Random();
            for (int i = 0; i < star_count; i++)   //звездный фон
            {
                game_objects.Add(new Star(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, star_max_speed), 0),
                    star_size));
            }
            Log?.Invoke("Создание звезд");

            const int asteroid_count = 15;
            const int asteroid_size = 30;
            const int asteroid_max_speed = 20;
            for (int i = 0; i < asteroid_count; i++)
            {
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0,Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0), 
                    asteroid_size));
            }
            Log?.Invoke("Создание астероиды");


            __GameObjects = game_objects.ToArray();

            __SpaceShip = new SpaceShip(new Point(10, 400), new Point(5, 5), new Size(10, 10));
            __SpaceShip.Destroyed += OnShipDestroyed;

            Log?.Invoke("Загрузка данных сцены выполнена");
        }

        private static void OnShipDestroyed(object Sender, EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            g.Clear(Color.DarkBlue);
            g.DrawString("Game over", new Font(FontFamily.GenericSerif, 60, FontStyle.Bold), Brushes.Red, 200, 100);
            __Buffer.Render();
            Log?.Invoke("Уничтожение корабля");
        }

        public static void Update()
        {
            if(__CtrlKeyPressed > 0)
            {
                for (int i = 0; i < __CtrlKeyPressed; i++)
                    __Bullets.Add(new Bullet(__SpaceShip.Rect.Y));
                __CtrlKeyPressed = 0;
            }

            if (__UpKeyPressed > 0)
            {
                for (int i = 0; i < __UpKeyPressed; i++)
                    __SpaceShip.MoveUp();
                __UpKeyPressed = 0;
            }

            if (__DownKeyPressed > 0)
            {
                for (int i = 0; i < __DownKeyPressed; i++)
                    __SpaceShip.MoveDown();
                __DownKeyPressed = 0;
             
            }

            foreach (var game_object in __GameObjects)
            {
                game_object?.Update();
            }

            __Bullets.ForEach(b => b.Update());
            foreach (var bullet_to_remove in __Bullets.Where(b => b.Rect.Left > Width).ToArray())
                __Bullets.Remove(bullet_to_remove);


            for(int i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if(obj is ICollision)
                { 
                    var collision_object = (ICollision) obj;

                    __SpaceShip.CheckCollision(collision_object);

                    foreach(var bullet in __Bullets.ToArray())
                        if (bullet.CheckCollision(collision_object))
                        {
                            __Bullets.Remove(bullet);
                            __GameObjects[i] = null;
                            System.Media.SystemSounds.Asterisk.Play();//TODO заменить звук
                            Log?.Invoke("Астероид уничтожен");
                        }
                }
            }
        }

    }
}
