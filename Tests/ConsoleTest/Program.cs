using ConsoleTest.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logger log = new TextFileLogger("text.log");
            //Logger log = new ConsoleLogger();
            //Logger log = new DebugOutputLogger();
            //Logger log = new TraceLogger();

            //Trace.Listeners.Add(new TextWriterTraceListener("logger.log"));
            //Trace.Listeners.Add(new XmlWriterTraceListener("logger.log.xml"));

            CombineLogger combine_log = new CombineLogger();
            combine_log.Add(new ConsoleLogger());
            combine_log.Add(new TextFileLogger("new_log.log"));
            combine_log.Add(new DebugOutputLogger());
            combine_log.Add(new TraceLogger());

            ILogger log = combine_log;

            combine_log.LogInformation("Info message");
            combine_log.LogWarning("Warning message");
            combine_log.LogError("Error message");

            Student student = new Student { Name = "Лёня" };

            ComputeLongValue(50, student);
            Console.WriteLine("Finish");

            //Console.ReadLine();

            using (var file_logger = new TextFileLogger("another.log"))
            {
                file_logger.LogInformation("Information");
            }

            combine_log.Flush();//метод для записи в файл из буфера 
        }

        private static double ComputeLongValue(int Count, ILogger Log)
        {
            int result = 0;
            for (int i = 0; i < Count; i++)
            {
                result++;
                Log.Log($"Вычисление итерации {i}");
                System.Threading.Thread.Sleep(100);
            }
            return result;
        }
    }


}
