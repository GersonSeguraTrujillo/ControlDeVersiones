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
 public   class CD_Reporte6
    {
        public List<Reporte6> Listar()
        {
            List<Reporte6> lista = new List<Reporte6>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Reporte6", oconexion);


                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte6()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Paciente = dr["Paciente"].ToString(),
                                cantidad = Convert.ToInt32(dr["cantidad"]),



                                Examanes = dr["Examanes"].ToString(),




                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte6>();
            }

            return lista;
        }
    }
}
