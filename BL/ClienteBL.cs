﻿using DA;
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
        private readonly UsuarioBL _usuarioBL;

        public ClienteBL(VentaRopaContext context)
        {
            clienteDA = new ClienteDA(context);
            _usuarioBL = new UsuarioBL(context);

        }
        //public int Agregar(Cliente cliente) //Antes de crear un cliente hay que crear un usuario
        //{
        //    try
        //    {
        //      return clienteDA.Agregar(cliente);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        public int CrearCliente(Cliente cliente, string contraseña)
        {
            try
            {
                // Validar el usuario
                var usuario = _usuarioBL.ObtenerUsuario(cliente.NombreUsuario, contraseña);

                if (usuario == null)
                {
                    throw new Exception("Usuario o contraseña incorrectos.");
                }

                // Asignar el usuario al cliente
                cliente.NombreUsuarioNavigation = usuario;

                // Crear el cliente
                return clienteDA.Agregar(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al crear el cliente: " + ex.Message);
            }
        }


        public int Actualizar(int id, Cliente cliente)
        {
            try
            {
                // Verificar que el cliente exista
                var clienteExistente = clienteDA.ObtenerPorId(id);
                if (clienteExistente == null)
                {
                    throw new Exception("Cliente no encontrado.");
                }

                // Verificar que el cliente actualizando es el mismo que está logueado
                if (clienteExistente.ClienteId != cliente.ClienteId)
                {
                    throw new Exception("No tiene permisos para actualizar este cliente.");
                }

                // Validar y actualizar el usuario asociado
                var usuarioExistente = _usuarioBL.ObtenerUsuario(cliente.NombreUsuario, clienteExistente.NombreUsuarioNavigation.Contraseña);
                if (usuarioExistente == null)
                {
                    throw new Exception("Usuario no encontrado o no coincide con la contraseña actual.");
                }

                // Actualizar propiedades del cliente que se permiten cambiar
                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Apellido = cliente.Apellido;
                clienteExistente.Nacimiento = cliente.Nacimiento;
                clienteExistente.Pais = cliente.Pais;

                // Actualizar dirección (llamando al método existente)
                clienteDA.EditarDireccion(cliente.Direccion, cliente.ClienteId);

                // Guardar cambios en el cliente
                clienteDA.Actualizar(clienteExistente);

                return clienteExistente.ClienteId;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar el cliente: " + ex.Message);
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
