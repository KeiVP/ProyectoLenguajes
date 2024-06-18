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
        private  VentaRopaContext _dbContext;

        public ProductosDA(VentaRopaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Producto> ObtenerTodos()
        {
            try
            {
                return _dbContext.Productos.ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Producto ObtenerPorId(int id)
        {
            try
            {
                return _dbContext.Productos.FirstOrDefault(p => p.ProductoId == id);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Agregar(Producto producto)
        {
            try
            {
                _dbContext.Productos.Add(producto);
                _dbContext.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Actualizar(int id, Producto producto)
        {
            try
            {
                Producto productoExistente = ObtenerPorId(id);
                productoExistente = producto.Nombre;
                productoExistente = producto.CategoriaId;
                productoExistente = producto.Descripcion;
                productoExistente = producto.Codigo;
                productoExistente = producto.Talla;
                productoExistente = producto.Precio;
                productoExistente = producto.Imagen;
                productoExistente = producto.Stock;
                _dbContext.Productos.Update(producto);
                _dbContext.SaveChanges();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                var producto = _dbContext.Productos.FirstOrDefault(p => p.ProductoId == id);
                if (producto != null)
                {
                    _dbContext.Productos.Remove(producto);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        
        }

        public List<Producto> BuscarPorNombre(string Nombre)
        {
            try
            {
                return _dbContext.Productos.Where(p => p.Codigo.Contains(Nombre) ;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public List<Producto> BuscarPorCodigo(string codigo)
        {
            try
            {
                return _dbContext.Productos.Where(p => p.Nombre.Contains(codigo)).ToList();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


    }
}
