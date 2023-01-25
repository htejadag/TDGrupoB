using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDB.Ms.Producto.Infraestructura.Common;

namespace TDB.Ms.Producto.Dominio.Entidades
{
    public class Categoria : Base
    {
        public string nombre { get; set; }
    }
}
