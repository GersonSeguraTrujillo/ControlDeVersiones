using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
  public  class CN_Reporte4
    {
        private CD_Reporte4 objCapaDato = new CD_Reporte4();
        public List<Reporte4> ListarReporte4()
        {
            return objCapaDato.Listar();


        }

    }
}
