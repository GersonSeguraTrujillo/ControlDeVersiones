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
  public  class CD_GastosMedicos
    {
        public List<GastosMedicos> Listar(int IdCita)
        {
            List<GastosMedicos> lista = new List<GastosMedicos>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Mostrar_Gasto", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new GastosMedicos()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),

                                

                                oExamen = new Examen() {  IdDescripcionCita = Convert.ToInt32(dr["IdDescripcionCita"]),  nombre = dr["nombre"].ToString(), descripcion = dr["descripcion"].ToString() },


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<GastosMedicos>();
            }

            return lista;
        }

        public List<DetalleCita> DetalleCita(int IdCita)
        {
            List<DetalleCita> lista = new List<DetalleCita>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Detalle_Cita", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetalleCita()
                            {
                           


                                Descripcion = dr["Descripcion"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"])



                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<DetalleCita>();
            }

            return lista;
        }



        public List<GastosMedicos> ListarMedicamento(int IdCita)
        {
            List<GastosMedicos> lista = new List<GastosMedicos>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Mostrar_Medicamentos", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new GastosMedicos()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),



                                oExamen = new Examen() { IdDescripcionCita = Convert.ToInt32(dr["IdDescripcionCita"]), nombre = dr["nombre"].ToString(), descripcion = dr["descripcion"].ToString() },


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<GastosMedicos>();
            }

            return lista;
        }

        public int Registrar(GastosMedicos obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Registrar_Gastos_Medicos", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", obj.IdCita);
                    cmd.Parameters.AddWithValue("IdDescripcionCita", obj.oExamen.IdDescripcionCita);
                    cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);

                    
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    //idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    idautogenerado = Convert.ToInt32(cmd.Parameters["IdCita"].Value.ToString());
                   
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (IOException ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }


        public bool Eliminar(int id, int i,out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from Gastos_Medicos where IdCita=@id and IdDescripcionCita=@i", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@i", i);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }




        public TotalCita VerTotalcita(int IdCita)
        {
            TotalCita objeto = new TotalCita();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("SP_Calcular_Total", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new TotalCita()
                            {
                             
                                Total = Convert.ToDecimal(dr["Total"])
                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new TotalCita();
            }

            return objeto;
        }


        public InformacionCita VerInfoCita(int IdCita)
        {
            InformacionCita  objeto = new InformacionCita();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("SP_Cita", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new InformacionCita()
                            {
                                Paciente = dr["Paciente"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Dpi = Convert.ToInt32(dr["Dpi"]),
                                Especialista = dr["Especialista"].ToString()



                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new InformacionCita();
            }

            return objeto;
        }



    }
}
