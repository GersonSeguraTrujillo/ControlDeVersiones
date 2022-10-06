using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public   class PagoMensualidad
    {
        public int IdPago { get; set; }
        public Paciente oPaciente { get; set; }
        public decimal PrecioMensualidad { get; set; }
        public Mes oMes { get; set; }
        public string FechaPago { get; set; }


    }
}
