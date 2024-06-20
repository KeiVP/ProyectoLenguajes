using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class UsuarioDA
    {

        private VentaRopaContext _dbContext;

        public UsuarioDA(VentaRopaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public String Agregar(Usuario usuario) {
            try {
               _dbContext.Usuarios.Add(usuario);
                _dbContext.SaveChanges();
                return usuario.NombreUsuario;
            
            }catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        public bool UsuarioExistente (string usuarioNombre, string usuarioContraseña)
        {
            try
            {
                var usuario = _dbContext.Usuarios.FirstOrDefault(u =>
            u.NombreUsuario == usuarioNombre && u.Contraseña == usuarioContraseña);
                return true;

            }catch (Exception ex)
            {
                return false;
            }
            
            
        }

        public Usuario ObtenerPorNombreUsuario(string id)
        {
            try
            {
                return _dbContext.Usuarios.FirstOrDefault(c => c.NombreUsuario == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
