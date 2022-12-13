using Microsoft.Extensions.Logging;
using System;

namespace ProyectoConsolaB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            PruebaLog objPruebaLog = new PruebaLog();
            //objPruebaLog.Convertir_Int_String();

            // Implementar Log del request
            objPruebaLog.Convertir_String_Int();
            // Implementar Log del response


            //using var loggerFactory = LoggerFactory.Create(builder =>
            //{
            //    builder
            //        .AddFilter("Microsoft", LogLevel.Warning)
            //        .AddFilter("System", LogLevel.Warning)
            //        .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
            //        .AddConsole();
            //});

            //ILogger logger = loggerFactory.CreateLogger<Program>();
            //logger.LogInformation("Example log message");

        }

    }
}
