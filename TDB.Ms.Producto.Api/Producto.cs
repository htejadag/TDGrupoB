using System;

namespace TDB.Ms.Producto.Api
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}
