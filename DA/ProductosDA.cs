using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
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

        public List<Producto> ObtenerTodos(String orderBy)
        {
            try
            {
                return _dbContext.Productos.OrderBy(orderBy).ToList();
            }
            catch (Exception ex)
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

        public int Agregar(Producto producto)
        {
            try
            {
                _dbContext.Productos.Add(producto);
                _dbContext.SaveChanges();
                return producto.ProductoId;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Actualizar(int id, Producto producto)
        {
            try
            {
                Producto productoExistente = ObtenerPorId(id);
                productoExistente.Nombre = producto.Nombre;
                productoExistente.CategoriaId = producto.CategoriaId;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Codigo = producto.Codigo;
                productoExistente.Talla = producto.Talla;
                productoExistente.Precio = producto.Precio;
                productoExistente.Imagen = producto.Imagen;
                productoExistente.Stock = producto.Stock;
                _dbContext.Productos.Update(producto);
                _dbContext.SaveChanges();
                return producto.ProductoId;
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
                return _dbContext.Productos.Where(p => p.Codigo.Contains(Nombre)).ToList();
            }
            catch (Exception ex)
            {
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
