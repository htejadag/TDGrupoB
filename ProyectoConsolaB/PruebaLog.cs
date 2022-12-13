using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace ProyectoConsolaB
{
    public class PruebaLog
    {

        public void Convertir_Int_String()
        {
            int a = 1;
            string b;

            b = a.ToString();

            Console.WriteLine("El valor es : " + b);
        }

        public void Convertir_String_Int()
        {
            try
            {
                string a = "20000";
                Int16 b;

                b = Int16.Parse(a);

                Console.WriteLine("El valor es : " + b);

                
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                //_logger.Log(LogLevel.Error, e.Message);
                Log.Information("Se produjo un error");
            }
            finally
            {
            }
        }
    }
}
