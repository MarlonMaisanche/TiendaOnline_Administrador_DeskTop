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
    
    public partial class CATEGORIAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIAS()
        {
            this.SUBCATEGORIAS = new HashSet<SUBCATEGORIAS>();
        }
    
        public int ID_CATEGORIA { get; set; }
        public string NOM_CATEGORIA { get; set; }
        public string IMAGEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBCATEGORIAS> SUBCATEGORIAS { get; set; }
    }
}