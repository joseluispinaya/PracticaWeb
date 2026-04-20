using CapaEntidad;
using CapaEntidad.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCategoria
    {
        #region "PATRON SINGLETON"
        private static DCategoria conexion = null;

        private DCategoria() { }

        public static DCategoria GetInstance()
        {
            if (conexion == null)
            {
                conexion = new DCategoria();
            }
            return conexion;
        }
        #endregion

        public Respuesta<List<ECategoria>> ListaCategorias()
        {
            try
            {
                List<ECategoria> rptLista = new List<ECategoria>();
                using (SqlConnection con = ConexionBD.GetInstance().ConexionDB())
                {
                    using (SqlCommand comando = new SqlCommand("usp_ListaCategorias", con))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rptLista.Add(new ECategoria
                                {
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    NombreCategoria = dr["NOmbreCatego"].ToString()
                                });
                            }
                        }
                    }
                }
                return new Respuesta<List<ECategoria>>()
                {
                    Estado = true,
                    Data = rptLista,
                    Mensaje = "Lista obtenida correctamente"
                };
            }
            catch (Exception)
            {
                return new Respuesta<List<ECategoria>>()
                {
                    Estado = false,
                    Data = null,
                    Mensaje = $"Error al obtener la lista:"
                };
            }
        }
    }
}
