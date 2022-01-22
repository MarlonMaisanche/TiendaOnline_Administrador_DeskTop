using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class CarritoEntidad
    {
        public int ID_CARRITO { get; set; }
        public String NOM_PRO { get; set; }
        public String SUB_TITULO { get; set; }
        public int STOCK { get; set; }
        public int ID_USUARIO { get; set; }
        public int CANTIDAD { get; set; }
        public int TALLA { get; set; }
        public int COLOR { get; set; }
        public double PRECIO { get; set; }
        public int ID_PRODUCTO { get; set; }
        public System.DateTime FECHA_CRE { get; set; }
        public ImagenProductoEntidad IMAGEN { get; set; }
        public TallaProductoEntidad NOMBRE_TALLA { get; set; }
        public ColorProductoEntidad NOMBRE_COLOR { get; set; }
      

    }
}