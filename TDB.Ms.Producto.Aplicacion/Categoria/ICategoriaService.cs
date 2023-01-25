using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Aplicacion.Categoria
{
    public interface ICategoriaService
    {
        List<dominio.Categoria> ListarCategorias();

        dominio.Categoria Categoria(int idCategoria);

        bool RegistrarCategoria(dominio.Categoria categoria);

        //bool ModificarCategoria(dominio.Categoria categoria);

        void Eliminar(int idCategoria);
    }
}
