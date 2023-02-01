using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDB.Gateway.Aplicacion.Productos.Request
{
    public class RegistrarPedidoRequest
    {
        public int idCliente { get; set; }
        public int idProducto { get; set; }
    }
}
