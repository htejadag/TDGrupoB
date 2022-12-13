using Microsoft.Extensions.Logging;
using Serilog;
using System;
using Serilog.Sinks.SystemConsole.Themes;

namespace ProyectoConsolaB
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creación del log
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt")
                .CreateLogger();

            //Console.WriteLine("Hello World!");

            PruebaLog objPruebaLog = new PruebaLog();
            //objPruebaLog.Convertir_Int_String();

            // Implementar Log del request
            objPruebaLog.Convertir_String_Int();
            // Implementar Log del response            
        }

    }
}
