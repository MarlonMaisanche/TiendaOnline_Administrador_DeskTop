using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class ListaDeseoEntidad
    {
        public int ID_DESEO { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_PRODUCTO { get; set; }
        public System.DateTime FECHA_CREA { get; set; }

    }
}