using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class AfiliadoEntidad
    {
        public int ID_AFILIADO { get; set; }
        public int ID_USUARIO_PER { get; set; }
        public string COD_AFILIADO { get; set; }
        public System.DateTime FECHA_CREACION { get; set; }
        public Nullable<int> VENTAS_TOTALES { get; set; }
        public Nullable<double> VALOR_COBRAR { get; set; }
    }
}