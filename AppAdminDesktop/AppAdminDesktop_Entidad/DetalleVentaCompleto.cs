using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class DetalleVentaCompleto
    {
        public int ID_PRO { get; set; }
        public String NOM_PRO { get; set; }
        public String SUB_TITULO { get; set; }
        public int CANTIDAD { get; set; }
        public double PRECIO { get; set; }
        public String IMAGEN { get; set; }
        public String NOMBRE_TALLA { get; set; }
        public String NOMBRE_COLOR { get; set; }
    }
}