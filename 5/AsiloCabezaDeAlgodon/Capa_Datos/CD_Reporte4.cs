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
   public  class CD_Reporte4
    {
        public List<Reporte4> Listar()
        {
            List<Reporte4> lista = new List<Reporte4>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Reporte4", oconexion);


                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte4()
                            {
                                IdPago = Convert.ToInt32(dr["IdPago"]),

                                Paciente = dr["Paciente"].ToString(),
                                PrecioMensualidad = Convert.ToDecimal(dr["PrecioMensualidad"]),

                                Fecha = dr["Fecha"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),




                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte4>();
            }

            return lista;
        }
    }
}
