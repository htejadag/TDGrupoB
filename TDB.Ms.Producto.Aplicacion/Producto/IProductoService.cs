using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Aplicacion.Producto
{
    public interface IProductoService
    {
        List<dominio.Producto> ListarProductos();
        dominio.Producto BuscarPorId(int idProducto);

        bool Registrar(dominio.Producto producto);
        bool Modificar(dominio.Producto producto);
        void Eliminar(int idProducto);

        void ActualizarStock(int idProducto, int cantidad);
    }
}
