using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class OrdenesDA
    {

        private VentaRopaContext _dbContext;

        public OrdenesDA(VentaRopaContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
