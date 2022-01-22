using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class DetalleRegaloEntidad
    {
        public int ID_DET_REGALO { get; set; }
        public Nullable<int> ID_VENTA_PER { get; set; }
        public string DESTINATARIO { get; set; }
        public Nullable<int> ID_TIPO_ENVOLTURA { get; set; }
        public string MENSAJE { get; set; }
        public string EXTRA { get; set; }
    }
}