using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StudentsManager.ViewModels.Base;

namespace StudentsManager.ViewModels.Base
{
    class MainWindowViewModels : ViewModels
    {
        private string _Title = "Редактор студентов";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
    }
}
