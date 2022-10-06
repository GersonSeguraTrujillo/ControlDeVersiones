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
   public  class CD_Reporte2
    {
        public List<Reporte2> Listar()
        {
            List<Reporte2> lista = new List<Reporte2>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Reporte2", oconexion);
                

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte2()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                
                                Paciente = dr["Paciente"].ToString(),
                                Cintomas = dr["Cintomas"].ToString(),
                             
                                Medicamentos = dr["Medicamentos"].ToString(),
                                Examanes = dr["Examanes"].ToString(),




                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte2>();
            }

            return lista;
        }


    }
}
