using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Aplicacion.Producto
{
    public interface IProductoService
    {
        List<dominio.Producto> ListarProductos();
        bool Registraproducto(dominio.Producto producto);
        dominio.Producto Producto(int idProducto);
        void Eliminar(int idProducto);
    }
}
