using DA;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClienteBL
    {

        private ClienteDA clienteDA;

        public ClienteBL(VentaRopaContext context)
        {
            clienteDA = new ClienteDA(context);

        }
        public int Agregar(Cliente cliente) //Antes de crear un cliente hay que crear un usuario
        {
            try
            {
              return clienteDA.Agregar(cliente);
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
                return clienteDA.ObtenerPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Si se implementa una nueva tabla llamada Direcciones, de aquí para abajo se elimina y se crea una nueva clase
        public int AgregarDirecciones(string direccion, int clienteID)
        { //Implica una nueva tabla direcciones
            try
            {
                return clienteDA.AgregarDirecciones (direccion, clienteID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int EditarDireccion(string direccion, int clienteID)
        {
            try
            {

                return clienteDA.EditarDireccion (direccion, clienteID);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int EliminarDireccion(int clienteID)
        {
            try
            {
                return clienteDA.EliminarDireccion(clienteID);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
