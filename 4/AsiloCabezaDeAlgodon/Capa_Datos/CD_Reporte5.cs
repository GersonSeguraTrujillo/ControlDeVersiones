using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Capa_Datos
{
  public  class CD_Reporte5
    {
        public List<Reporte5> Listar()
        {
            List<Reporte5> lista = new List<Reporte5>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Reporte5", oconexion);


                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte5()
                            {
                                Fecha = dr["Fecha"].ToString(),
                                Persona = dr["Persona"].ToString(),
                                Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                               

                                
                                Descripcion = dr["Descripcion"].ToString(),




                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte5>();
            }

            return lista;
        }

    }
}
