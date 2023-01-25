using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = TDB.Ms.Producto.Dominio.Entidades;

namespace TDB.Ms.Producto.Aplicacion.Categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICollectionContext<dominio.Categoria> _categoria;
        private readonly IBaseRepository<dominio.Categoria> _categoriaR;

        public CategoriaService(ICollectionContext<dominio.Categoria> categoria, 
                                IBaseRepository<dominio.Categoria> categoriaR)
        {
            _categoria = categoria;
            _categoriaR = categoriaR;
        }

        public dominio.Categoria Categoria(int idCategoria)
        {
            Expression<Func<dominio.Categoria, bool>> filter = s => s.esEliminado == false && s.idCategoria == idCategoria;
            var item = (_categoria.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idCategoria)
        {
            Expression<Func<dominio.Categoria, bool>> filter = s => s.esEliminado == false && s.idCategoria == idCategoria;
            var item = (_categoria.Context().FindOneAndDelete(filter, null));
        }

        public List<dominio.Categoria> ListarCategorias()
        {
            Expression<Func<dominio.Categoria, bool>> filter = s => s.esEliminado == false;
            var items = (_categoria.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool ModificarCategoria(dominio.Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarCategoria(dominio.Categoria categoria)
        {
            categoria.esEliminado = false;
            categoria.fechaCreacion = DateTime.Now;
            categoria.esActivo = true;

            var p = _categoriaR.InsertOne(categoria);

            return true;
        }
    }
}
