//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hckaton2018v2
{
    using System;
    using System.Collections.Generic;
    
    public partial class egreso
    {
        public int idEgreso { get; set; }
        public int idPresupuesto { get; set; }
        public int idArchivo { get; set; }
        public double cantidad { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> votosPositivos { get; set; }
        public Nullable<int> votosNegativos { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    
        public virtual archivo archivo { get; set; }
        public virtual presupuesto presupuesto { get; set; }
    }
}
