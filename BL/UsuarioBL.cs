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
    public class UsuarioBL
    {
        private UsuarioDA usuarioDA;

        public UsuarioBL(VentaRopaContext context)
        {
            usuarioDA = new UsuarioDA(context);
        }

        public String Agregar(Usuario usuario)
        {
            try
            {
                return usuarioDA.Agregar(usuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario ObtenerUsuario(string nombreUsuario, string contraseña)
        {
            try
            {
                return usuarioDA.ObtenerUsuario(nombreUsuario, contraseña);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
