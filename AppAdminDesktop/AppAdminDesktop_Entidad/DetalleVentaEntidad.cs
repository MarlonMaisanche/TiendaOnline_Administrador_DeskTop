using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class DetalleVentaEntidad
    {
        public int ID_DETALLE_VENTA { get; set; }
        public int ID_VENTA_PER { get; set; }
        public int ID_PRODUCTO_PER { get; set; }
        public int ID_COLOR_PRO { get; set; }
        public int ID_TALLA_PRO { get; set; }
        public int CANTIDAD { get; set; }
        public int ESTADO { get; set; }
        public Nullable<int> PERSONALIZABLE { get; set ; }
        public ImagenProductoEntidad Imagen { get; set ; }
    }
}