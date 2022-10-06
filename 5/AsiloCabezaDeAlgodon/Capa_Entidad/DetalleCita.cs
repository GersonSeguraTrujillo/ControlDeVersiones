using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
     
    public    class DetalleCita
    {

        public int IdCita { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio  { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    }
}
