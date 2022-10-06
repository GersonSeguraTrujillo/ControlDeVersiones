using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;


namespace Capa_Negocio
{
   public class CN_Reporte5
    {
        private CD_Reporte5 objCapaDato = new CD_Reporte5();
        public List<Reporte5> ListarReporte5()
        {
            return objCapaDato.Listar();


        }
    }
}
