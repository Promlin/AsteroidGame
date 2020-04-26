using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class Player
    {

        private string _Name;//поле класса

        public string GetName()
        {
            return _Name;
        }

        public void SetName(string Name)
        {
            _Name = Name;
        }

        public string Name//свойство
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public string Surname { get; set; } = "Глупенький";//тоже свойство. более краткая версия реализации


        public Player(string Name)//Конструктор (без параметров/с параметрами)
        {
            this._Name = Name;
        }


    }
}
