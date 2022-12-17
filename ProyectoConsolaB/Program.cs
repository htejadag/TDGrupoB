using Serilog;
using System;

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

            Conversion objConversion = new Conversion();
            string valor;


            valor = null;
            Log.Information("valor : " + valor);
            int valorDevuelto1 = objConversion.Convertir_a_Entero(valor);

            valor = "aaa";
            Log.Information("valor : " + valor);
            int valorDevuelto2 = objConversion.Convertir_a_Entero(valor);

            valor = "40000";
            Log.Information("valor : " + valor);
            int valorDevuelto3 = objConversion.Convertir_a_Entero(valor);

            //PruebaLog objPruebaLog = new PruebaLog();

            //// Implementar Log del request
            //objPruebaLog.Convertir_String_Int();
            //// Implementar Log del response
            Saludar();
        }

        public static void Saludar() {
            Console.WriteLine("Hola");
        }
    }
}
