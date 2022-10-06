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
 public  class CD_Reporte3
    {

        public List<Reporte3> Listar(string  fechaDeInicio , string fechaDeFin)
        {
            List<Reporte3> lista = new List<Reporte3>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Reporte3", oconexion);
                    cmd.Parameters.AddWithValue("fechaDeInicio", fechaDeInicio);
                    cmd.Parameters.AddWithValue("fechaDeFin", fechaDeFin);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte3()
                            {
                                Fecha  = dr["Fecha"].ToString(),
                                Paciente = dr["Paciente"].ToString(),
                                Total= Convert.ToDecimal(dr["Total"]),
                                Descripcion = dr["Descripcion"].ToString(),


                            

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte3>();
            }

            return lista;
        }

    }
}
