using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Models
{
    internal class Student: INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public StudentsGroup Group { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
