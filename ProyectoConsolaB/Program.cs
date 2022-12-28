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

            //Conversion objConversion = new Conversion();
            //string valor;


            //valor = null;
            //Log.Information("valor : " + valor);
            //int valorDevuelto1 = objConversion.Convertir_a_Entero(valor);

            //valor = "aaa";
            //Log.Information("valor : " + valor);
            //int valorDevuelto2 = objConversion.Convertir_a_Entero(valor);

            //valor = "40000";
            //Log.Information("valor : " + valor);
            //int valorDevuelto3 = objConversion.Convertir_a_Entero(valor);

            //PruebaLog objPruebaLog = new PruebaLog();

            //// Implementar Log del request
            //objPruebaLog.Convertir_String_Int();
            //// Implementar Log del response
            //Saludar();

            Pregunta5();
        }

        public static void Saludar()
        {
            Console.WriteLine("Hola");
        }

        public static void Pregunta1()
        {
            try
            {
                Int16 a;
                String b = "40000";
                a = Int16.Parse(b);
                Console.WriteLine("El número es " + a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Pregunta2()
        {
            try
            {
                int a;
                String b = null;
                a = int.Parse(b);
                Console.WriteLine("El número es " + a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void Pregunta3()
        {
            try
            {
                int a;
                String b = "hola";
                a = int.Parse(b);
                Console.WriteLine("El número es " + a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void Pregunta4()
        {
            int a = 5, b = 0, c;
            c = a / b;
            Console.WriteLine("El resultado es " + c);
        }

        public static void Pregunta5()
        {
            string a = "5", b = "0", c = a + b;
            Console.WriteLine("El resultado es " + c);
        }
    }
}
