using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class DatosBancariosAfiliadoEntidad
    {
        public int ID_DATOS_BANCARIOS { get; set; }
        public int ID_AFILIADO_PER { get; set; }
        public string NOMBRE_BANCO { get; set; }
        public string TIPO_DE_CUENTA { get; set; }
        public string NOMBRE_CUENTA { get; set; }
        public string NUM_CUENTA { get; set; }
    }
}