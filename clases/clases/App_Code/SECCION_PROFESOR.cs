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
    
    public partial class SECCION_PROFESOR
    {
        public Nullable<int> ID_PROFESOR { get; set; }
        public Nullable<int> ID_SECCION { get; set; }
        public int ID_PROFE_SECCION { get; set; }
    
        public virtual PROFESOR PROFESOR { get; set; }
        public virtual SECCION SECCION { get; set; }
    }
}