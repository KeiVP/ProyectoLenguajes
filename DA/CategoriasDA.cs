using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace DA
{
    internal class CategoriasDA
    {
        private readonly VentaRopaContext _dbContext;

        public CategoriasDA(VentaRopaContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public List<Categoria> ObtenerTodos(String orderBy)
        {
            try
            {
                return _dbContext.Categoria.ToList();
                   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Categoria ObtenerPorId(int id)
        {
            try
            {
                return _dbContext.Categoria.FirstOrDefault(c => c.CategoriaId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Agregar(Categoria categoria)
        {
            try
            {
                _dbContext.Categoria.Add(categoria);
                _dbContext.SaveChanges();
                return categoria.CategoriaId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Actualizar(int id, Categoria categoria)
        {
            try
            {
                Categoria categoriaExistente = ObtenerPorId(id);
                categoriaExistente.Descripcion = categoria.Descripcion;
                _dbContext.Categoria.Update(categoria);
                _dbContext.SaveChanges();
                return categoria.CategoriaId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                var categoria = _dbContext.Categoria.FirstOrDefault(c => c.CategoriaId == id);
                if (categoria != null)
                {
                    _dbContext.Categoria.Remove(categoria);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
