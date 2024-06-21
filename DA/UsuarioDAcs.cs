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

      
        public Usuario ObtenerUsuario(string nombreUsuario, string contrasena)
        {
            try
            {
                return _dbContext.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contrasena);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
