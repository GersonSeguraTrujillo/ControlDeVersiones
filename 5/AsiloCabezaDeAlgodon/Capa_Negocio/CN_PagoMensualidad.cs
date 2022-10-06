using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
  public   class CN_PagoMensualidad
    {
        private CD_PagoMensualidad objCapaDato = new CD_PagoMensualidad();

        public List<PagoMensualidad> Listar()
        {

            return objCapaDato.Listar();
        }

        public string Registrar(PagoMensualidad obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.oPaciente.NoPaciente == 0)
            {
                Mensaje = "Debe Seleccionar el paciente";
            }
            else if (obj.PrecioMensualidad == 0)
            {
                Mensaje = "Resive el campo Monto:" +
               " Lo a dejado vacio o" +
               " digito letras " ;
            }
            else if (obj.oMes.IdMes == 0)
            {
                Mensaje = "Debe seleccionar el mes de pago";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return null;
            }

        }


        public bool Editar(PagoMensualidad obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.oPaciente.NoPaciente == 0)
            {
                Mensaje = "Debe Seleccionar el paciente";
            }
            else if (obj.PrecioMensualidad == 0)
            {
                Mensaje = "Resive el campo monto:" +
               " Lo a dejado vacio o " +
               " digito letras " ;
            }
            else if (obj.oMes.IdMes == 0)
            {
                Mensaje = "Debe seleccionar el mes de pago";
            }



            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }



    }
}
