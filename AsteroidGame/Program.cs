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

            //создание формы
            Form game_form = new Form();
            //Screen.PrimaryScreen.WorkingArea.Height     для области по высоте экрана 
            game_form.Width = 800;
            game_form.Height = 600;

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
