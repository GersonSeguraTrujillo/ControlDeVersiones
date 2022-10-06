using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
   public  class CN_Reporte6
    {
        private CD_Reporte6 objCapaDato = new CD_Reporte6();
        public List<Reporte6> ListarReporte6()
        {
            return objCapaDato.Listar();


        }

    }
}
