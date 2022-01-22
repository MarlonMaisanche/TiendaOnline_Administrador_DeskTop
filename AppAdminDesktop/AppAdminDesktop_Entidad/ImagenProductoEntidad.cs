using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class ImagenProductoEntidad
    {
        public int ID_IMAGEN { get; set; }
        public int ID_PROD_PER { get; set; }
        public string IMAGEN { get; set; }
        public ImagenProductoEntidad()
        {

        }
        public ImagenProductoEntidad(String Imagen)
        {
            this.IMAGEN = Imagen;
        }
    }
}