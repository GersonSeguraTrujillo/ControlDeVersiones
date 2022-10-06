using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
  public   class CN_Donacion
    {
        private CD_Donacion objCapaDato = new CD_Donacion();

        public List<Donacion> Listar()
        {

            return objCapaDato.Listar();
        }

        public string Registrar(Donacion obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Dondate) || string.IsNullOrWhiteSpace(obj.Dondate))
            {
                Mensaje = "Tiene que escribir quien esta haciendo la donacion";
            }
         
            else if (obj.Cantidad == 0)
            {
                Mensaje = "Resive el campo cantidad:" +
                   " Lo a dejado vacio, " +
                   " digito letras o" +
                   " digito una coma";
            }
            else if (obj.oFundacion.IdFundacion == 0)
            {
                Mensaje = "Debe Seleccionar la fundacion para hacer la donacion";
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



        public bool Editar(Donacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Dondate) || string.IsNullOrWhiteSpace(obj.Dondate))
            {
                Mensaje = "Tiene que escribir quien esta haciendo la donacion";
            }

            else if (obj.Cantidad == 0)
            {
                Mensaje = "Falta la cantidad que va donar";
            }
            else if (obj.oFundacion.IdFundacion == 0)
            {
                Mensaje = "Debe Seleccionar la fundacion para hacer la donacion";
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
