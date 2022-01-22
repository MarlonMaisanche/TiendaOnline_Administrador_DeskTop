using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class SubCategoriaEntidad
    {
        public int ID_SUBCAT { get; set; }
        public int ID_CATEGO_PER { get; set; }
        public string NOM_SUBCATEGO { get; set; }
        public string DESC_SUBCATEGO { get; set; }
        public string IMAGEN { get; set; }
    }
}