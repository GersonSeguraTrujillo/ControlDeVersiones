using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
  public  class CN_Reporte7
    {
        private CD_Reporte7 objCapaDato = new CD_Reporte7();
        public List<Reporte7> ListarReporte7()
        {
            return objCapaDato.Listar();


        }
    }
}
