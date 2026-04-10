using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EProducto
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioCom { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
    }
}
