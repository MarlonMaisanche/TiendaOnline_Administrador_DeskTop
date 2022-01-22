using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class DetalleColeccionEntidad
    {
        public int ID_DETA_COLE { get; set; }
        public Nullable<int> ID_COLECCION { get; set; }
        public Nullable<int> ID_PRODUCTO { get; set; }

    }
}