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
    
    public partial class MODULO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MODULO()
        {
            this.MODULO_SALA = new HashSet<MODULO_SALA>();
            this.SECCION_MODULO = new HashSet<SECCION_MODULO>();
        }
    
        public int ID_MODULO { get; set; }
        public Nullable<int> NOMBRE_MODULO { get; set; }
        public Nullable<System.TimeSpan> HORARIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MODULO_SALA> MODULO_SALA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SECCION_MODULO> SECCION_MODULO { get; set; }
    }
}