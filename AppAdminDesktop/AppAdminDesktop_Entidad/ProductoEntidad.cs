using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class ProductoEntidad
    {
        public int ID_PRO { get; set; }
        public int ID_TIPO { get; set; }
        public string MARCA { get; set; }
        public string NOM_PRO { get; set; }
        public string SUBTITULO_PRO { get; set; }
        public int ID_GENERO { get; set; }
        public double PRECIO_PRO { get; set; }
        public double PRE_DESCU_PRO { get; set; }
        public double COSTO_ENVIO { get; set; }
        public int DIAS_TARDA_LLEGAR { get; set; }
        public int STOCK { get; set; }
        public string DESCRIPCION_PRO { get; set; }
        public double CALIFICACION_PRO { get; set; }
        public int ID_SUBCATEGORIA_PER { get; set; }
        public int CANTIDAD_VENDIDA { get; set; }
        public int ESTADO { get; set; }
        public int PERSONALIZABLE { get; set; }
        public string DESCRIP_PERSONALIZABLE { get; set; }
        public int ID_SECCION { get; set; }

        public List<ImagenProductoEntidad> IMAGENES { get; set; }
        public List<TallaProductoEntidad> TALLAS { get; set; }
        public List<ColorProductoEntidad> COLORES { get; set; }
        public List<DetalleProductoEntidad> DETALLES { get; set; }
        public List<ResenaEntidad> RESENAS { get; set; }
        
    }
}