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
    
    public partial class CLASE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLASE()
        {
            this.ALUMNO_CLASE = new HashSet<ALUMNO_CLASE>();
            this.HISTORIAL_CURSO = new HashSet<HISTORIAL_CURSO>();
        }
    
        public int ID_CLASE { get; set; }
        public Nullable<int> ID_CARRERA { get; set; }
        public Nullable<int> ID_RAMO_PROFE { get; set; }
        public Nullable<int> ID_MODULO_SALA { get; set; }
        public string ESTADO_PROFESOR { get; set; }
        public Nullable<System.DateTime> FECHA_CLASE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALUMNO_CLASE> ALUMNO_CLASE { get; set; }
        public virtual CARRERA CARRERA { get; set; }
        public virtual MODULO_SALA MODULO_SALA { get; set; }
        public virtual RAMO_PROFESOR RAMO_PROFESOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIAL_CURSO> HISTORIAL_CURSO { get; set; }
    }
}
