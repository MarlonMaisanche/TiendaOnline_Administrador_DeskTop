using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class ResenaEntidad
    {
        public int ID_RESE { get; set; }
        public int ID_PROD_PER { get; set; }
        public int ID_USU_ESCR { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public string TITULO { get; set; }
        public double VALORACION { get; set; }
        public string COMENTARIO { get; set; }
        public List<ImagenResenaEntidad> IMAGENES { get; set; }
        public Nullable<int> ESTADO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }

    }
}