//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Canton
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Canton()
        {
            this.Distritoes = new HashSet<Distrito>();
            this.Clientes = new HashSet<Cliente>();
        }
    
        public int id_Canton { get; set; }
        public int id_Provincia { get; set; }
        public string nombre { get; set; }
        public string usuarioCrea { get; set; }
        public Nullable<System.DateTime> fechaCrea { get; set; }
        public string usuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
        public string vc_Estado { get; set; }
        public int id_CantonInec { get; set; }
    
        public virtual Provincia Provincia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Distrito> Distritoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
