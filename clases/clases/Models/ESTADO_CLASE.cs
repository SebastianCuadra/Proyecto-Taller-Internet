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
    
    public partial class ESTADO_CLASE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADO_CLASE()
        {
            this.HISTORIAL_CURSO = new HashSet<HISTORIAL_CURSO>();
        }
    
        public int ID_ESTADO { get; set; }
        public string NOMBRE_ESTADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_CURSO> HISTORIAL_CURSO { get; set; }
    }
}