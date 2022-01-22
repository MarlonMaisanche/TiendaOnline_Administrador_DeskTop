using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class DetalleConjuntoEntidad
    {
        public int ID_DET_CONJ { get; set; }
        public Nullable<int> ID_CONJ_PER { get; set; }
        public Nullable<int> ID_PRODUCTO { get; set; }
    }
}