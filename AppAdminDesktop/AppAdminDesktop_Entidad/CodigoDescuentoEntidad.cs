using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class CodigoDescuentoEntidad
    {
        public int ID_DESCUENTO { get; set; }
        public string COD_DES { get; set; }
        public int DESCUENTO { get; set; }
        public int CANT_PER_USO { get; set; }
        public Nullable<int> ID_SUBCATEGORIA { get; set; }

    }
}