using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class DireccionEntidad
    {
        public int ID_DIREC { get; set; }
        public int ID_USU_PER { get; set; }
        public Nullable<int> ID_CIUDAD { get; set; }
        public string NOM_REC { get; set; }
        public string CEDULA { get; set; }
        public string TELEFONO { get; set; }
        public string CALLE_PRINPICAL { get; set; }
        public string CALLE_SECUNDARIA { get; set; }
        public string NUMERO_CASA { get; set; }
        public string REFERECNIA { get; set; }
        public string CODIGO_POS { get; set; }
        public System.DateTime FEC_CRE { get; set; }
        public int ESTADO { get; set; }
        public Nullable<double> LONGITUD { get; set; }
        public Nullable<double> LATITUD { get; set; }

    }
}