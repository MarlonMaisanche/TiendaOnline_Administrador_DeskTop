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
    
    public partial class COLECCIONES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COLECCIONES()
        {
            this.DETALLE_COLECCION = new HashSet<DETALLE_COLECCION>();
        }
    
        public int ID_COLECCION { get; set; }
        public string NOM_COLECCION { get; set; }
        public string DES_COLECCION { get; set; }
        public Nullable<System.DateTime> FECHA_LANZAMIENTO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_COLECCION> DETALLE_COLECCION { get; set; }
    }
}
