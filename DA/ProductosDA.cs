using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class ProductosDA
    {
        private readonly VentaRopaContext _dbContext;

        public ProductosDA(VentaRopaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Producto> ObtenerTodos()
        {
            return _dbContext.Productos.ToList();
        }

        public Producto ObtenerPorId(int id)
        {
            return _dbContext.Productos.FirstOrDefault(p => p.ProductoId == id);
        }

        public void Agregar(Producto producto)
        {
            _dbContext.Productos.Add(producto);
            _dbContext.SaveChanges();
        }

        public void Actualizar(Producto producto)
        {
            _dbContext.Productos.Update(producto);
            _dbContext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var producto = _dbContext.Productos.FirstOrDefault(p => p.ProductoId == id);
            if (producto != null)
            {
                _dbContext.Productos.Remove(producto);
                _dbContext.SaveChanges();
            }
        }

        public List<Producto> BuscarPorNombre(string codigoNombre)
        {
            return _dbContext.Productos.Where(p => p.Codigo.Contains(codigoNombre) ;
        }

        public List<Producto> BuscarPorCodigo(string codigo)
        {
            return _dbContext.Productos.Where(p =>  p.Nombre.Contains(codigo)).ToList();
        }


    }
}
