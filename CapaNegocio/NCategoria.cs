using CapaDatos;
using CapaEntidad;
using CapaEntidad.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCategoria
    {
        #region "PATRON SINGLETON"
        private static NCategoria conexion = null;

        private NCategoria() { }

        public static NCategoria GetInstance()
        {
            if (conexion == null)
            {
                conexion = new NCategoria();
            }
            return conexion;
        }
        #endregion

        public Respuesta<List<ECategoria>> ListaCategorias()
        {
            return DCategoria.GetInstance().ListaCategorias();
        }
    }
}
