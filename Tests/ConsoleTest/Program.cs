﻿using ConsoleTest.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logger log = new TextFileLogger("text.log");
            //Logger log = new ConsoleLogger();
            Logger log = new DebugOutputLogger();

            log.LogInformation("Info message");
            log.LogWarning("Warning message");
            log.LogError("Error message");

            log.Flush();//метод для записи в файл из буфера 

            Console.ReadLine();
        }
    }

    
}
