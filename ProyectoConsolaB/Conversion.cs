using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace ProyectoConsolaB
{
    public class Conversion
    {

        public int Convertir_a_Entero(string numero)
        {
            Int16 valor = 0;
            try
            {                
                valor = Int16.Parse(numero);                
            }
            catch (ArgumentNullException ex)
            {
                Log.Error("ArgumentNullException : " + ex.Message);
                //Console.WriteLine("ArgumentNullException: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Log.Error("FormatException : " + ex.Message);
                //Console.WriteLine("FormatException: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Log.Error("OverflowException : " + ex.Message);
                //Console.WriteLine("OverflowException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("Exception : " + ex.Message);
                //Console.WriteLine("Exception: " + ex.Message);
            }
            return valor;
        }


        public void LeerConsola() {

            Console.WriteLine("Ingrese un número");
            string numero = Console.ReadLine();
        }

    }
}
