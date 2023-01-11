using System;
using System.ComponentModel.DataAnnotations;

namespace TDB.Ms.Producto.Api
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
