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
   public class CD_PagoMensualidad
    {
        public List<PagoMensualidad> Listar()
        {
            List<PagoMensualidad> lista = new List<PagoMensualidad>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select pg.IdPago, p.NoPaciente,p.Nombre[nomPaciente],p.Apellido,");
                    sb.AppendLine("m.IdMes,m.Nombre [nomMes],pg.PrecioMensualidad, pg.FechaPago");
                    sb.AppendLine("from PagoMensualidad pg ");
                    sb.AppendLine("inner join Paciente p on p.NoPaciente = pg.NoPaciente");
                    sb.AppendLine("inner join Mes m on m.IdMes = pg.IdMes");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new PagoMensualidad()
                            {
                                IdPago = Convert.ToInt32(dr["IdPago"]),
                              
                               

                                oPaciente = new Paciente() { NoPaciente = Convert.ToInt32(dr["NoPaciente"]), Nombre = dr["nomPaciente"].ToString(), Apellido = dr["Apellido"].ToString() },
                                PrecioMensualidad = Convert.ToDecimal(dr["PrecioMensualidad"]),
                                oMes = new Mes() { IdMes = Convert.ToInt32(dr["IdMes"]), Nombre = dr["nomMes"].ToString() },
                                FechaPago = dr["FechaPago"].ToString(),

                            }
                            );
                        }
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                lista = new List<PagoMensualidad>();
            }

            return lista;
        }


        public string Registrar(PagoMensualidad obj, out string Mensaje)
        {
            string idautogenerado = null;

            Mensaje = string.Empty;
            try
            {


                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Registrar_Pago_Mesaulidad", oconexion);


                    cmd.Parameters.AddWithValue("NoPaciente", obj.oPaciente.NoPaciente);
                    cmd.Parameters.AddWithValue("PrecioMensualidad", obj.PrecioMensualidad);
                    cmd.Parameters.AddWithValue("IdMes", obj.oMes.IdMes);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();
            
                    idautogenerado = cmd.Parameters["Resultado"].Value.ToString();
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = null;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }
        public bool Editar(PagoMensualidad obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Editar_pago", oconexion);
                    cmd.Parameters.AddWithValue("IdPago", obj.IdPago);
                    cmd.Parameters.AddWithValue("NoPaciente", obj.oPaciente.NoPaciente);
                    cmd.Parameters.AddWithValue("PrecioMensualidad", obj.PrecioMensualidad);
                    cmd.Parameters.AddWithValue("IdMes", obj.oMes.IdMes);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value.ToString());
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Eliminar_Pago_Mensualidad", oconexion);
                    cmd.Parameters.AddWithValue("IdPago", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }





    }
}
