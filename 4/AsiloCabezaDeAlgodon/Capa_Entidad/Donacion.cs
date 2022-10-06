using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Capa_Entidad
{
  public  class Donacion
    {
        public int IdDonacion { get; set; }
        public string Dondate { get; set; }
        public decimal Cantidad { get; set; }
        public Fundacion oFundacion { get; set; }

        public string FechaDonacion { get; set; }
    }
}
