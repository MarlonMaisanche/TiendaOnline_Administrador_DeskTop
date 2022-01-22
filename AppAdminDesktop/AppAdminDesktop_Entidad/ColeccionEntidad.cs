using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class ColeccionEntidad
    {
        public int ID_COLECCION { get; set; }
        public string NOM_COLECCION { get; set; }
        public string DES_COLECCION { get; set; }
        public Nullable<System.DateTime> FECHA_LANZAMIENTO { get; set; }
        public List<ProductoEntidad> PRODUCTOS { get; set; }

    }
}