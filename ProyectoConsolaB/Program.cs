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
            string valorPrueba;


            valorPrueba = null;
            Log.Information("valorPrueba : "+valorPrueba);
            int valorDevuelto1 = objConversion.Convertir_a_Entero(valorPrueba);

            valorPrueba = "aaa";
            Log.Information("valorPrueba : " + valorPrueba);
            int valorDevuelto2 = objConversion.Convertir_a_Entero(valorPrueba);

            valorPrueba = "40000";
            Log.Information("valorPrueba : " + valorPrueba);
            int valorDevuelto3 = objConversion.Convertir_a_Entero(valorPrueba);

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
