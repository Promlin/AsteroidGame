using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            const int Width = 800;
            const int Height = 600;

            //создание формы
            Form game_form = new Form();
            //Screen.PrimaryScreen.WorkingArea.Height     для области по высоте экрана 
            game_form.Width = Width;
            game_form.Height = Height;

            game_form.Show();

            Game.Initialize(game_form);
            Game.Load();
            Game.Draw();

            Application.Run(game_form);

            System.Threading.Thread.Sleep(1000);
            //Application.Run(); //внутри можно указать главное окно
        }
    }
}
