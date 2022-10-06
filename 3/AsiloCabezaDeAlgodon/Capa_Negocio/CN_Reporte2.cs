using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
namespace Capa_Negocio
{
      public  class CN_Reporte2
    {
        private CD_Reporte2 objCapaDato = new CD_Reporte2();
        public List<Reporte2> ListarReporte2()
        {
            return objCapaDato.Listar();


        }

    }
}
