//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace clases.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RAMO_PROFESOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RAMO_PROFESOR()
        {
            this.CLASE = new HashSet<CLASE>();
        }
    
        public Nullable<int> ID_PROFESOR { get; set; }
        public Nullable<int> ID_RAMO { get; set; }
        public int ID_RAMO_PROFE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASE> CLASE { get; set; }
        public virtual PROFESOR PROFESOR { get; set; }
        public virtual RAMO RAMO { get; set; }
    }
}
