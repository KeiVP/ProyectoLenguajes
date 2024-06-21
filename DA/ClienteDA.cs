using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class ClienteDA
    {

        private VentaRopaContext _dbContext;

        public ClienteDA(VentaRopaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Agregar(Cliente cliente) 
        {
            try
            {
                
                _dbContext.Clientes.Add(cliente);
                _dbContext.SaveChanges();
                return cliente.ClienteId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cliente ObtenerPorId(int id)
        {
            try
            {
                return _dbContext.Clientes.Include(c
                    => c.NombreUsuarioNavigation).FirstOrDefault(c // Incluir usuario asociado
                    => c.ClienteId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Actualizar(Cliente cliente)
        {
            try
            {
                if (cliente != null)
                {
                    _dbContext.Clientes.Update(cliente);
                    _dbContext.SaveChanges();
                    return cliente.ClienteId;
                }
                else
                {
                    throw new Exception("Cliente vacio.");

                }

             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //Si se implementa una nueva tabla llamada Direcciones, de aquí para abajo se elimina y se crea una nueva clase
        public int AgregarDirecciones(string direccion, int clienteID) { //Implica una nueva tabla direcciones
            try {
                Cliente cliente = ObtenerPorId(clienteID);
                cliente.Direccion = direccion;
                _dbContext.Update(cliente);
                _dbContext.SaveChanges();
                return cliente.ClienteId;

            } catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public int EditarDireccion(string direccion, int clienteID) {
            try {

                Cliente cliente = ObtenerPorId(clienteID);
                cliente.Direccion = direccion;
                _dbContext.Update(cliente);
                _dbContext.SaveChanges();
                return cliente.ClienteId;
            
            }catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int EliminarDireccion(int clienteID) {
            try
            {
                Cliente cliente = ObtenerPorId(clienteID);
                cliente.Direccion = null;
                _dbContext.Update(cliente);
                _dbContext.SaveChanges();
                return cliente.ClienteId;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
