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
    
    public partial class TBL_Preferencias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Preferencias()
        {
            this.TBL_Cliente = new HashSet<TBL_Cliente>();
        }
    
        public int PK_PrefID { get; set; }
        public string PRE_Tematica { get; set; }
        public int FK_RestauranteID { get; set; }
        public int FK_PlatoId { get; set; }
    
        public virtual TBL_Plato TBL_Plato { get; set; }
        public virtual TBL_Restaurante TBL_Restaurante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Cliente> TBL_Cliente { get; set; }
    }
}
