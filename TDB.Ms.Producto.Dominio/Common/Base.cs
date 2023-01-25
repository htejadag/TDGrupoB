using System.Reflection.Metadata;

namespace TDB.Ms.Producto.Dominio
{
    public class Base : Document
    {
        public bool esEliminado { get; set; } = false;

        public bool esActivo { get; set; } = true;

        public string usuarioCreacion { get; set; }

        public DateTime fechaCreacion { get; set; } = DateTime.Now;

        public string usuarioModificacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        //public string token { get; set; }

        //public bool esBloqueado { get; set; }
    }
}
