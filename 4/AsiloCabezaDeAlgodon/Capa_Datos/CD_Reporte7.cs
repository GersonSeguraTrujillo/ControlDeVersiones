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
  public  class CD_Reporte7
    {
        public List<Reporte7> Listar()
        {
            List<Reporte7> lista = new List<Reporte7>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Reporte7", oconexion);


                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte7()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Paciente = dr["Paciente"].ToString(),
                                cantidad = Convert.ToInt32(dr["cantidad"]),



                                Medicamentos = dr["Medicamentos"].ToString(),




                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte7>();
            }

            return lista;
        }
    }
}
