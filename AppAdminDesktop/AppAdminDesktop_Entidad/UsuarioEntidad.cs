using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class UsuarioEntidad
    {
        public int ID_USUARIO { get; set; }
        public string CORREO { get; set; }
        public string PASS { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CEDULA { get; set; }
        public Nullable<int> ID_GENERO { get; set; }
        public string TELEFONO { get; set; }
        public Nullable<int> ID_DIR_PRI { get; set; }
        public Nullable<double> VAL_USU { get; set; }
        public System.DateTime FEC_CREA { get; set; }
        public int ESTADO { get; set; }
    }
}