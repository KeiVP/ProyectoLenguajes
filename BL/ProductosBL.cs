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
        private ProductosDA productDA;

        public ProductosBL(VentaRopaContext context)
        {
            productDA = new ProductosDA(context);
        }

        public async Task<List<Producto>> getAllProducts(string orderBy, string orderType)
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
                return await productDA.getAllProducts(orderByQuery + " " + orderTypeQuery);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }


        public async Task<Product> getProductById(string id)
        {
            try
            {
                return await productDA.getProductById(id);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<int> createProduct(Product product)
        {
            try
            {
                return await productDA.createProduct(product);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<int> editProduct(string id, Product product)
        {

            try
            {
                return await productDA.editProduct(id, product);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<int> deleteProductById(string id)
        {
            try
            {
                return await productDA.deleteProductById(id);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }


    }
}
