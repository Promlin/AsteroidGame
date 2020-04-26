using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>Объект, поддерживающий возможность операции логирования</summary>
    internal interface ILogger
    {
        /// <summary>Добавить сообщение в журнал</summary>
        /// <param name="Message">Сообщение, добавляемое в журнал</param>
        void Log(string Message);
        /// <summary>Добавить информационное сообщение</summary>
        /// <param name="Message">Сообщение, добавляемое в журнал</param>
        void LogInformation(string Message);

        /// <summary>Добавить сообщение с предупреждением</summary>
        /// <param name="Message">Сообщение, добавляемое в журнал</param>
        void LogWarning(string Message);

        /// <summary>Добавить сообщение об ошибке</summary>
        /// <param name="Message">Сообщение, добавляемое в журнал</param>
        void LogError(string Message);
    }
}
