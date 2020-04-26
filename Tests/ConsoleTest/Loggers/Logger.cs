using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Loggers
{
    internal abstract class Logger
    {
        public static Logger CreateFileLogger(string FileName) //фабричный метод 
        {
            return new TextFileLogger(FileName);
        }

        public abstract void Log(string Message);
        public void LogInformation(string Message)
        {
            Log($"{DateTime.Now:s}[info]:{Message}");
        }
        public void LogWarning(string Message)
        {
            Log($"{DateTime.Now:s}[warn]:{Message}");
        }
        public void LogError(string Message)
        {
            Log($"{DateTime.Now:s}[error]:{Message}");
        }

        public virtual void Flush() { }
    }
}