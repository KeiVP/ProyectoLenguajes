using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using Models;

namespace BL
{
    public class ProductosBL
    {
        private ProductosDA productosDA;

        public ProductosBL(VentaRopaContext context)
        {
            productosDA = new ProductosDA(context);
        }

        public List<Producto> ObtenerTodos(string orderBy, string orderType)
        {
            try
            {
                string orderByQuery = "Id";
                if (orderBy != null) //Si no se especificó el ordenamiento, o sea si viene null, utilizamos el por defecto (OrderByQuery)
                {
                    orderByQuery = orderBy;
                }
                string orderTypeQuery = "asc";
                if (orderType != null)
                {
                    orderTypeQuery = orderType;
                }
                return productosDA.ObtenerTodos(orderByQuery + " " + orderTypeQuery);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }


        public Producto obtenerPorId(int id)
        {
            try
            {
                return productosDA.ObtenerPorId(id);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public void Agregar(Producto producto)
        {
            try
            {
              productosDA.Agregar(producto);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public int Actualizar(int id, Producto producto)
        {

            try
            {
                
                return productosDA.Actualizar(id, producto);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                productosDA.Eliminar(id);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public List<Producto> BuscarPorNombre(string nombre) {
            try
            {
                return productosDA.BuscarPorNombre(nombre);
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public List<Producto> BuscarPorCodigo(string codigo) {
            return productosDA.BuscarPorCodigo(codigo);
        } 


    }
}
