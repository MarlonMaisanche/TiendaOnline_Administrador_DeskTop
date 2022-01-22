using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class TallaProductoEntidad
    {
        public int ID_TALL_PRO { get; set; }
        public int ID_PRO_PER { get; set; }
        public int ID_TALLA_PER { get; set; }
        public Nullable<double> PRECIO_TALL { get; set; }
        public Nullable<double> PRECIO_TALL_PROM { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public String NOM_TALLA { get; set; }
    }
}