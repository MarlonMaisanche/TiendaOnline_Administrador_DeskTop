//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppAdminDesktop_Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESENAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESENAS()
        {
            this.IMAGENES_RESENA = new HashSet<IMAGENES_RESENA>();
        }
    
        public int ID_RESE { get; set; }
        public int ID_PROD_PER { get; set; }
        public int ID_USU_ESCR { get; set; }
        public string TITULO { get; set; }
        public double VALORACION { get; set; }
        public string COMENTARIO { get; set; }
        public Nullable<int> ESTADO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMAGENES_RESENA> IMAGENES_RESENA { get; set; }
        public virtual Productos Productos { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
    }
}