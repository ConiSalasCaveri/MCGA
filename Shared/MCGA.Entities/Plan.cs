//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCGA.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plan()
        {
            this.Afiliado = new HashSet<Afiliado>();
        }
    
        public int Id { get; set; }
        public string descripcion { get; set; }
        public decimal precio_bono_consulta { get; set; }
        public decimal precio_bono_farmacia { get; set; }
        public System.DateTime createdon { get; set; }
        public string createdby { get; set; }
        public System.DateTime changedon { get; set; }
        public string changedby { get; set; }
        public Nullable<System.DateTime> deletedon { get; set; }
        public string deletedby { get; set; }
        public bool isdeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Afiliado> Afiliado { get; set; }
    }
}
