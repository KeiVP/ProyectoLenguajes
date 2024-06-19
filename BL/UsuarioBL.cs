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

        public Usuario ObtenerPorNombreUsuario(string id)
        {
            try
            {
                return usuarioDA.ObtenerPorNombreUsuario(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
