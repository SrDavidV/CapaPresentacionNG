//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaPresentacionNG
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Promociones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Promociones()
        {
            this.TBL_Restaurante = new HashSet<TBL_Restaurante>();
        }
    
        public int PK_PromocionId { get; set; }
        public double PRO_Descuento { get; set; }
        public int PRO_puntosParaCanjear { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Restaurante> TBL_Restaurante { get; set; }
    }
}
