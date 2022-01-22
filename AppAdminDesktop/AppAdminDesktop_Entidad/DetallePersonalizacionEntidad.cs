using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class DetallePersonalizacionEntidad
    {
        public int ID_DETALL_PER { get; set; }
        public int ID_DETALLE_PER { get; set; }
        public string IMAGEN { get; set; }
        public string DETALLES { get; set; }
    }
}