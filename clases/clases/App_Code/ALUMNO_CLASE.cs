//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace clases.App_Code
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALUMNO_CLASE
    {
        public Nullable<int> ID_ALUMNO { get; set; }
        public Nullable<int> ID_CLASE { get; set; }
        public Nullable<bool> ESTADO_ALUMNO { get; set; }
        public int ID_ALUMNO_CLASE { get; set; }
    
        public virtual ALUMNO ALUMNO { get; set; }
        public virtual CLASE CLASE { get; set; }
    }
}
