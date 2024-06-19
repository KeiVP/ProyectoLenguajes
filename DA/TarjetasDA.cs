using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class TarjetasDA
    {

        private readonly VentaRopaContext _dbContext;

        public TarjetasDA(VentaRopaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Agregar(Tarjetum tarjeta) 
        {
            try
            {
                _dbContext.Tarjeta.Add(tarjeta);
                _dbContext.SaveChanges();
                return tarjeta.TarjetaId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TokenPago ObtenerTokenPorId(int id)
        {
            try
            {
                return _dbContext.TokenPagos.FirstOrDefault(c => c.TokenId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarToken(TokenPago token) {
            try
            {
                _dbContext.TokenPagos.Add(token);
                _dbContext.SaveChanges();
                return token.TokenId;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public int EliminarToken(TokenPago token)
        {
            try
            {
                _dbContext.TokenPagos.Remove(token);
                return token.TokenId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int EditarToken(TokenPago token, int id)
        {
            try
            {
                TokenPago tokenExistente = ObtenerTokenPorId(id);
                tokenExistente.Descripcion = token.Descripcion;
                _dbContext.TokenPagos.Update(token);
                _dbContext.SaveChanges();
                
                return token.TokenId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
