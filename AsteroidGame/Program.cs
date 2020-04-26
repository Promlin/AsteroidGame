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

            const int game_form_width = 800;
            const int game_form_height = 600;

            if (game_form_width > 1000 || game_form_width < 0)
                throw new ArgumentOutOfRangeException(nameof(game_form_width), game_form_width, "Ширина экрана должна быть положительна и меньше 1000");

            if (game_form_height > 1000 || game_form_height < 0)
                throw new ArgumentOutOfRangeException(nameof(game_form_height), game_form_height, "Высота экрана должна быть положительна и меньше 1000");

            //создание формы
            Form game_form = new Form();
            //Screen.PrimaryScreen.WorkingArea.Height     для области по высоте экрана 
            game_form.Width = game_form_width;
            game_form.Height = game_form_height;

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
