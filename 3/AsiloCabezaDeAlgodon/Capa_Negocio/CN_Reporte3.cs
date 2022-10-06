using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
namespace Capa_Negocio
{
   public class CN_Reporte3
    {
        private CD_Reporte3 objCapaDato = new CD_Reporte3();
        public List<Reporte3> ListarReporte3(string fechaDeInicio, string fechaDeFin)
        {
            return objCapaDato.Listar(fechaDeInicio,fechaDeFin);


        }
    }
}
