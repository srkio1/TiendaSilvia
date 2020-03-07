using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaSilvia.Datos
{
    public class venta_rapida
    {
        public int id_venta_rapida { get; set; }
        public DateTime fecha { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public string detalle_cantidad { get; set; }
        public decimal monto { get; set; }
    }
}
