using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class ColorProductoEntidad
    {
        public int ID_COL_PRO { get; set; }
        public int ID_PRO_PER { get; set; }
        public int ID_COLOR { get; set; }
        public string IMAGEN { get; set; }
        public string NOM_COLOR { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
    }
}