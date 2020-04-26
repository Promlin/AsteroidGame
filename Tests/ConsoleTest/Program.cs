using ConsoleTest.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

            CombineLogger log = new CombineLogger();
            log.Add(new ConsoleLogger());
            log.Add(new TextFileLogger("new_log.log"));
            log.Add(new DebugOutputLogger());
            log.Add(new TraceLogger());

            log.LogInformation("Info message");
            log.LogWarning("Warning message");
            log.LogError("Error message");



            ComputeLongValue(50, log);
            Console.WriteLine("Finish");

            Console.ReadLine();

            log.Flush();//метод для записи в файл из буфера 
        }

        private static double ComputeLongValue(int Count, Logger log)
        {
            int result = 0;
            for (int i = 0; i < Count; i++)
            {
                result++;
                log.LogInformation($"Вычисление итерации {i}");
                System.Threading.Thread.Sleep(100);
            }
            return result;
        }
    }


}
